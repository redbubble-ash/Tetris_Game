using System;
using System.Text;

namespace Tetris_Game

{
    public enum Bricks { I, O, T, S, Z, J, L }
    class Piece
    {

        static Point[][] pieces;  // jagged arrays.
        static int[][,] blocks = new int[7][,]; //arrary of 7 2d arrarys

        static Piece()
        {

            pieces = new Point[7][];
            pieces[0] = new Point[] { new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 1, y = 2 }, new Point { x = 1, y = 3 } }; // I shape
            pieces[1] = new Point[] { new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 2, y = 0 }, new Point { x = 2, y = 1 } }; // O shape
            pieces[2] = new Point[] { new Point { x = 0, y = 0 }, new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 2, y = 0 } }; // T shape
            pieces[3] = new Point[] { new Point { x = 0, y = 1 }, new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 2, y = 0 } }; // S shape
            pieces[4] = new Point[] { new Point { x = 0, y = 0 }, new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 2, y = 1 } }; // Z shape
            pieces[5] = new Point[] { new Point { x = 0, y = 0 }, new Point { x = 1, y = 0 }, new Point { x = 1, y = 1 }, new Point { x = 1, y = 2 } }; // J shape
            pieces[6] = new Point[] { new Point { x = 0, y = 0 }, new Point { x = 0, y = 1 }, new Point { x = 0, y = 2 }, new Point { x = 1, y = 2 } }; // L shape

            //fill each shape into 4x4 matrix and assign filled cell to 1 (default the unfilled cells are zero)
            for (int i = 0; i < pieces.Length; i++)
            {
                int[,] block = new int[4, 4]; //signle 4x4 block

                foreach (var cell in pieces[i])
                {
                    block[cell.x, cell.y] = 1;
                }
                blocks[i] = block; // each block represents a different shape


            }
        }

        public int[,] GetBlock(Bricks shape)
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
