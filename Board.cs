using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris_Game
{
    class Board
    {
        static int[,] wholeBoard = new int[30, 20];
        static int BoardWidth { get; }
        static int BoardHeight { get; }

        public Board()
        {
            for (int row = 0; row < 30; row++)
            {
                for (int col = 0; col < 20; col++)
                {
                    wholeBoard[row, col] = 0;
                }
            }
        }

        // add a piece into the board and add 1 for the filled cells
        public int[,] place(Bricks x)
        {
            Piece newBrick = new Piece();
            int[,] newBrickCoordinate = newBrick.GetBlock(x);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    wholeBoard[i + 8, j] = newBrickCoordinate[i, j];
                }
            }
            return wholeBoard;
        }
        //public void clearRow() { }; //compact the board downwards by clearing any filled rows
        //public int rowWidth(); //the number of filled blocks in the given horizontal row
        //public int columnHeight(); //the height the board is filled in the given column.
        //public int dropHeight(Piece x); //the y value where the origin (lower left corner) of the given piece would come to rest if the piece dropped straight down at the given x



    }
}
