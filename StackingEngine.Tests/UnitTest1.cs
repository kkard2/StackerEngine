﻿using StackingEngine;

namespace StackingEngine.Tests;

public class UnitTest1
{
    public static void DebugPieceRotation(PieceType pieceType, Orientation orientation)
    {
        // Find the size of the grid to render the piece
        var positions = pieceType.Rotations[orientation];
        int maxX = positions.Max(p => p.X) + 1;
        int maxY = positions.Max(p => p.Y) + 1;

        char[,] board = new char[maxY, maxX];

        // Fill the grid with '.' (empty space)
        for (int y = 0; y < maxY; y++)
        {
            for (int x = 0; x < maxX; x++)
            {
                board[y, x] = '.'; // Empty space
            }
        }

        // Place the piece on the grid based on its rotation
        foreach (var pos in positions)
        {
            int xPos = pos.X; // Apply offset to center the piece
            int yPos = pos.Y; // Apply offset to center the piece
            board[yPos, xPos] = pieceType.Name[0]; // Place the piece name (single char)
        }

        // Print the board with padding
        for (int y = 0; y < maxY; y++)
        {
            for (int x = 0; x < maxX; x++)
            {
                Console.Write(board[y, x]); // Print each character in the grid
            }
            Console.WriteLine(); // Move to the next line after each row
        }
    }

    //[Fact]
    public void Show()
    {
                var pieces = new PieceType[] { Pieces.I, Pieces.O, Pieces.T, Pieces.L, Pieces.J, Pieces.S, Pieces.Z };

        foreach (var piece in pieces)
        {
            Console.WriteLine($"Piece: {piece.Name}");
            foreach (var orientation in Enum.GetValues<Orientation>())
            {
                Console.WriteLine($"Orientation: {orientation}");
                DebugPieceRotation(piece, orientation);
                Console.WriteLine(); // Add spacing between rotations
            }
        }
    }

    [Fact]
    public void Bag()
    {
        var q = new PieceQueue(0);
        for (var i = 0; i < 1000; i++)
            Console.WriteLine(q.Next().Name);
    }

    [Fact]
    public void Tki()
    {
        var board = new Board();

        var i = board.SpawnPiece(Pieces.I);
        i = board.Dash(i, Pos.Down);
        board.Place(i);
        // ...IIII...
        board.PrintBoard();

        var z = board.SpawnPiece(Pieces.Z);
        z = board.Dash(z, Pos.Down);
        board.Place(z);
        // ...ZZ.....
        // ....ZZ....
        // ...IIII...
        board.PrintBoard();

        var l = board.SpawnPiece(Pieces.L);
        l = board.Rotate(l, true);
        Assert.NotNull(l);
        l = board.Dash(l, Pos.Left);
        l = board.Dash(l, Pos.Down);
        board.Place(l);
        // L..ZZ.....
        // L...ZZ....
        // LL.IIII...
        board.PrintBoard();

        var o = board.SpawnPiece(Pieces.O);
        o = board.Dash(o, Pos.Right);
        o = board.Dash(o, Pos.Down);
        board.Place(o);
        // L..ZZ.....
        // L...ZZ..OO
        // LL.IIII.OO
        board.PrintBoard();

        var s = board.SpawnPiece(Pieces.S);
        s = board.Rotate(s, true);
        s = board.Move(s, Pos.Right);
        s = board.Move(s, Pos.Right);
        s = board.Dash(s, Pos.Down);
        board.Place(s);
        // L..ZZ.S...
        // L...ZZSSOO
        // LL.IIIISOO
        board.PrintBoard();

        var t = board.SpawnPiece(Pieces.T);
        t = board.Dash(t, Pos.Left);
        t = board.Rotate(t, true);
        t = board.Dash(t, Pos.Down);
        t = board.Rotate(t, true);
        board.Place(t);
        board.PrintBoard();
        Assert.Equal(2, board.ClearLines());
        board.PrintBoard();

    }
}
