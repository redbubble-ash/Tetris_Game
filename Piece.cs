﻿namespace Tetris_Game
{
    class Piece
    {
        enum Bricks { I, O, T, S, Z, J, L }

        static Point[][] pieces;  // jagged arrays.

        static Piece()
        {
            int[,] block = new int[4, 4];

            pieces = new Point[7][];
            pieces[0] = new Point[] { new Point { x = 1, y = 3 }, new Point { x = 1, y = 2 }, new Point { x = 1, y = 1 }, new Point { x = 1, y = 0 } }; // I shape
            pieces[1] = new Point[] { new Point { x = 0, y = 0 }, new Point { x = 1, y = 0 }, new Point { x = 0, y = 1 }, new Point { x = 1, y = 1 } }; // O shape
            pieces[2] = new Point[] { new Point { x = 0, y = 1 }, new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 2, y = 0 } }; // T shape
            pieces[3] = new Point[] { new Point { x = 0, y = 0 }, new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 2, y = 1 } }; // S shape
            pieces[4] = new Point[] { new Point { x = 0, y = 1 }, new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 2, y = 0 } }; // Z shape
            pieces[5] = new Point[] { new Point { x = 0, y = 0 }, new Point { x = 1, y = 0 }, new Point { x = 2, y = 0 }, new Point { x = 2, y = 1 } }; // J shape
            pieces[6] = new Point[] { new Point { x = 0, y = 0 }, new Point { x = 0, y = 1 }, new Point { x = 1, y = 0 }, new Point { x = 2, y = 0 } }; // L shape

            //fill each shape into 4x4 matrix and assign filled cell to 1 (default the unfilled cells are zero)
            foreach (var piece in pieces)
            {
                foreach (var cell in piece)
                {
                    block[cell.x,cell.y] = 1;
                }
            }

        }

    }


}
