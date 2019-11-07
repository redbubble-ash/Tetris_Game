using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris_Game
{
    internal class Display
    {
        public void PrintBoad(Scoreboard scoreBoard, Board board)
        {
            Console.CursorVisible = false;
            for (int y =0 ; y < Board.boardHeight; y++)
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
                        if (board.currentPiece.pieceStore[y - board.fallingPoint.y, x - board.fallingPoint.x] == 1)
                        {
                            Console.BackgroundColor = board.currentPiece.GetShapeColor(board.currentBlock);
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

        public void PrintScoreBoard(Scoreboard scoreBoard, Board board)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(50, 1);
            Console.WriteLine("#############################");
            Console.Title = "Timer";
            string title1 = @"             ___     ___";
            string title2 = @"       |\ | |__  \_/  |";
            string title3 = @"       | \| |___ / \  |";
            Console.SetCursorPosition(50,2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(title1, Console.ForegroundColor);
            Console.SetCursorPosition(50, 3);
            Console.WriteLine(title2, Console.ForegroundColor);
            Console.SetCursorPosition(50, 4);
            Console.WriteLine(title3, Console.ForegroundColor);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            PrintBlock(board);
            Console.ResetColor();
            Console.Title = "Score";
            string score1 = @"     __   __   __   __   ___";
            string score2 = @"    /__` /  ` /  \ |__) |__";
            string score3 = @"    .__/ \__, \__/ |  \ |___";
            Console.SetCursorPosition(50, 10);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(score1, Console.ForegroundColor);
            Console.SetCursorPosition(50, 11);
            Console.WriteLine(score2, Console.ForegroundColor);
            Console.SetCursorPosition(50, 12);
            Console.WriteLine(score3, Console.ForegroundColor);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(50, 15);
            int currentLevel = scoreBoard.UpdateLevel(board);
            Console.WriteLine($"               {scoreBoard.UpdateScore(currentLevel, board)}");
            Console.ResetColor();
            Console.Title = "Level";
            string level1 = @"         ___       ___   ";
            string level2 = @"    |    |__  \  / |__  | ";
            string level3 = @"    |___ |___  \/  |___ |___";
            Console.SetCursorPosition(50, 17);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(level1, Console.ForegroundColor);
            Console.SetCursorPosition(50, 18);
            Console.WriteLine(level2, Console.ForegroundColor);
            Console.SetCursorPosition(50, 19);
            Console.WriteLine(level3, Console.ForegroundColor);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(50, 22);
            Console.WriteLine($"               {scoreBoard.UpdateLevel(board)}");
            Console.ResetColor();
            Console.Title = "Lines";
            string lines1 = @"                  ___  __";
            string lines2 = @"     |    | |\ | |__  /__` ";
            string lines3 = @"     |___ | | \| |___ .__/ ";
            Console.SetCursorPosition(50, 23);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(lines1, Console.ForegroundColor);
            Console.SetCursorPosition(50, 24);
            Console.WriteLine(lines2, Console.ForegroundColor);
            Console.SetCursorPosition(50, 25);
            Console.WriteLine(lines3, Console.ForegroundColor);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(50, 28);
            Console.WriteLine($"               {board.removedRows}");
            Console.ResetColor();
            Console.SetCursorPosition(50, 30);
            Console.WriteLine("#############################");
        }

        public void PrintBlock(Board board)
        {
            int n = 6;
            for (int x = 0; x < 4; x++)
            {
                Console.SetCursorPosition(62, n);
                n++;
                for (int y = 0; y < 4; y++)
                {
                    if (board.nextPiece.pieceStore[x, y] == 1)
                    {
                        Console.BackgroundColor = board.nextPiece.GetShapeColor(board.nextBlock);
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
        }
    }
}