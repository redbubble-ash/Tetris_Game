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
            board.PlaceBlock();
            displayBoard = new Display();
            displayBoard.PrintBoad(board);
            SetTimer();
            Console.ReadLine();// instead of readline() use while loop with key to control left and right
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