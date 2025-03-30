namespace StackingEngine;

public static class Pieces
{
    public static readonly Dictionary<(Orientation, Orientation), Pos[]> StandardKickTable = new()
    {
        // Standard (JLSTZ) Kicks
        { (Orientation.Up, Orientation.Right),   new[] { new Pos(0, 0), new Pos(-1, 0), new Pos(-1, 1), new Pos(0, -2), new Pos(-1, -2) } },
        { (Orientation.Right, Orientation.Up),   new[] { new Pos(0, 0), new Pos(1, 0), new Pos(1, -1), new Pos(0, 2), new Pos(1, 2) } },

        { (Orientation.Right, Orientation.Down), new[] { new Pos(0, 0), new Pos(1, 0), new Pos(1, -1), new Pos(0, 2), new Pos(1, 2) } },
        { (Orientation.Down, Orientation.Right), new[] { new Pos(0, 0), new Pos(-1, 0), new Pos(-1, 1), new Pos(0, -2), new Pos(-1, -2) } },

        { (Orientation.Down, Orientation.Left),  new[] { new Pos(0, 0), new Pos(1, 0), new Pos(1, 1), new Pos(0, -2), new Pos(1, -2) } },
        { (Orientation.Left, Orientation.Down),  new[] { new Pos(0, 0), new Pos(-1, 0), new Pos(-1, -1), new Pos(0, 2), new Pos(-1, 2) } },

        { (Orientation.Left, Orientation.Up),    new[] { new Pos(0, 0), new Pos(-1, 0), new Pos(-1, -1), new Pos(0, 2), new Pos(-1, 2) } },
        { (Orientation.Up, Orientation.Left),    new[] { new Pos(0, 0), new Pos(1, 0), new Pos(1, 1), new Pos(0, -2), new Pos(1, -2) } }
    };

    public static readonly Dictionary<(Orientation, Orientation), Pos[]> I_KickTable = new()
    {
        // I piece has its own unique kick table
        { (Orientation.Up, Orientation.Right),   new[] { new Pos(0, 0), new Pos(-2, 0), new Pos(1, 0), new Pos(-2, -1), new Pos(1, 2) } },
        { (Orientation.Right, Orientation.Up),   new[] { new Pos(0, 0), new Pos(2, 0), new Pos(-1, 0), new Pos(2, 1), new Pos(-1, -2) } },

        { (Orientation.Right, Orientation.Down), new[] { new Pos(0, 0), new Pos(-1, 0), new Pos(2, 0), new Pos(-1, 2), new Pos(2, -1) } },
        { (Orientation.Down, Orientation.Right), new[] { new Pos(0, 0), new Pos(1, 0), new Pos(-2, 0), new Pos(1, -2), new Pos(-2, 1) } },

        { (Orientation.Down, Orientation.Left),  new[] { new Pos(0, 0), new Pos(2, 0), new Pos(-1, 0), new Pos(2, 1), new Pos(-1, -2) } },
        { (Orientation.Left, Orientation.Down),  new[] { new Pos(0, 0), new Pos(-2, 0), new Pos(1, 0), new Pos(-2, -1), new Pos(1, 2) } },

        { (Orientation.Left, Orientation.Up),    new[] { new Pos(0, 0), new Pos(1, 0), new Pos(-2, 0), new Pos(1, -2), new Pos(-2, 1) } },
        { (Orientation.Up, Orientation.Left),    new[] { new Pos(0, 0), new Pos(-1, 0), new Pos(2, 0), new Pos(-1, 2), new Pos(2, -1) } }
    };

    public static PieceType I { get; } = new()
    {
        Name = "I",
        Rotations = new()
        {
            [Orientation.Up] = new Pos[] { new(0, 2), new(1, 2), new(2, 2), new(3, 2) },
            [Orientation.Right] = new Pos[] { new(2, 0), new(2, 1), new(2, 2), new(2, 3) },
            [Orientation.Down] = new Pos[] { new(0, 1), new(1, 1), new(2, 1), new(3, 1) },
            [Orientation.Left] = new Pos[] { new(1, 0), new(1, 1), new(1, 2), new(1, 3) }
        },
        KickTable = I_KickTable
    };

    public static PieceType O { get; } = new()
    {
        Name = "O",
        Rotations = new()
        {
            [Orientation.Up] = new Pos[] { new(1, 1), new(1, 2), new(2, 1), new(2, 2) },
            [Orientation.Right] = new Pos[] { new(1, 1), new(1, 2), new(2, 1), new(2, 2) },
            [Orientation.Down] = new Pos[] { new(1, 1), new(1, 2), new(2, 1), new(2, 2) },
            [Orientation.Left] = new Pos[] { new(1, 1), new(1, 2), new(2, 1), new(2, 2) }
        },
        KickTable = StandardKickTable
    };

    public static PieceType T { get; } = new()
    {
        Name = "T",
        Rotations = new()
        {
            [Orientation.Up] = new Pos[] { new(0, 1), new(1, 1), new(2, 1), new(1, 2) },
            [Orientation.Right] = new Pos[] { new(1, 0), new(1, 1), new(2, 1), new(1, 2) },
            [Orientation.Down] = new Pos[] { new(0, 1), new(1, 1), new(2, 1), new(1, 0) },
            [Orientation.Left] = new Pos[] { new(1, 0), new(0, 1), new(1, 1), new(1, 2) }
        },
        KickTable = StandardKickTable
    };

    public static PieceType J { get; } = new()
    {
        Name = "J",
        Rotations = new()
        {
            [Orientation.Up] = new Pos[] { new(0, 1), new(0, 2), new(1, 1), new(2, 1) },
            [Orientation.Right] = new Pos[] { new(1, 0), new(1, 1), new(1, 2), new(2, 2) },
            [Orientation.Down] = new Pos[] { new(0, 1), new(1, 1), new(2, 1), new(2, 0) },
            [Orientation.Left] = new Pos[] { new(0, 0), new(1, 0), new(1, 1), new(1, 2) }
        },
        KickTable = StandardKickTable
    };

    public static PieceType L { get; } = new()
    {
        Name = "L",
        Rotations = new()
        {
            [Orientation.Up] = new Pos[] { new(0, 1), new(1, 1), new(2, 1), new(2, 2) },
            [Orientation.Right] = new Pos[] { new(1, 0), new(1, 1), new(1, 2), new(2, 0) },
            [Orientation.Down] = new Pos[] { new(0, 0), new(0, 1), new(1, 1), new(2, 1) },
            [Orientation.Left] = new Pos[] { new(0, 2), new(1, 2), new(1, 1), new(1, 0) }
        },
        KickTable = StandardKickTable
    };

    public static PieceType S { get; } = new()
    {
        Name = "S",
        Rotations = new()
        {
            [Orientation.Up] = new Pos[] { new(0, 1), new(1, 1), new(1, 2), new(2, 2) },
            [Orientation.Right] = new Pos[] { new(1, 2), new(1, 1), new(2, 1), new(2, 0) },
            [Orientation.Down] = new Pos[] { new(0, 0), new(1, 0), new(1, 1), new(1, 2) },
            [Orientation.Left] = new Pos[] { new(0, 2), new(0, 1), new(1, 1), new(1, 0) }
        },
        KickTable = StandardKickTable
    };

    public static PieceType Z { get; } = new()
    {
        Name = "Z",
        Rotations = new()
        {
            [Orientation.Up] = new Pos[] { new(0, 2), new(1, 2), new(1, 1), new(2, 1) },
            [Orientation.Right] = new Pos[] { new(1, 0), new(1, 1), new(2, 1), new(2, 2) },
            [Orientation.Down] = new Pos[] { new(0, 1), new(1, 1), new(1, 0), new(2, 0) },
            [Orientation.Left] = new Pos[] { new(0, 0), new(0, 1), new(1, 1), new(1, 2) }
        },
        KickTable = StandardKickTable
    };
}
