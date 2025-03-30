namespace StackingEngine;

public record Piece
{
    public required PieceType Type { get; init; }
    public required Pos Pos { get; init; }
    public required Orientation Rot { get; init; }

    public Piece Move(Pos offset)
    {
        return this with
        {
            Pos = Pos + offset
        };
    }
}
