using ErenPortfolio.Models;

namespace ErenPortfolio.Data;

// Public portfolio content. Unknown dates, metrics and private links are omitted.
public static class PortfolioContent
{
    public const string GitHub = "https://github.com/cevdetozbozkurt";
    public static IReadOnlyList<PortfolioProject> Projects { get; } =
    [
        new("square", "Square", "Games", "GAME JAM",
            "Small shape. Big ideas. A game-jam experiment in level design and playful mechanics.",
            "Built during a game jam, Square explores core gameplay mechanics and level design within a short development cycle. It is a project about turning an idea into something playable with a team.",
            ["Unity", "C#", "Level design"], null, "Pixel illustration inspired by Square; not a gameplay screenshot.", null),
        new("woodsman", "WoodsMan", "Games", "INTERNSHIP PROJECT",
            "Chop, collect, grow. An arcade idle game built around a satisfying gameplay loop.",
            "An arcade idle game developed during a summer internship. Explore the project repository and its gameplay images to see the world, resource collection and progression in action.",
            ["Unity", "C#", "Arcade idle"], "assets/images/woodsman.png", "Actual WoodsMan gameplay showing its forest environment.", "https://github.com/cevdetozbozkurt/WoodsMan"),
        new("rocketsan", "Rocket-San", "Games", "IEEE CLUB PROJECT",
            "A little thrust goes a long way. A rocket parkour game about movement and precision.",
            "Developed as an IEEE club project, Rocket-San is a parkour game made with Unity and C#. The repository includes the project source and screenshots of its obstacle courses.",
            ["Unity", "C#", "Parkour"], "assets/images/rocketsan.png", "Actual Rocket-San gameplay with a rocket and platform obstacles.", "https://github.com/cevdetozbozkurt/Rocketsan"),
        new("ar-room", "AR Room Scanner", "Experiments", "APPLIED AR",
            "Bringing software into physical spaces. An augmented-reality room scanning project.",
            "A Unity and C# project developed as part of a part-time role, exploring room scanning through augmented reality. A public demo and source repository are not currently listed.",
            ["Unity", "C#", "Augmented reality"], null, "Concept illustration of a room scanner; not an application screenshot.", null)
    ];

    public static IEnumerable<PortfolioProject> Filter(string category) =>
        category == "All" ? Projects : Projects.Where(project => project.Category == category);
}
