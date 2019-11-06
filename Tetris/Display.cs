using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris_Game
{
    internal class Display
    {
        public void PrintBoad(Board board)
        {
            Console.CursorVisible = false;
            for (int y = 0; y < Board.boardHeight; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("*");
                for (int x = 0; x < Board.boardWidth; x++)
                {
                    if (board.wholeBoard[y][x].val == 1)
                    {
                        Console.BackgroundColor = board.wholeBoard[y][x].color;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                    else if (x >= board.fallingPoint.x && x < (board.fallingPoint.x + 4) && y >= board.fallingPoint.y && y < (board.fallingPoint.y + 4))
                    {
                        if (board.newPiece.pieceStore[y - board.fallingPoint.y, x - board.fallingPoint.x] == 1)
                        {
                            Console.BackgroundColor = board.newPiece.GetShapeColor(board.currentBlock);
                            Console.Write("  ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("  ");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                }
                Console.SetCursorPosition(Board.boardWidth*2+1, y);
                Console.Write("*");
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, Board.boardHeight);
            Console.WriteLine("##########################################");
        }

        public void PrintScoreBoard()
        {

        }

        public void PrintBlock(int[,] block)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (block[x, y] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }
    }
}