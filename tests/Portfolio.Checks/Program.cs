using ErenPortfolio.Data;
using ErenPortfolio.Models;

var checks = 0;
void Check(bool condition, string message)
{
    if (!condition) throw new InvalidOperationException(message);
    checks++;
    Console.WriteLine($"PASS: {message}");
}

var game = new ExplorationState();
Check(game.Position == 1 && game.CollectedCount == 0 && !game.Completed, "New game starts without progress");
for (var i = 0; i < 30; i++) game.Move(-1);
Check(game.Position == 0, "Player cannot leave the left edge");
for (var i = 0; i < 30; i++) game.Move(1);
Check(game.Position == ExplorationState.LastPosition, "Player cannot leave the right edge");
Check(game.Completed && game.CollectedCount == 3, "Traversing the world collects all gems and completes the quest");
for (var i = 0; i < 30; i++) game.Move(-1);
Check(game.CollectedCount == 3, "Revisiting a gem cannot award it twice");
game.Reset();
Check(game.Position == 1 && game.CollectedCount == 0 && !game.Completed, "Restart clears both progress and player position");
Check(!ExplorationState.GemPositions.Any(game.IsCollected), "All gems return on restart");
game.Move(500);
Check(game.Position == 2, "Movement is a single step even with an oversized direction");
game.Move(0);
Check(game.Position == 2, "A zero direction does not move the player");
Check(PortfolioContent.Filter("All").Count() == 4, "All projects includes the full library");
Check(PortfolioContent.Filter("Games").Count() == 3, "Games filter excludes the AR experiment");
Check(PortfolioContent.Filter("Experiments").Single().Id == "ar-room", "Experiments filter selects AR Room Scanner");
Check(!PortfolioContent.Filter("unknown").Any(), "Unknown filters return no unrelated projects");
Check(PortfolioContent.Projects.Select(p => p.Id).Distinct().Count() == PortfolioContent.Projects.Count, "Project identifiers are unique");
Check(PortfolioContent.Projects.All(p => !string.IsNullOrWhiteSpace(p.Detail)), "Every project has usable detail content");
Check(PortfolioContent.Projects.SelectMany(p => new[] { p.SourceUrl, p.PlayUrl }).Where(url => url is not null).All(url => Uri.TryCreate(url, UriKind.Absolute, out var uri) && uri.Scheme == "https"), "Published project links use HTTPS");
Console.WriteLine($"\n{checks} checks passed.");
