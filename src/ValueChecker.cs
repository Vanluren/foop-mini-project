using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace foop_mini_project.src
{
    public class ValueChecker
    {
        public List<DiceCombination> combinations;
        public DiceCombination GetCombo(int index)
        {
            return combinations[index - 1];
        }
        public ValueChecker()
        {
            combinations = new List<DiceCombination>();
        }
        public void PairOfChecker(List<Dice> dices)
        {
            for (int i = 0; i <= 6; i++)
            {
                var amount = AmountOfOneKindChecker(dices, i);
                if (amount > 0 && amount % 2 == 0)
                {
                    int amountOfPairs = amount / 2;
                    combinations.Add(new DiceCombination($"Pairs of {i}s: ", amountOfPairs, 2 * i));
                };
            }
        }
        public void ThreeOfAKindChecker(List<Dice> dices)
        {
            for (int i = 0; i <= 6; i++)
            {
                var amount = AmountOfOneKindChecker(dices, i);
                if (amount > 2 && amount % 3 == 0)
                {
                    int amountOfPairs = amount / 3;
                    combinations.Add(new DiceCombination($"Three of {i}s: ", amountOfPairs, 3 * i));
                };
            }
        }
        public void FourOfAKindChecker(List<Dice> dices)
        {
            for (int i = 0; i <= 6; i++)
            {
                var amount = AmountOfOneKindChecker(dices, i);
                if (amount > 3 && amount % 4 == 0)
                {
                    int amountOfPairs = amount / 4;
                    combinations.Add(new DiceCombination($"Four of {i}s: ", amountOfPairs, 4 * i));
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

            combinations.Add(new DiceCombination($"Small straight: ", (check == 5) ? 1 : 0, 15));
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

            combinations.Add(new DiceCombination($"Large straight: ", (check == 5) ? 1 : 0, 16));
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
            ClearChecker();

            if (lockUpper == false)
            {
                PairOfChecker(dices);
                ThreeOfAKindChecker(dices);
                FourOfAKindChecker(dices);
            }
            else
            {
                SmallStraightChecker(dices);
                LargeStraightChecker(dices);
                FullHouseChecker(dices);
            }


            string toPrint = "";
            var myEnumerator = combinations.GetEnumerator();
            int index = 1;
            foreach (DiceCombination combo in combinations)
            {
                toPrint += $"{index}.{combo.comboName} {combo.score} \n";
                index++;
            }
            return toPrint;
        }
    }
}
