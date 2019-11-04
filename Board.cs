using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris_Game
{
    internal class Board
    {
        public int[,] wholeBoard = new int[30, 20];
        public int boardWidth;
        public int boardHeight;
        public Piece newPiece; // using this to handle rotation of a piece.

        public Point fallingPoint = new Point(); //track the current falling block's x & y
        public Bricks currentBlock;

        public Board()
        {
            boardWidth = wholeBoard.GetLength(1);
            boardHeight = wholeBoard.GetLength(0);

            for (int row = 0; row < 30; row++)
            {
                for (int col = 0; col < 20; col++)
                {
                    wholeBoard[row, col] = 0;
                }
            }
        }

        // add a piece into the board and add 1 for the filled cells
        public void PlaceBlock()
        {
            fallingPoint.x = 8;
            fallingPoint.y = 0;
            Random r = new Random();
            Bricks block = (Bricks)r.Next(0, 7);
            currentBlock = block;
        }

        public void DropBlock()
        {
            Piece blockPiece = new Piece();
            int[,] currentBrickCoordinates = blockPiece.GetBlock(currentBlock);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (currentBrickCoordinates[j, i] == 1)
                    {
                        if (j + fallingPoint.y + 1 >= boardHeight)
                        {
                            FillBlock();
                            PlaceBlock();
                            return;
                        }
                        else if (wholeBoard[fallingPoint.y + j + 1, fallingPoint.x + i] == 1)
                        {
                            FillBlock();
                            PlaceBlock();
                            return;
                        }
                    }
                }
            }

            fallingPoint.y++;
        }

        public void FillBlock()
        {
            Piece blockPiece = new Piece();
            int[,] currentBrickCoordinates = blockPiece.GetBlock(currentBlock);
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (currentBrickCoordinates[row, col] == 1)
                    {
                        wholeBoard[row + fallingPoint.y, col + fallingPoint.x] = 1;
                    }
                }
            }

            //check if the row has been filled so it can be cleared.
        }

        //public void clearRow() { }; //compact the board downwards by clearing any filled rows
        //public int rowWidth(); //the number of filled blocks in the given horizontal row
        //public int columnHeight(); //the height the board is filled in the given column.
        //public int dropHeight(Piece x); //the y value where the origin (lower left corner) of the given piece would come to rest if the piece dropped straight down at the given x
    }
}