using System;

namespace Tetris_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Piece printShapes = new Piece();
            Console.WriteLine("7 unique shapes are");
            printShapes.listOfBlocks();

        }


    }
}
