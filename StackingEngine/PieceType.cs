namespace StackingEngine;

public class PieceType
{
    public required string Name { get; init; }

    public required Dictionary<Orientation, Pos[]> Rotations { get; init; }
    public required Dictionary<(Orientation, Orientation), Pos[]> KickTable { get; init; }
}
