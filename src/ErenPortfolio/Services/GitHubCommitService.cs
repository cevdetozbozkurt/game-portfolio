using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.RegularExpressions;
using ErenPortfolio.Models;

namespace ErenPortfolio.Services;

/// <summary>Reads public commit metadata only. No token, polling or persistent visitor storage.</summary>
public sealed class GitHubCommitService(HttpClient http, Action<HttpRequestMessage>? configureRequest = null)
{
    private readonly Dictionary<string, GitHubCommit> lastSuccessful = new(StringComparer.OrdinalIgnoreCase);

    public async Task<CommitLoadResult> GetLatestAsync(string repository, CancellationToken cancellationToken = default)
    {
        // Repository identifiers are authored in the project data, never supplied by visitors.
        if (repository.Length > 200 || !Regex.IsMatch(repository, @"\A[A-Za-z0-9][A-Za-z0-9-]*/[A-Za-z0-9][A-Za-z0-9._-]*\z"))
            return new(CommitLoadStatus.Unavailable);

        CommitLoadResult Failed(CommitLoadStatus status) => new(status, lastSuccessful.GetValueOrDefault(repository));
        using var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeout.CancelAfter(TimeSpan.FromSeconds(8));
        try
        {
            // Omitting sha follows the repository's current default branch, even after a rename.
            using var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/repos/{repository}/commits?per_page=1");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
            request.Headers.Add("X-GitHub-Api-Version", "2026-03-10");
            configureRequest?.Invoke(request);
            using var response = await http.SendAsync(request, timeout.Token);
            if (response.StatusCode is HttpStatusCode.Forbidden or HttpStatusCode.TooManyRequests)
                return Failed(CommitLoadStatus.RateLimited);
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                lastSuccessful.Remove(repository);
                return new(CommitLoadStatus.Empty);
            }
            if (!response.IsSuccessStatusCode) return Failed(CommitLoadStatus.Unavailable);

            using var document = JsonDocument.Parse(await response.Content.ReadAsStringAsync(timeout.Token));
            var root = document.RootElement;
            if (root.ValueKind != JsonValueKind.Array) return Failed(CommitLoadStatus.Unavailable);
            if (root.GetArrayLength() == 0)
            {
                lastSuccessful.Remove(repository);
                return new(CommitLoadStatus.Empty);
            }

            var item = root[0];
            if (item.ValueKind != JsonValueKind.Object ||
                !item.TryGetProperty("sha", out var shaValue) || shaValue.ValueKind != JsonValueKind.String ||
                !item.TryGetProperty("commit", out var commit) || commit.ValueKind != JsonValueKind.Object ||
                !commit.TryGetProperty("message", out var messageValue) || messageValue.ValueKind != JsonValueKind.String)
                return Failed(CommitLoadStatus.Unavailable);

            var sha = shaValue.GetString()!;
            var message = messageValue.GetString()!.Replace("\r\n", "\n").Replace('\r', '\n').Trim();
            if (!Regex.IsMatch(sha, @"\A[0-9a-fA-F]{40}\z") || string.IsNullOrWhiteSpace(message))
                return Failed(CommitLoadStatus.Unavailable);

            DateTimeOffset? committedAt = null;
            if (commit.TryGetProperty("committer", out var committer) && committer.ValueKind == JsonValueKind.Object &&
                committer.TryGetProperty("date", out var date) && date.ValueKind == JsonValueKind.String &&
                date.TryGetDateTimeOffset(out var parsedDate))
                committedAt = parsedDate;

            var newline = message.IndexOf('\n');
            var title = newline < 0 ? message : message[..newline];
            var body = newline < 0 ? "" : message[(newline + 1)..].Trim();
            cancellationToken.ThrowIfCancellationRequested();
            var result = new GitHubCommit(sha, title, body, committedAt,
                $"https://github.com/{repository}/commit/{sha}", DateTimeOffset.UtcNow);
            lastSuccessful[repository] = result;
            return new(CommitLoadStatus.Loaded, result);
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            return Failed(CommitLoadStatus.TimedOut);
        }
        catch (HttpRequestException) { return Failed(CommitLoadStatus.Unavailable); }
        catch (JsonException) { return Failed(CommitLoadStatus.Unavailable); }
    }
}
