using System;
using System.Linq;

namespace StackingEngine
{
    public class Board
    {
        public Board(int width = 10, int height = 20)
        {
            State = new PieceType?[height * 2][];
            for (var i = 0; i < height * 2; i++)
                State[i] = new PieceType?[width];

            Width = width;
            Height = height;
        }

        public PieceType?[][] State { get; }
        public int Width { get; }
        public int Height { get; }

        /// <summary>
        /// Returns null if spawn position is blocked.
        /// </summary>
        public Piece? SpawnPiece(PieceType type)
        {
            if (Width != 10 || Height != 20)
                throw new NotImplementedException(":weary:");

            var result = new Piece
            {
                Type = type,
                Rot = Orientation.Up,
                Pos = new Pos(3, 21)
            };

            if (CheckCollision(result))
                return null;
            else
                return result;
        }

        /// <summary>
        /// True if overlaps board bounds/placed cell.
        /// </summary>
        public bool CheckCollision(Piece piece)
        {
            foreach (var pos in piece.Type.Rotations[piece.Rot])
            {
                var realPos = pos + piece.Pos;
                if (!PosInBounds(realPos))
                    return true;

                if (State[realPos.Y][realPos.X] is not null)
                    return true;
            }

            return false;
        }

        public Piece? Rotate(Piece piece, bool cw)
        {
            Orientation newRot;
            if (cw)
            {
                newRot = piece.Rot switch
                {
                    Orientation.Up => Orientation.Right,
                    Orientation.Right => Orientation.Down,
                    Orientation.Down => Orientation.Left,
                    Orientation.Left => Orientation.Up,
                    _ => throw new InvalidOperationException("Unknown orientation")
                };
            }
            else
            {
                newRot = piece.Rot switch
                {
                    Orientation.Up => Orientation.Left,
                    Orientation.Left => Orientation.Down,
                    Orientation.Down => Orientation.Right,
                    Orientation.Right => Orientation.Up,
                    _ => throw new InvalidOperationException("Unknown orientation")
                };
            }

            foreach (var kick in piece.Type.KickTable[(piece.Rot, newRot)])
            {
                var result = new Piece
                {
                    Type = piece.Type,
                    Pos = piece.Pos + kick,
                    Rot = newRot
                };

                if (!CheckCollision(result))
                    return result;
            }

            return null;
        }
	
        public Piece? Move(Piece piece, Pos offset)
        {
            var new_piece = piece with
            {
                Pos = piece.Pos + offset
            };
            return CheckCollision(new_piece) ? null : new_piece;
        }

        public Piece? Dash(Piece piece, Pos offset)
        {
            while (true)
            {
                var newPiece = Move(piece, offset);
                if (newPiece == null)
                {
                    return piece;
                }
                piece = newPiece;
            }
        }

        /// <summary>
        /// This does not check anything.
        /// </summary>
        public void Place(Piece p)
        {
            foreach (var offset in p.Type.Rotations[p.Rot])
            {
                var pos = p.Pos + offset;
                if (PosInBounds(pos))
                    State[pos.Y][pos.X] = p.Type;
            }
        }

        public int ClearLines()
        {
            int cleared = 0;

            for (int y = State.Length - 1; y >= 0; y--)
            {
                if (State[y].All(cell => cell is not null)) // Row is full
                {
                    cleared++;

                    // Shift all rows above down
                    for (int row = y; row < State.Length - 1; row++)
                        State[row] = State[row + 1];

                    // Clear the topmost row
                    State[Height * 2 - 1] = new PieceType?[Width];

                    // Since we removed a row, stay on the same index
                    y++;
                }
            }

            return cleared;
        }

        public void PrintBoard()
        {
            for (int y = Height * 2 - 1; y >= 0; y--)  // Start from the top (since 0 is the bottom)
            {
                for (int x = 0; x < Width; x++)
                {
                    var piece = State[y][x];
                    if (piece is not null)
                        Console.Write(piece.Name); // Print the piece's name (a single character)
                    else
                        Console.Write("."); // Print '.' for empty space
                }
                Console.WriteLine(); // Newline at the end of each row
            }
        }


        private bool PosInBounds(Pos pos)
        {
            if (pos.X < 0 || pos.X >= Width)
                return false;
            if (pos.Y < 0 || pos.Y >= State.Length)
                return false;

            return true;
        }
    }
}
