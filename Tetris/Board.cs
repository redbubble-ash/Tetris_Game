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
        public Piece currentPiece; // using this to handle rotation of a piece.
        public Piece nextPiece;
        public Bricks currentBlock;
        public Bricks nextBlock;

        public enum Key { Left, Right, Down, rLeft, rRight }

        public bool isInGame = true;
        public int removedRows = 0;
        public Point fallingPoint = new Point(); //track the position ofthe current falling block's x & y on the board
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
            Random r = new Random();
            Bricks block = (Bricks)r.Next(0, 7);
            nextBlock = block;
            nextPiece = new Piece(nextBlock);
        }

        // add one piece of block into the board and give value 1 to the occupied cells
        public void PlaceBlock()
        {
            //entering position on the board
            fallingPoint.x = 8;
            fallingPoint.y = 0;

            //place the exsiting block and randomly generate a new one
            currentPiece = nextPiece;
            currentBlock = nextBlock;
            Random r = new Random();
            Bricks block = (Bricks)r.Next(0, 7);
            nextBlock = block;
            nextPiece = new Piece(nextBlock);
        }

        public bool checkMove(int Xmove, int Ymove) //validate the next move, stop move if the Shape acrssed the boundary of the board
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (currentPiece.pieceStore[j, i] == 1)
                    {
                        if (j + fallingPoint.y + Ymove >= boardHeight) //check the bottom edge of the board
                        {
                            return false;
                        }
                        else if (i + fallingPoint.x + Xmove >= boardWidth || i + fallingPoint.x + Xmove < 0) // check both side edge of the board
                        {
                            return false;
                        }
                        else if (wholeBoard[fallingPoint.y + j + Ymove][fallingPoint.x + i + Xmove].val == 1) // check the exsiting occupied cells in the board
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

        //assign the value and the color of the falling block to the board when stop
        public void FillBlock()
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (currentPiece.pieceStore[row, col] == 1)
                    {
                        wholeBoard[row + fallingPoint.y][col + fallingPoint.x].val = 1; // assign the value of the block to the board: 1 means that cell has being occupied
                        wholeBoard[row + fallingPoint.y][col + fallingPoint.x].color = currentPiece.GetShapeColor(currentBlock); // assign the color of the block to the occupied cell
                    }
                }
            }

            clearRow(); //check if the row has been filled so it can be cleared.
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
                    wholeBoard.RemoveAt(row); // remove the whole filled row
                    Cell[] cellArrary;
                    cellArrary = new Cell[boardWidth]; // generate a new row with the value of 0, which mean the cells are empty
                    for (int i = 0; i < boardWidth; i++)
                    {
                        cellArrary[i] = new Cell { val = 0 };
                    }
                    wholeBoard.Insert(0, cellArrary);
                    removedRows++; // counting the removed rows
                }
            }
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

                    case Key.rLeft:
                        if (checkMove(-1, 0) && checkMove(1, 0) && checkMove(0, 1)) currentPiece.Lrotate();
                        break;

                    case Key.rRight:
                        if (checkMove(-1, 0) && checkMove(1, 0) && checkMove(0, 1)) currentPiece.Rrotate(); ;
                        break;

                    default:
                        break;
                }
            }
        }

        // when block hit the top of the board
        public void isGameOver()
        {
            for (int col = 0; col < boardWidth; col++)
            {
                if (wholeBoard[0][col].val == 1) // check the value of the first row of the board, if any cell is 1, game is over
                {
                    isInGame = false;
                }
            }
        }
    }
}