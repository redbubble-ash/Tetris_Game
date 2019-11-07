using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Tetris_Game
{
    class Scoreboard
    {
        public int Score { get; private set; }
        public int Levels { get; private set; }

        public Scoreboard(Board board)
        {
           
        }

        public int UpdateScore(int level, Board board)
        {
            int scoreEachRow = 40 ;
            Score = scoreEachRow * board.removedRows;
            return Score;
        }

        public int UpdateLevel(Board board)
        {
            if (Score < 40) Levels = 1;
            else if (Score >= 40 && Score < 120) Levels = 2;
            else if (Score >= 120 && Score < 200) Levels = 3;
            else if (Score >= 200) Levels = 4;
            return Levels;
        }

        public double UpdateInterval(int level)
        {
            switch (level)
            {
                case 1:
                    return 500;
                case 2:
                    return 350;
                case 3:
                    return 300;
                case 4:
                    return 250;
                default:
                    throw new Exception();
            }
        }
    }
}
