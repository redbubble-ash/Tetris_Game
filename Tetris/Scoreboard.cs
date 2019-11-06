using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris_Game
{
    class Scoreboard
    {
        public int score;
        public int levels; 

        public int GetScore(int level, Board board)
        {
            int scoreEachRow = 40 + (level - 1) * 10;
            score = scoreEachRow * board.removedRows;
            return score;
        }

        public void GetLevel(Board board)
        {
            if (score < 400) levels = 1;
            else if (score == 400 && levels == 1)
            {
                levels = 2;
                score = 0;
            }
            else if (score == 500 && levels == 2)
            {
                levels = 3;
                score = 0;
            }
            else if (score == 600 && levels == 2)
            {
                levels = 3;
                score = 0;
            }
        }

        public int GetLines(Board board)
        {
            return board.removedRows;
        }

        public Bricks GetNextShape(Board board)
        {
           return board.nextBlock;
        }
    }
}
