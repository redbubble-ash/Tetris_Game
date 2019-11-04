using System;
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
            board = new Board();
            board.PlaceBlock(Bricks.S);
            displayBoard = new Display();
            displayBoard.PrintBoad(board);
            SetTimer();
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += Tick;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void Tick(Object source, ElapsedEventArgs e)
        {
            board.fallingPoint.y++;
            displayBoard.PrintBoad(board);
        }
    }
}