using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace foop_mini_project.src
{
    public class ScoreBoard
    {
        private bool hasUsedStrike;
        private bool hasUseChance;
        private ValueChecker valueChecker;
        public bool upperLocked;
        public bool lowerLocked;
        private List<Score> _upper;
        private List<Score> _lower;

        public ScoreBoard()
        {
            valueChecker = new ValueChecker();
            _upper = new List<Score>();
            _lower = new List<Score>();
            upperLocked = false;
            lowerLocked = true;
        }
        public void SaveScore(int turnNumber, DiceCombination combo = null, string userInput = null)
        {
            Score score;
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
            else if (turnNumber == 6 && CheckForUpperBonus())
            {
                _upper.Add(new Score("BONUS!", 64));
            }
            else
            {
                upperLocked = true;
                lowerLocked = false;
                _lower.Add(score);
            }

        }
        private Score CalcScore(List<Dice> dices)
        {
            return new Score();
        }
        private bool CheckForUpperBonus()
        {
            int bonus = 0;
            foreach (Score score in _upper)
            {
                bonus += score.score;
            }

            if (bonus >= 63) return true;
            return false;
        }

        public string DisplaySection(List<Score> section)
        {
            string toDisplay = "";

            if (section.Count > 0)
            {
                toDisplay += "\n"
                             + String.Format("{0,-5} | {1,-12} | {2,5}", "Turn", "Combo", "Score")
                             + "\n";

                int count = 1;
                foreach (Score score in section)
                {
                    toDisplay += String.Format("{0,-5} | {1,-12} | {2,5}", count, score.scoreName, score.score) + "\n";
                    count++;
                }
            }

            return toDisplay;
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
