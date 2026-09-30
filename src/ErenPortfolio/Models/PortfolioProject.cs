namespace ErenPortfolio.Models;

public sealed record PortfolioProject(
    string Id, string Title, string Category, string Context,
    string Description, string Detail, string[] Technologies,
    string? Image, string ImageAlt, string? SourceUrl, string? PlayUrl = null,
    string Status = "Source available", string Role = "",
    string ImageLabel = "IN-GAME CAPTURE", string[]? Highlights = null,
    ProjectMedia[]? Gallery = null)
{
    public IReadOnlyList<ProjectMedia> Media => Image is null ? [] :
        new[] { new ProjectMedia(Image, ImageAlt) }.Concat(Gallery ?? []).ToArray();
}

public sealed record ProjectMedia(string Path, string Alt);
