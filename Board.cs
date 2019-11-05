using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris_Game
{
    internal class Board
    {
        public const int boardWidth = 20;
        public const int boardHeight = 30;
        public List<Cell[]> wholeBoard;
        public Piece newPiece; // using this to handle rotation of a piece.

        public enum Key { Left, Right, Up, Down, rLeft, rDown }

        public bool isInGame;
        public int removedRows = 0;

        public Point fallingPoint = new Point(); //track the current falling block's x & y
        public Bricks currentBlock;
        public Cell cellInBoard = new Cell(); //track each cell's value - int & color

        public Board()
        {
            wholeBoard = new List<Cell[]>();
            for (int row = 0; row < boardHeight; row++)
            {
                Cell[] cellArrary;
                cellArrary = new Cell[boardWidth];
                for (int i = 0; i < boardWidth; i++)
                {
                    cellArrary[i] = new Cell { val = 0 };
                }
                wholeBoard.Add(cellArrary);
            }
        }

        // add a piece into the board and give value 1 for the filled cells
        public void PlaceBlock()
        {
            isInGame = true;
            fallingPoint.x = 8;
            fallingPoint.y = 0;
            Random r = new Random();
            Bricks block = (Bricks)r.Next(0, 7);
            currentBlock = block;
        }

        public bool checkMove(int Xmove, int Ymove)
        {
            Piece blockPiece = new Piece(currentBlock);
            int[,] currentBrickCoordinates = blockPiece.GetBlock(currentBlock);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (currentBrickCoordinates[j, i] == 1)
                    {
                        if (j + fallingPoint.y + Ymove >= boardHeight)
                        {
                            return false;
                        }
                        else if (i + fallingPoint.x + Xmove >= boardWidth || i + fallingPoint.x + Xmove < 0)
                        {
                            return false;
                        }
                        else if (wholeBoard[fallingPoint.y + j + Ymove][fallingPoint.x + i + Xmove].val == 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void DropBlock()
        {
            if (!checkMove(0, 1))
            {
                FillBlock();
                PlaceBlock();
                return;
            }

            fallingPoint.y++;
        }

        public void FillBlock()
        {
            Piece blockPiece = new Piece(currentBlock);
            int[,] currentBrickCoordinates = blockPiece.GetBlock(currentBlock);
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (currentBrickCoordinates[row, col] == 1)
                    {
                        wholeBoard[row + fallingPoint.y][col + fallingPoint.x].val = 1;
                    }
                }
            }

            clearRow(); //check if the row has been filled so it can be cleared.
        }

        public void keyPress(Key k)
        {
            if (isInGame)
            {
                switch (k)
                {
                    case Key.Left:
                        if (checkMove(-1, 0)) fallingPoint.x--;
                        break;

                    case Key.Right:
                        if (checkMove(1, 0)) fallingPoint.x++;
                        break;

                    case Key.Down:
                        if (checkMove(0, 1)) fallingPoint.y++;
                        break;

                    default:
                        break;
                }
            }
        }

        //compact the board downwards by clearing any filled rows
        public void clearRow()
        {
            for (int row = 0; row < boardHeight; row++)
            {
                bool isFilled = true;

                for (int col = 0; col < boardWidth; col++)
                {
                    if (wholeBoard[row][col].val == 0)
                    {
                        isFilled = false;
                        break;
                    }
                }
                if (isFilled)
                {
                    wholeBoard.RemoveAt(row);
                    Cell[] cellArrary;
                    cellArrary = new Cell[boardWidth];
                    for (int i = 0; i < boardWidth; i++)
                    {
                        cellArrary[i] = new Cell { val = 0 };
                    }
                    wholeBoard.Insert(0, cellArrary);
                    removedRows++;
                }
            }
        }
    }
}