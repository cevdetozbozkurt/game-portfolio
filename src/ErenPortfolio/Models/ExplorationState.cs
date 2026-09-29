namespace ErenPortfolio.Models;

/// <summary>A small bounded exploration game. All gameplay state runs in C#.</summary>
public sealed class ExplorationState
{
    public const int LastPosition = 12;
    public static IReadOnlyList<int> GemPositions { get; } = Array.AsReadOnly(new[] { 3, 7, 11 });
    private readonly HashSet<int> collected = [];
    public int Position { get; private set; } = 1;
    public int CollectedCount => collected.Count;
    public bool Completed => collected.Count == GemPositions.Count;
    public bool IsCollected(int position) => collected.Contains(position);

    public bool Move(int direction)
    {
        Position = Math.Clamp(Position + Math.Sign(direction), 0, LastPosition);
        return GemPositions.Contains(Position) && collected.Add(Position);
    }

    public void Reset()
    {
        Position = 1;
        collected.Clear();
    }
}
