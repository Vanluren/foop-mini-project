using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace foop_mini_project.src
{
    public class ValueChecker
    {
        OrderedDictionary combinations;
        public ValueChecker()
        {
            combinations = new OrderedDictionary();
        }
        public void PairOfChecker(List<Dice> dices)
        {
            for (int i = 0; i <= 6; i++)
            {
                var amount = AmountOfOneKindChecker(dices, i);
                if (amount > 0 && amount % 2 == 0)
                {
                    int amountOfPairs = amount / 2;
                    combinations.Add($"Pairs of {i}s: ", amountOfPairs);
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
                    combinations.Add($"Three of {i}s: ", amountOfPairs);
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
                    combinations.Add($"Four of {i}s: ", amountOfPairs);
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

            combinations.Add($"Small straight: ", (check == 5));
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

            combinations.Add($"Large straight: ", (check == 5));
        }

        public void FullHouseChecker(List<Dice> dices)
        {
            bool check = false;

            bool aPair = false;
            bool threeOfAKind = false;

            for (int i = 1; i <= 6; i++)
            {
                if (!threeOfAKind && AmountOfOneKindChecker(dices, i) == 3)
                {
                    threeOfAKind = true;
                }
                else if (!aPair && AmountOfOneKindChecker(dices, i) == 2)
                {
                    aPair = true;
                }
                if (aPair && threeOfAKind)
                {
                    check = true;
                }
            }

            combinations.Add($"Full House: ", check);
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
        public string CustomToString(List<Dice> dices)
        {
            PairOfChecker(dices);
            ThreeOfAKindChecker(dices);
            FourOfAKindChecker(dices);
            SmallStraightChecker(dices);
            LargeStraightChecker(dices);
            FullHouseChecker(dices);

            string toPrint = "";
            var myEnumerator = combinations.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                toPrint += $"{myEnumerator.Key} {myEnumerator.Value} \n";
            }
            return toPrint;
        }
    }
}
