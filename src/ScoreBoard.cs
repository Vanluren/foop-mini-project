using System;
using System.Collections.Generic;

namespace foop_mini_project.src
{
    public class ScoreBoard
    {
        public bool upperLocked;
        public bool lowerLocked;
        private readonly List<Score> _upper;
        private readonly List<Score> _lower;

        public ScoreBoard()
        {
            _upper = new List<Score>();
            _lower = new List<Score>();
            upperLocked = false;
            lowerLocked = true;
        }
        public void SaveScore(int turnNumber, DiceCombination combo = null)
        {
            Score score;
            bool bonus = CheckForUpperBonus();
            if (combo != null)
            {
                score = new Score(combo.comboName, combo.score);
            }
            else
            {
                score = new Score();
            }
            if (turnNumber <= 6)
            {
                _upper.Add(score);
            }
            else if (turnNumber >= 6 && bonus)
            {
                _upper.Add(new Score("BONUS!", 50));
            }
            else
            {
                upperLocked = true;
                lowerLocked = false;
                _lower.Add(score);
            }

        }
        private bool CheckForUpperBonus()
        {
            return (CalcTotalScore() >= 63);
        }

        private string DisplaySection(List<Score> section)
        {
            string toDisplay = "";

            if (section.Count > 0)
            {
                toDisplay += "\n"
                             + string.Format("{0,-5} | {1,-12} | {2,5}", "Turn", "Combo", "Score")
                             + "\n";

                int count = 1;
                foreach (Score score in section)
                {
                    toDisplay += string.Format("{0,-5} | {1,-12} | {2,5}", count, score.scoreName, score.score) + "\n";
                    count++;
                }
            }

            return toDisplay;
        }

        private int CalcTotalScore()
        {
            int totalScore = 0;
            foreach (Score currentScore in _upper)
            {
                totalScore += currentScore.score;
            }
            foreach (Score currentScore in _lower)
            {
                totalScore += currentScore.score;
            }

            return totalScore;
        }

        public override string ToString()
        {
            string scoreBoard = "";
            if (_upper.Count > 0)
            {
                scoreBoard = "----------------------------" +
                                "\n" +
                                "\t" + "SCORE BOARD: " + "\t" +
                                "\n" +
                                "----------------------------";
                scoreBoard += "\n" +
                                  "Upper:" + "\t" +
                                  DisplaySection(_upper);

                scoreBoard += "----------------------------"
                                + "\n"
                                + "Total score: " + CalcTotalScore();
            }

            if (_lower.Count > 0)
            {
                scoreBoard += "----------------------------" +
                                "\n" +
                                "Lower:" + "\t" +
                                DisplaySection(_lower);
            }
            Console.WriteLine(scoreBoard);
            return scoreBoard;
        }
    }
}
