using System.Collections.Generic;
namespace foop_mini_project.src
{
    /// <summary>
    /// Value checker. Checks the values the rolls have made, 
    /// against the yatzy rules
    /// </summary>
    public class ValueChecker
    {
        bool hasUsedChance;
        public List<DiceCombination> combinations;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:foop_mini_project.src.ValueChecker"/> class.
        /// </summary>
        public ValueChecker()
        {
            combinations = new List<DiceCombination>();
        }

        /// <summary>
        /// Clears the checker.
        /// </summary>
        private void ClearComboList()
        {
            combinations.Clear();
        }

        /// <summary>
        /// Gets the combo from the saved values.
        /// </summary>
        /// <returns>The combo.</returns>
        /// <param name="index">Index.</param>
        public DiceCombination GetComboFromCombolist(int index)
        {
            hasUsedChance |= combinations[index - 1].comboName == "CHANCE!";
            return combinations[index - 1];
        }

        /// <summary>
        /// Makes a possible combos list.
        /// </summary>
        /// <returns>The combo list.</returns>
        /// <param name="dices">Dices.</param>
        /// <param name="lockUpper">If set to <c>true</c> lock upper.</param>
        public string PossibleComboList(List<Dice> dices, bool lockUpper = false)
        {
            string toPrint = "";
            int index = 1;
            ClearComboList();

            if (lockUpper == false)
            {
                ChanceChecker(dices);
                int score = 0;
                for (int i = 1; i <= 6; i++)
                {
                    var amount = AmountOfOneKindChecker(dices, i);
                    if (amount > 0)
                    {
                        score = amount * i;
                        combinations.Add(new DiceCombination($"{amount}x{i}!", amount, score));
                    }
                }
            }
            else
            {
                ChanceChecker(dices);
                AmountOfPairsChecker(dices, 2);
                AmountOfPairsChecker(dices, 3);
                XOfAKindChecker(dices, 3, "Three");
                XOfAKindChecker(dices, 4, "Four");
                SmallStraightChecker(dices);
                LargeStraightChecker(dices);
                FullHouseChecker(dices);
                XOfAKindChecker(dices, 6, "YATZY!!: ");
            }
            foreach (DiceCombination combo in combinations)
            {
                toPrint += $"{index}.{combo.comboName}: {combo.score} \n";
                index++;
            }
            return toPrint;
        }

        /// <summary>
        /// Checks how many dices have the same eyes
        /// </summary>
        /// <returns>Amount of dice with same eyes</returns>
        /// <param name="dices">Dices.</param>
        /// <param name="eyesToLookFor">Eyes to look for.</param>
        private int AmountOfOneKindChecker(List<Dice> dices, int eyesToLookFor)
        {
            int amountOfThisKind = 0;
            foreach (Dice dice in dices)
            {
                if (dice.CurrentEyes == eyesToLookFor)
                {
                    amountOfThisKind++;
                }
            }
            return amountOfThisKind;
        }

        /// <summary>
        /// Check for x dices of dice-eyes.
        /// </summary>
        /// <param name="dices">Dices.</param>
        /// <param name="kind">Kind.</param>
        /// <param name="wording">Wording.</param>
        private void XOfAKindChecker(List<Dice> dices, int kind, string wording = null)
        {
            string wordingToPring = wording == null ? $"{kind}x" : $"{wording} ";
            for (int i = 0; i <= 6; i++)
            {
                var amount = AmountOfOneKindChecker(dices, i);
                if (amount >= kind)
                {
                    int amountOfPairs = amount / kind;
                    combinations.Add(new DiceCombination($"{wordingToPring}{i}s", amountOfPairs, kind * i));
                };
            }
        }

        /// <summary>
        /// Amounts of pairs checker. Checks how many pairs there are.
        /// </summary>
        /// <param name="dices">Dices.</param>
        /// <param name="amountOfPairs">Amount of pairs.</param>
        private void AmountOfPairsChecker(List<Dice> dices, int amountOfPairs)
        {
            int pairs = 0;
            int score = 0;
            for (int i = 1; i <= 6; i++)
            {
                if (AmountOfOneKindChecker(dices, i) >= 2)
                {
                    pairs++;
                    score += 2 * i;
                }
            }
            if (pairs == amountOfPairs && amountOfPairs == 2)
            {
                combinations.Add(new DiceCombination($"Two pairs", pairs, score > 10 ? 10 : score));
            }
            else if (pairs == amountOfPairs && amountOfPairs == 3)
            {
                combinations.Add(new DiceCombination($"Two pairs", pairs, score > 30 ? 30 : score));
            }
        }

        /// <summary>
        /// Check for a small straight
        /// </summary>
        /// <param name="dices">Dices.</param>
        private void SmallStraightChecker(List<Dice> dices)
        {
            int check = 0;

            for (int i = 1; i <= 5; i++)
            {
                if (AmountOfOneKindChecker(dices, i) >= 1)
                {
                    check++;
                }
            }

            combinations.Add(new DiceCombination($"Small straight", (check == 5) ? 1 : 0, 15));
        }

        /// <summary>
        /// Check for a large straight
        /// </summary>
        /// <param name="dices">Dices.</param>
        private void LargeStraightChecker(List<Dice> dices)
        {
            int check = 0;

            for (int i = 2; i <= 6; i++)
            {
                if (AmountOfOneKindChecker(dices, i) >= 1)
                {
                    check++;
                }
            }

            combinations.Add(new DiceCombination($"Large straight", (check == 5) ? 1 : 0, 16));
        }

        /// <summary>
        /// Check for a full house combo
        /// </summary>
        /// <param name="dices">Dices.</param>
        private void FullHouseChecker(List<Dice> dices)
        {
            bool check = false;
            int score = 0;
            bool aPair = false;
            bool threeOfAKind = false;

            for (int i = 1; i <= 6; i++)
            {
                if (!threeOfAKind && AmountOfOneKindChecker(dices, i) == 3)
                {
                    threeOfAKind = true;
                    score += 3 * i;
                }
                else if (!aPair && AmountOfOneKindChecker(dices, i) == 2)
                {
                    aPair = true;
                    score += 2 * i;
                }
                check |= (aPair && threeOfAKind);
            }

            combinations.Add(new DiceCombination($"Full House: ", check ? 1 : 0, score));
        }

        /// <summary>
        /// Check for a chance!
        /// </summary>
        /// <param name="dices">Dices.</param>
        private void ChanceChecker(List<Dice> dices)
        {
            int score = 0;
            if (hasUsedChance == false)
            {
                foreach (Dice dice in dices)
                {
                    score += dice.CurrentEyes;
                }
                combinations.Add(new DiceCombination($"CHANCE!", 1, score));
            }
        }
    }
}
