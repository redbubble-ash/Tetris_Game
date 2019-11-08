using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Tetris_Game
{
    internal class Scoreboard
    {
        public int Score { get; private set; }
        public int Levels { get; private set; }

        public Scoreboard(Board board)
        {
        }

        public int UpdateScore(int level, Board board)
        {
            int scoreEachRow = 40;
            Score = scoreEachRow * board.removedRows;
            GetHighestScore();
            return Score;
        }

        public void GetHighestScore()
        {
            int savedScore;
            try
            {
                string str = File.ReadAllText("score.txt");
                savedScore = Convert.ToInt32(str);
            }
            catch (Exception)
            {
                savedScore = 0;
            }
            if (Score > savedScore) File.WriteAllText("score.txt", Score.ToString());
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