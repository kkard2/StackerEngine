namespace StackingEngine
{
    public class PieceQueue
    {
        private readonly Random _random;
        private Queue<PieceType> _queue = new();


        public PieceQueue(int seed)
        {
            _random = new Random(seed);
        }

        public PieceType Next()
        {
            if (_queue.Count == 0)
                RegenerateQueue();
            return _queue.Dequeue();
        }

        private void RegenerateQueue()
        {
            var bag = new PieceType[] { Pieces.I, Pieces.O, Pieces.T, Pieces.L, Pieces.J, Pieces.S, Pieces.Z };
            _random.Shuffle(bag);
            _queue = new Queue<PieceType>(bag);
        }
    }
}
