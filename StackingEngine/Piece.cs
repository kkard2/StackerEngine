namespace StackingEngine
{
    public record Piece
    {
        public PieceType Type { get; set; }
        public Pos Pos { get; set; }
        public Orientation Rot { get; set; }
    }
}
