namespace ErenPortfolio.Models;

public sealed record GitHubCommit(
    string Sha, string Title, string Body, DateTimeOffset? CommittedAt,
    string Url, DateTimeOffset RetrievedAt)
{
    public string ShortSha => Sha[..7];
}

public enum CommitLoadStatus { Loaded, Empty, Unavailable, RateLimited, TimedOut }

public sealed record CommitLoadResult(CommitLoadStatus Status, GitHubCommit? Commit = null)
{
    public bool IsStale => Commit is not null && Status != CommitLoadStatus.Loaded;
}
