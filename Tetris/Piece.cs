﻿using System;
using System.Text;

namespace Tetris_Game

{
    public enum Bricks { I, O, T, S, Z, J, L }

    internal class Piece
    {
        private static Point[][] pieces;  // jagged arrays.
        private static int[][,] blocks = new int[7][,]; //arrary of 7 2d arrays
        public int[,] pieceStore; //non static 4*4 array to store cell status in order to rotate

        static Piece()
        {
            pieces = new Point[7][];
            pieces[0] = new Point[] { new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 1, y = 2 }, new Point { x = 1, y = 3 } }; // I shape
            pieces[1] = new Point[] { new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 2, y = 0 }, new Point { x = 2, y = 1 } }; // O shape
            pieces[2] = new Point[] { new Point { x = 0, y = 0 }, new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 2, y = 0 } }; // T shape
            pieces[3] = new Point[] { new Point { x = 0, y = 1 }, new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 2, y = 0 } }; // S shape
            pieces[4] = new Point[] { new Point { x = 0, y = 0 }, new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 2, y = 1 } }; // Z shape
            pieces[5] = new Point[] { new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 1, y = 2 }, new Point { x = 0, y = 2 } }; // J shape
            pieces[6] = new Point[] { new Point { x = 0, y = 0 }, new Point { x = 0, y = 1 }, new Point { x = 0, y = 2 }, new Point { x = 1, y = 2 } }; // L shape

            //fill each shape into 4x4 matrix and assign filled cell to 1 (default the unfilled cells are zero)
            for (int i = 0; i < pieces.Length; i++)
            {
                int[,] block = new int[4, 4]; //signle 4x4 block

                foreach (var cell in pieces[i])
                {
                    block[cell.y, cell.x] = 1;
                }
                blocks[i] = block; // each block represents a different shape
            }
        }

        public Piece(Bricks shape)
        {
            pieceStore = new int[4, 4];
            int[,] block = GetBlock(shape);

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    pieceStore[row, col] = block[row, col];
                }
            }
        }

        private int[,] GetBlock(Bricks shape)
        {
            switch ((int)shape)
            {
                case 0:
                    return blocks[0];

                case 1:
                    return blocks[1];

                case 2:
                    return blocks[2];

                case 3:
                    return blocks[3];

                case 4:
                    return blocks[4];

                case 5:
                    return blocks[5];

                case 6:
                    return blocks[6];

                default: throw new Exception();
            }
        }

        public ConsoleColor GetShapeColor(Bricks shape)
        {
            switch ((int)shape)
            {
                case 0:
                    return ConsoleColor.Blue;

                case 1:
                    return ConsoleColor.Green;

                case 2:
                    return ConsoleColor.Magenta;

                case 3:
                    return ConsoleColor.White;

                case 4:
                    return ConsoleColor.Red;

                case 5:
                    return ConsoleColor.Yellow;

                case 6:
                    return ConsoleColor.Cyan;

                default: throw new Exception();
            }
        }

        // rotate clockwise
        // create a new arrary to store all 16 new coordinates and then restore back to the pieceStore
        public void Rrotate()
        {
            int[,] pieceRotateArr = new int[4, 4];

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    pieceRotateArr[col, 3 - row] = pieceStore[row, col];
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    pieceStore[i, j] = pieceRotateArr[i, j];
                }
            }
        }

        // rotate counterclockwise
        // create a new arrary to store all 16 new coordinates and then restore back to the pieceStore array.
        public void Lrotate()
        {
            int[,] pieceRotateArr = new int[4, 4];

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    pieceRotateArr[3 - col, row] = pieceStore[row, col];
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    pieceStore[i, j] = pieceRotateArr[i, j];
                }
            }
        }
    }
}