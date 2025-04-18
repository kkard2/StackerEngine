namespace StackingEngine
{
    public struct Pos
    {
        public Pos(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public static Pos Up { get; } = new Pos(-1, 0);
        public static Pos Right { get; } = new Pos(1, 0);
        public static Pos Down { get; } = new Pos(0, -1);
        public static Pos Left { get; } = new Pos(-1, 0);

        public static Pos operator +(Pos a, Pos b)
        {
            return new Pos(a.X + b.X, a.Y + b.Y);
        }
    }
}
