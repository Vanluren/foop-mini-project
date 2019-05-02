using System;
using System.Collections.Generic;

namespace foop_mini_project.src
{
    /// <summary>
    /// Score board-class that represents the scoreboard in the game.
    /// </summary>
    public class ScoreBoard
    {
        public bool upperLocked;
        public bool lowerLocked;
        private readonly List<Score> _upper;
        private readonly List<Score> _lower;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:foop_mini_project.src.ScoreBoard"/> class.
        /// </summary>
        public ScoreBoard()
        {
            _upper = new List<Score>();
            _lower = new List<Score>();
            upperLocked = false;
            lowerLocked = true;
        }

        /// <summary>
        /// Saves a score to the scoreboard.
        /// </summary>
        /// <param name="turnNumber">The current turn number</param>
        /// <param name="combo">Combo. The combo chosen to save by the user.</param>
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
        /// <summary>
        /// Checks for upper bonus.
        /// </summary>
        /// <returns><c>true</c>, if for upper bonus was checked, <c>false</c> otherwise.</returns>
        private bool CheckForUpperBonus()
        {
            return (CalcTotalScore() >= 63);
        }

        /// <summary>
        /// Displaies the given section.
        /// </summary>
        /// <returns>The section.</returns>
        /// <param name="section">Section.</param>
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

        /// <summary>
        /// Calculates the total score.
        /// </summary>
        /// <returns>The total score.</returns>
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

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:foop_mini_project.src.ScoreBoard"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:foop_mini_project.src.ScoreBoard"/>.</returns>
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
