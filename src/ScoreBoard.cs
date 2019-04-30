using System;
using System.Collections.Generic;

namespace foop_mini_project.src
{
    public class ScoreBoard
    {
        private Dictionary<int, int> _upper = new Dictionary<int, int>();
        private Dictionary<int, int> _lower = new Dictionary<int, int>();

        public void SaveScore(int turnNumber, List<Dice> dices)
        {
            var score = CalcScore(dices);
            if (turnNumber <= 6 && turnNumber > 0)
            {
                _upper.Add(turnNumber, score);
                Console.WriteLine(turnNumber + ": " + dices.ToString());
            }
            else
            {
                _lower.Add(turnNumber, score);
            }
        }
        private int CalcScore(List<Dice> dices)
        {
            int score = 0;
            foreach (Dice dice in dices)
            {
                score += dice.CurrentEyes;
            }
            return score;
        }
        private bool CheckForUpperBonus()
        {
            int bonus = 0;
            foreach (int score in _upper.Values)
            {
                bonus += score;
            }

            if (bonus >= 63) return true;
            return false;
        }
        public override string ToString()
        {
            string scoreBoard = "----------------------------" +
                                "\n" +
                                "\t" + "SCORE BOARD: " + "\t" +
                                "\n" +
                                "----------------------------";
            Console.WriteLine(scoreBoard);
            return scoreBoard;
        }
    }
}
