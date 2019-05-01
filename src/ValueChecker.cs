using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace foop_mini_project.src
{
    public class ValueChecker
    {
        bool hasUsedChance = false;
        public List<DiceCombination> combinations;
        public DiceCombination GetCombo(int index)
        {
            if (combinations[index - 1].comboName == "CHANCE!")
            {
                hasUsedChance = true;
            }
            return combinations[index - 1];
        }
        public ValueChecker()
        {
            combinations = new List<DiceCombination>();
        }
        public void XOfAKindChecker(List<Dice> dices, int kind, string wording = null)
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
        public void SmallStraightChecker(List<Dice> dices)
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
        public void LargeStraightChecker(List<Dice> dices)
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

        public void FullHouseChecker(List<Dice> dices)
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
                if (aPair && threeOfAKind)
                {
                    check = true;
                }
            }

            combinations.Add(new DiceCombination($"Full House: ", check ? 1 : 0, score));
        }

        public void ChanceChecker(List<Dice> dices)
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

        public int AmountOfOneKindChecker(List<Dice> dices, int eyesToLookFor)
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

        public void ClearChecker()
        {
            combinations.Clear();
        }
        public string PossibleComboList(List<Dice> dices, bool lockUpper = false)
        {
            string toPrint = "";
            int index = 1;
            ClearChecker();

            if (lockUpper == false)
            {
                ChanceChecker(dices);
                XOfAKindChecker(dices, 2, "Pair of");
                XOfAKindChecker(dices, 3, "Three");
                XOfAKindChecker(dices, 4, "Four");
            }
            else
            {
                ChanceChecker(dices);
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
    }
}
