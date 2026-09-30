using ErenPortfolio.Models;

namespace ErenPortfolio.Data;

// Verified public portfolio content. Sources and asset attribution: docs/CONTENT-SOURCES.md.
public static class PortfolioContent
{
    public const string GitHub = "https://github.com/cevdetozbozkurt";
    public const string LinkedIn = "https://www.linkedin.com/in/cevdetozbzkrt/";
    public const string ItchIo = "https://ceox.itch.io/";
    public const string Email = "ce.ozbozkurt@gmail.com";

    public static IReadOnlyList<PortfolioProject> Projects { get; } =
    [
        new("exiled-frontiers", "Exiled Frontiers", "Games", "SOLO RTS PROTOTYPE",
            "A settlement starts with a single worker. An experiment in resource gathering, building and AI.",
            "A solo, isometric real-time strategy and city-building prototype. I focused on the systems underneath the world: worker roles, NavMesh movement, a shared inventory, crafting and grid-based construction. The prototype uses simple 3D shapes so the core loop can be tested. A downloadable Windows build is available on itch.io.",
            ["Unity", "C#", "NavMesh", "Systems design"], "assets/images/exiled-sketch.svg",
            "Original isometric illustration of the prototype's gather, craft and build loop; not a gameplay screenshot.",
            "https://github.com/cevdetozbozkurt/Exiled-Frontiers", "https://ceox.itch.io/exiled-frontiers-prototip",
            Status: "Prototype · Windows", Role: "Solo developer", ImageLabel: "SYSTEMS ILLUSTRATION",
            Highlights: ["Select and command workers with different roles", "Collect resources into a shared inventory", "Craft items and place buildings on a grid", "Assign builders to turn foundations into structures"]),
        new("square", "Square", "Games", "MAĞARA JAM #5",
            "Small shape. Big questions. A minimalist puzzle game about a square trying to find where it belongs.",
            "Created for Mağara Jam #5, Square follows a shape searching for others like itself. I worked as a game developer and animator alongside Ömer Furkan İşleyen, Buğra Okumuş and Yaren Nur Solmaz. The team created the game's assets from scratch. Available for Windows on itch.io.",
            ["Unity", "C#", "Animation"], "assets/images/square.png", "Official Square artwork from the game's itch.io page.",
            "https://github.com/cevdetozbozkurt/MagaraJam5", "https://omerfi.itch.io/square",
            Status: "Released · Windows", Role: "Game developer & animator", ImageLabel: "GAME ARTWORK",
            Highlights: ["Original team-made art and audio", "Puzzle levels with a narrative twist", "Movement, combat sections and a boss encounter"]),
        new("second", "SE:CO:ND", "Games", "JAMINATION 6",
            "A world where nothing disappears. A platforming journey after a purpose slipping away in time.",
            "A 2D platformer made for Jamination 6 with Yaren Nur Solmaz. In a world where nothing is lost, a man pursues a purpose that fades with time. I am credited as a game developer. The Windows game is available on itch.io; its page also includes the original controls and asset credits.",
            ["Unity", "C#", "2D platformer"], "assets/images/second.png", "Actual SE:CO:ND gameplay showing the player, a house, platforms and a timer.",
            null, "https://yns21.itch.io/second", Status: "Released · Windows", Role: "Co-developer",
            Highlights: ["A collaborative game-jam project", "Platforming in a stark black-and-white world", "Keyboard movement and jumping"],
            Gallery: [new("assets/images/second-menu.png", "SE:CO:ND's original title menu.")]),
        new("woodsman", "WoodsMan", "Games", "INTERNSHIP PROJECT",
            "Chop, collect, grow. An arcade idle game built around a satisfying gameplay loop.",
            "An arcade idle game developed during a summer internship. This project gave me room to explore the rhythm of resource collection and progression in Unity. The repository contains the project source and screenshots from the playable prototype.",
            ["Unity", "C#", "Arcade idle"], "assets/images/woodsman.png", "Actual WoodsMan gameplay showing its forest environment.",
            "https://github.com/cevdetozbozkurt/WoodsMan", Role: "Game development internship",
            Highlights: ["Arcade idle gameplay", "Resource collection and progression", "A Unity project built during a summer internship"],
            Gallery: [new("assets/images/woodsman-2.png", "Another in-game view of the WoodsMan prototype.")]),
        new("rocketsan", "Rocket-San", "Games", "IEEE CLUB PROJECT",
            "A little thrust goes a long way. A rocket parkour game about movement and precision.",
            "Developed as an IEEE club project, Rocket-San is a parkour game made with Unity and C#. A small rocket navigates a course of obstacles. The public repository contains the source project and screenshots from its levels.",
            ["Unity", "C#", "Parkour"], "assets/images/rocketsan.png", "Actual Rocket-San gameplay with a rocket and platform obstacles.",
            "https://github.com/cevdetozbozkurt/Rocketsan", Role: "Game developer · IEEE club",
            Highlights: ["Rocket movement through obstacle courses", "A project developed within the IEEE club", "Source and level screenshots available on GitHub"],
            Gallery: [new("assets/images/rocketsan-2.png", "Another obstacle course from Rocket-San.")]),
        new("escape-monsters", "Escape From Monsters", "Games", "2D GAME EXPERIMENT",
            "Keep moving. Keep jumping. A small 2D game with monsters arriving from both sides.",
            "A Unity experiment in player movement, jumping, animation and enemy spawning. Monsters appear from either side with randomized timing and speed. Colliding with an enemy ends the run and displays the game-over interface. The source is published in my 2D-game repository.",
            ["Unity", "C#", "2D physics"], "assets/images/escape-monsters.png", "Actual Escape From Monsters gameplay: a jumping character above a ghost under a starry sky.",
            "https://github.com/cevdetozbozkurt/2D-game", Role: "Game developer",
            Highlights: ["Movement and jumping with Rigidbody2D", "Randomized enemy timing and movement", "Player animation and a game-over interface"]),
        new("flappy", "Flappy Bird Clone", "Experiments", "LEARNING ARCHIVE",
            "Learning through a familiar loop: tap, fly, miss a pipe, try again.",
            "A small Unity learning project recreating the Flappy Bird-style loop. The code handles a click-driven upward impulse, collision-based game over, score triggers and restarting the scene. It is a practice clone, not an original game concept. The source is available on GitHub; no public playable build is linked.",
            ["Unity", "C#", "2D physics"], "assets/images/flappy-sketch.svg", "Original pixel illustration of a bird and obstacle pipes; not a gameplay screenshot.",
            "https://github.com/cevdetozbozkurt/flappy-bird-clone", Status: "Learning project · source available", Role: "Practice & experimentation", ImageLabel: "CONCEPT ILLUSTRATION",
            Highlights: ["Click-to-flap movement", "Trigger-based scoring", "Collision detection and scene restart"]),
        new("ar-room", "AR Room Scanner", "Experiments", "PAST EXPLORATION",
            "An earlier experiment connecting Unity with physical spaces. Kept here as part of the learning journey.",
            "An earlier Unity project exploring room scanning through augmented reality, developed during a part-time role. The original code and playable demo are not currently available. I keep it here as a record of what I explored.",
            ["Unity", "C#", "Augmented reality"], null, "Concept illustration of a room scanner; not an application screenshot.",
            null, Status: "Past project · source unavailable", Role: "AR exploration", ImageLabel: "CONCEPT ILLUSTRATION",
            Highlights: ["Experience with Unity and augmented reality", "Original source and demo are not archived"])
    ];

    public static IEnumerable<PortfolioProject> Filter(string category) =>
        category == "All" ? Projects : Projects.Where(project => project.Category == category);
}
