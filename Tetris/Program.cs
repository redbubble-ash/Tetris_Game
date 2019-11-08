﻿using System;
using System.Text;
using System.Timers;
using System.Threading;
using System.Media;
using WMPLib;
using System.IO;

namespace Tetris_Game
{
    internal class Program
    {
        private static System.Timers.Timer aTimer;
        private static Board board;
        private static Scoreboard scoreBoard;
        private static Display displayBoard;
        private static readonly object consoleLock = new object();

        private static void Main(string[] args)
        {
            //background music;
            WMPLib.WindowsMediaPlayer WinMediaPlayer = new WMPLib.WindowsMediaPlayer();
            (WinMediaPlayer.settings as WMPLib.IWMPSettings).setMode("loop", true);
            WinMediaPlayer.URL = "start.mp3";
            WinMediaPlayer.controls.play();

            Console.Title = "Tetris";
            string title = @"
 ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄
▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
 ▀▀▀▀█░█▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀  ▀▀▀▀█░█▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌ ▀▀▀▀█░█▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀
     ▐░▌     ▐░▌               ▐░▌     ▐░▌       ▐░▌     ▐░▌     ▐░▌
     ▐░▌     ▐░█▄▄▄▄▄▄▄▄▄      ▐░▌     ▐░█▄▄▄▄▄▄▄█░▌     ▐░▌     ▐░█▄▄▄▄▄▄▄▄▄
     ▐░▌     ▐░░░░░░░░░░░▌     ▐░▌     ▐░░░░░░░░░░░▌     ▐░▌     ▐░░░░░░░░░░░▌
     ▐░▌     ▐░█▀▀▀▀▀▀▀▀▀      ▐░▌     ▐░█▀▀▀▀█░█▀▀      ▐░▌      ▀▀▀▀▀▀▀▀▀█░▌
     ▐░▌     ▐░▌               ▐░▌     ▐░▌     ▐░▌       ▐░▌               ▐░▌
     ▐░▌     ▐░█▄▄▄▄▄▄▄▄▄      ▐░▌     ▐░▌      ▐░▌  ▄▄▄▄█░█▄▄▄▄  ▄▄▄▄▄▄▄▄▄█░▌
     ▐░▌     ▐░░░░░░░░░░░▌     ▐░▌     ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
      ▀       ▀▀▀▀▀▀▀▀▀▀▀       ▀       ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀

";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(title, Console.ForegroundColor);
            Console.WriteLine();
            Console.WriteLine("                           Awesome    Tetris   Game");
            Console.ResetColor();
            Console.WriteLine("                             Press enter to start");
            int savedScore = 0;
            try
            {
                string str = File.ReadAllText("score.txt");
                savedScore = Convert.ToInt32(str);
            }
            catch (Exception)
            {
                savedScore = 0;
            }
            Console.WriteLine("Higest score is " + savedScore);

            //start the game
            while (true)
            {
                Console.Read();
                Console.Clear();
                WinMediaPlayer.URL = "Tetris.mp3";
                WinMediaPlayer.controls.play();
                Console.SetWindowSize(100, 50);
                Console.SetBufferSize(100, 80);
                board = new Board();
                board.PlaceBlock();
                displayBoard = new Display();
                scoreBoard = new Scoreboard(board);
                displayBoard.PrintBoad(scoreBoard, board);
                scoreBoard.UpdateLevel(board);
                SetTimer();
                while (true)
                {
                    if (!board.isInGame)
                    {
                        WinMediaPlayer.URL = "gameover.mp3";
                        WinMediaPlayer.controls.play();
                        break;
                    };

                    //check if current timer interval matches the level changes
                    //increase the dropping speed when level goes up
                    if (scoreBoard.UpdateInterval(scoreBoard.Levels) != aTimer.Interval)
                    {
                        aTimer.Interval = scoreBoard.UpdateInterval(scoreBoard.Levels);
                    }

                    lock (consoleLock) // two consoleLocks in the main class, the second thread will wait untill the first one is complete
                    {
                        displayBoard.PrintBoad(scoreBoard, board);
                        displayBoard.PrintScoreBoard(scoreBoard, board);
                    }

                    Thread.Sleep(200); //allow main thread delay for 0.2 second
                    while (Console.KeyAvailable)
                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.LeftArrow:
                                board.keyPress(Board.Key.Left);
                                break;

                            case ConsoleKey.RightArrow:
                                board.keyPress(Board.Key.Right);
                                break;

                            case ConsoleKey.DownArrow:
                                board.keyPress(Board.Key.Down);
                                break;

                            case ConsoleKey.A:
                                board.keyPress(Board.Key.rLeft);
                                break;

                            case ConsoleKey.D:
                                board.keyPress(Board.Key.rRight);
                                break;

                            case ConsoleKey.Spacebar:
                                aTimer.Enabled = aTimer.Enabled ? false : true; // Pause key, when aTimer.Enabled is true ==> false (Pause the game)
                                break;

                            case ConsoleKey.Escape:
                                Environment.Exit(0);
                                break;

                            default:
                                break;
                        }
                    }
                }
                //aTimer.Dispose();
            }
        }

        private static void SetTimer()
        {
            // Create a timer with half second interval.
            aTimer = new System.Timers.Timer(500);
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += Tick;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void Tick(Object source, ElapsedEventArgs e)
        {
            board.isGameOver();
            if (board.isInGame)
            {
                board.DropBlock();
            }
            else
            {
                aTimer.Stop();
                lock (consoleLock)
                {
                    displayBoard.PrintGameOver();
                }
            }
        }
    }
}