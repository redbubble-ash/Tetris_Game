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
            int scoreEachRow = 40 + (level - 1) * 10;
            Score = scoreEachRow * board.removedRows;
            return Score;
        }

        public int UpdateLevel(Board board)
        {
            if (Score < 400) Levels = 1;
            else if (Score == 400 && Levels == 1)
            {
                Levels = 2;
                Score = 0;
            }
            else if (Score == 500 && Levels == 2)
            {
                Levels = 3;
                Score = 0;
            }
            else if (Score == 600 && Levels == 2)
            {
                Levels = 3;
                Score = 0;
            }
            return Levels;
        }

    }
}
