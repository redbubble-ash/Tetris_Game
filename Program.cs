﻿using System;
using System.Text;
using System.Timers;

namespace Tetris_Game
{
    internal class Program
    {
        private static System.Timers.Timer aTimer;
        private static Board board;
        private static Display displayBoard;

        private static void Main(string[] args)
        {
            Console.SetWindowSize(50, 50);
            Console.SetBufferSize(80, 80);
            board = new Board();
            board.PlaceBlock();
            displayBoard = new Display();
            displayBoard.PrintBoad(board);
            SetTimer();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                            board.keyPress(Board.Key.Left);
                            break;
                        case ConsoleKey.RightArrow:
                            board.keyPress(Board.Key.Right);
                            break;

                    }

                }
            }
            //.ReadLine();// instead of readline() use while loop with key to control left and right
            aTimer.Stop();
            aTimer.Dispose();
        }

        private static void SetTimer()
        {
            // Create a timer with a one second interval.
            aTimer = new System.Timers.Timer(500);
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += Tick;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void Tick(Object source, ElapsedEventArgs e)
        {
            board.DropBlock();
            displayBoard.PrintBoad(board);
        }
    }
}