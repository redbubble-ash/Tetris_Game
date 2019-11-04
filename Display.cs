using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris_Game
{
    internal class Display
    {
        public void PrintBlock(int[,] block)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    //Console.Write(block[x, y] + " ");
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

        public void PrintBoad(Board board)
        {
            for (int y = 0; y < board.wholeBoard.GetLength(0); y++)
            {
                Console.Write("|");
                for (int x = 0; x < board.wholeBoard.GetLength(1); x++)
                {
                    if (board.wholeBoard[y, x] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                    if (x >= board.fallingPoint.x && x < (board.fallingPoint.x + 4) && y >= board.fallingPoint.y && y < (board.fallingPoint.y + 4))
                    {
                        Piece newBrick = new Piece();
                        int[,] newBrickCoordinates = newBrick.GetBlock(board.currentBlock);
                        if (newBrickCoordinates[y - board.fallingPoint.y, x - board.fallingPoint.x] == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
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
                Console.WriteLine();
            }
            Console.WriteLine("________________________________________");
        }

        //public void ListOfBlocks()
        //{
        //    foreach (var block in blocks)
        //    {
        //        for (int x = 0; x < 4; x++)
        //        {
        //            for (int y = 0; y < 4; y++)
        //            {
        //                //Console.Write(block[x, y] + " ");
        //                if (block[y, x] == 1)
        //                {
        //                    Console.BackgroundColor = ConsoleColor.Yellow;
        //                    Console.Write("  ");
        //                    Console.ResetColor();
        //                }
        //                else
        //                {
        //                    Console.BackgroundColor = ConsoleColor.Gray;
        //                    Console.Write("  ");
        //                    Console.ResetColor();
        //                }
        //            }
        //            Console.WriteLine();

        //        }
        //    }
        //}
    }
}