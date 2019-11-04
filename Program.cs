using System;
using System.Text;

namespace Tetris_Game
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Piece newPiece = new Piece();
            //int[,] newCoordinates = newPiece.GetBlock(Bricks.L);
            //Display newBlock = new Display();
            //newBlock.PrintBlock(newCoordinates);
            Board newBlock = new Board();
            newBlock.PlaceBlock(Bricks.S);
            Display displayBoard = new Display();
            displayBoard.PrintBoad(newBlock);
        }
    }
}