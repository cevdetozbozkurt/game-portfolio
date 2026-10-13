using System.Net;
using System.Text.Json;
using ErenPortfolio.Models;
using ErenPortfolio.Services;

internal static class CommitChecks
{
    public static async Task RunAsync(Action<bool, string> check)
    {
        const string repo = "cevdetozbozkurt/UnityLearn";
        const string firstSha = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        const string nextSha = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
        string Payload(string sha, string message, string? date = "2026-10-13T18:36:08Z") =>
            JsonSerializer.Serialize(new[] { new { sha, html_url = "https://untrusted.example/redirect", commit = new { message, committer = new { date } } } });
        var handler = new StubHandler();
        using var http = new HttpClient(handler);
        var service = new GitHubCommitService(http);

        handler.Body = Payload(firstSha, "Lesson completed\r\n\r\n- Player input\r\n- Camera follow");
        var first = await service.GetLatestAsync(repo);
        check(first is { Status: CommitLoadStatus.Loaded, Commit.ShortSha: "aaaaaaa" } &&
            first.Commit.Body == "- Player input\n- Camera follow", "Commit titles and complete multiline descriptions retain their structure");
        check(first.Commit?.Url == $"https://github.com/{repo}/commit/{firstSha}", "Commit links use the intended repository and validated SHA, not response redirects");
        check(first.Commit?.CommittedAt == DateTimeOffset.Parse("2026-10-13T18:36:08Z"), "Commit timestamps retain their timezone");
        check(handler.LastUri?.AbsoluteUri == $"https://api.github.com/repos/{repo}/commits?per_page=1" && !handler.HadAuthorization,
            "The API requests one default-branch commit without credentials");

        handler.Body = Payload(nextSha, "Next lesson completed");
        var next = await service.GetLatestAsync(repo);
        check(handler.Calls == 2 && next.Commit?.Sha == nextSha, "Reopening or refreshing fetches new progress instead of returning a cached success");

        handler.Status = HttpStatusCode.TooManyRequests;
        var limited = await service.GetLatestAsync(repo);
        check(limited is { Status: CommitLoadStatus.RateLimited, IsStale: true } && limited.Commit?.Sha == nextSha,
            "A rate limit keeps the last successful commit explicitly marked as stale");
        handler.Status = HttpStatusCode.Forbidden;
        check((await service.GetLatestAsync("cevdetozbozkurt/OtherRepo")) is { Status: CommitLoadStatus.RateLimited, Commit: null },
            "Cached progress cannot leak between repositories");
        handler.Status = HttpStatusCode.NotFound;
        check((await new GitHubCommitService(http).GetLatestAsync(repo)) is { Status: CommitLoadStatus.Unavailable, Commit: null },
            "An unavailable repository leaves a clean fallback without fabricated progress");

        handler.Status = HttpStatusCode.OK;
        handler.Body = "[]";
        check((await service.GetLatestAsync(repo)) is { Status: CommitLoadStatus.Empty, Commit: null }, "An empty repository has an honest empty state");
        handler.Status = HttpStatusCode.Conflict;
        check((await service.GetLatestAsync(repo)).Status == CommitLoadStatus.Empty, "GitHub's empty-repository conflict is handled");
        handler.Status = HttpStatusCode.OK;
        foreach (var body in new[] { "not json", "{}", "[null]", "[{\"sha\":null}]", Payload("not-a-sha", "Message"), Payload(firstSha, " ") })
        {
            handler.Body = body;
            check((await service.GetLatestAsync(repo)).Status == CommitLoadStatus.Unavailable, "Malformed or incomplete commit data does not break project details");
        }
        handler.Body = Payload(firstSha, "<script>alert('not markup')</script>\n\n**plain text**", null);
        var plainText = await service.GetLatestAsync(repo);
        check(plainText.Commit is { CommittedAt: null, Body: "**plain text**" } && plainText.Commit.Title.StartsWith("<script>"),
            "Messages remain plain text for Razor encoding and missing dates are not invented");
        handler.Error = new HttpRequestException("Offline");
        check((await service.GetLatestAsync(repo)) is { Status: CommitLoadStatus.Unavailable, IsStale: true }, "Offline requests preserve a clearly stale last-loaded update");
        handler.Error = new TaskCanceledException("Timeout");
        check((await service.GetLatestAsync(repo)).Status == CommitLoadStatus.TimedOut, "A timed-out request has a recoverable state");
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();
        var cancelled = false;
        try { await service.GetLatestAsync(repo, cancellation.Token); }
        catch (OperationCanceledException) { cancelled = true; }
        check(cancelled, "Disposed project requests can be cancelled without returning unrelated progress");
        var calls = handler.Calls;
        foreach (var invalid in new[] { "../repo", "user/../repo", "https://example.com", "user/repo?token=value" })
            await service.GetLatestAsync(invalid);
        check(handler.Calls == calls, "Invalid repository identifiers never produce network requests");
    }

    private sealed class StubHandler : HttpMessageHandler
    {
        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
        public string Body { get; set; } = "[]";
        public Exception? Error { get; set; }
        public int Calls { get; private set; }
        public Uri? LastUri { get; private set; }
        public bool HadAuthorization { get; private set; }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Calls++;
            LastUri = request.RequestUri;
            HadAuthorization = request.Headers.Authorization is not null;
            cancellationToken.ThrowIfCancellationRequested();
            if (Error is not null) throw Error;
            return Task.FromResult(new HttpResponseMessage(Status) { Content = new StringContent(Body) });
        }
    }
}
