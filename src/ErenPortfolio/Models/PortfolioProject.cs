namespace ErenPortfolio.Models;

public sealed record PortfolioProject(
    string Id, string Title, string Category, string Context,
    string Description, string Detail, string[] Technologies,
    string? Image, string ImageAlt, string? SourceUrl);
