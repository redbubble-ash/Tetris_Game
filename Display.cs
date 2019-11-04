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

        public void PrintBoad(int[,] block)
        {
            for (int x = 0; x < Board.wholeBoard.GetLength(0); x++)
            {
                Console.Write("|");
                for (int y = 0; y < Board.wholeBoard.GetLength(1); y++)
                {
                    if (block[x, y] == 1)
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