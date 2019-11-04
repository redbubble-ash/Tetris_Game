using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Tetris_Game
{
    internal class Board
    {
        public int[,] wholeBoard = new int[30, 20];

        public Point fallingPoint = new Point(); //track the current falling block's x & y
        public Bricks currentBlock;
        private static int BoardWidth { get; }
        private static int BoardHeight { get; }

        private static System.Timers.Timer aTimer;

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
        public void PlaceBlock(Bricks block)
        {
            //Piece newBrick = new Piece();
            //int[,] newBrickCoordinate = newBrick.GetBlock(block);
            fallingPoint.x = 8;
            fallingPoint.y = 0;
            currentBlock = block;
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += Tick;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void Tick(Object source, ElapsedEventArgs e)
        {
        }

        private static void MoveBlock()
        {
        }

        //public void clearRow() { }; //compact the board downwards by clearing any filled rows
        //public int rowWidth(); //the number of filled blocks in the given horizontal row
        //public int columnHeight(); //the height the board is filled in the given column.
        //public int dropHeight(Piece x); //the y value where the origin (lower left corner) of the given piece would come to rest if the piece dropped straight down at the given x
    }
}