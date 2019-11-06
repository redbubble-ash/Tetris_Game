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
            Console.CursorVisible = false;
            Console.SetCursorPosition(50, 1);
            Console.WriteLine("#############################");
            Console.Title = "Timer";
            string title = @"
                                                      ___          ___  __  
                                                       |  |  |\/| |__  |__) 
                                                       |  |  |  | |___ |  \ 
                      
                      
                      
                      
                      
";
            Console.SetCursorPosition(50,2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(title, Console.ForegroundColor);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("            aaaaaaaa");
            Console.ResetColor();
            Console.Title = "Score";
            string score = @"
                                                      __   __   __   __   ___ 
                                                     /__` /  ` /  \ |__) |__  
                                                     .__/ \__, \__/ |  \ |___ 
                         
";
            Console.SetCursorPosition(50, 8);
            Console.WriteLine(score);
            Console.SetCursorPosition(50, 13);
            Console.WriteLine("            aaaaaaaa");
            Console.Title = "Level";
            string level = @"
                                                            ___       ___      
                                                      |    |__  \  / |__  |    
                                                      |___ |___  \/  |___ |___ 
                         
";
            Console.SetCursorPosition(50, 14);
            Console.WriteLine(level);
            Console.SetCursorPosition(50, 20);
            Console.WriteLine("            aaaaaaaa");
            Console.Title = "Lines";
            string lines = @"
                                                                    ___  __  
                                                       |    | |\ | |__  /__` 
                                                       |___ | | \| |___ .__/ 
                      
";
            Console.SetCursorPosition(50, 21);
            Console.WriteLine(lines);
            Console.SetCursorPosition(50, 27);
            Console.WriteLine("            aaaaaaaa");




            //for (int row = 5; row < 10;  row++)
            //{
            //    Console.SetCursorPosition(50, row);
            //    Console.Write("*                           *");
            //}
            //Console.SetCursorPosition(50, 9);
            //Console.WriteLine("*****************************");
            Console.SetCursorPosition(50, 29);
            Console.WriteLine("#############################");
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