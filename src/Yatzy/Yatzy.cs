using System;
namespace foop_mini_project
{
    class Yatzy
    {
        public int numberOfDices = 6;
        public int[] rolledDices = new int[7];
        public void Roll()
        {
            for (var i = 0; i < numberOfDices + 1; i++)
            {
                var newDice = new Dice();
                newDice.Roll();
                rolledDices[i] = newDice.CurrentEyes;
            }
        }
        public int Chance()
        {
            int chanceRes = 0;
            for (var i = 0; 0 < rolledDices.Length; i++)
            {
                chanceRes += rolledDices[i];
            }
            return chanceRes;
        }
        public bool checkValues(int[] values)
        {
            return true;
        }

        public int NumberOf(int eyes)
        {
            int numberOfDices = 0;
            foreach (int diceValue in rolledDices)
            {
                numberOfDices++;
            }
            return numberOfDices;
        }
    }
}