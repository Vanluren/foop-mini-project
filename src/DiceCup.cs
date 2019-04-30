using System;
using System.Collections.Generic;

namespace foop_mini_project.src
{
    public class DiceCup
    {
        UserInteraction userInteraction;
        public int numberOfDices = 6;
        public List<Dice> rolledDices = new List<Dice>();
        public List<Dice> heldDices = new List<Dice>();
        public int amountOfRolls;
        ValueChecker values;

        public DiceCup(int rolls = 3)
        {
            userInteraction = new UserInteraction();
            values = new ValueChecker();
            amountOfRolls = rolls;
            for (var i = 0; i < numberOfDices; i++)
            {
                rolledDices.Add(new Dice());
            }
        }
        public void ThrowDice()
        {
            values.ClearChecker();
            amountOfRolls -= 1;
            for (var i = 0; i < numberOfDices; i++)
            {
                rolledDices[i].RollDice();
            }
            Console.WriteLine(ToString());
        }

        public void ReThrowDices()
        {
            if (amountOfRolls > 0)
            {
                Console.WriteLine("Rolling Again...");
                ThrowDice();
            }
        }
        public void HoldDices(string input)
        {
            string[] indexFromInput = input.Split(",");
            for (int i = 0; i < indexFromInput.Length; i++)
            {
                int indexOfDiceToHold = Int16.Parse(indexFromInput[i]) - 1;
                Dice dice = rolledDices[indexOfDiceToHold];
                dice.HoldDice(true);
                heldDices.Insert(i, dice);
            }

        }
        public void RemoveHeldDice()
        {
            foreach (Dice dice in heldDices)
            {
                dice.HoldDice(false);
            }
            heldDices.RemoveAll(item => item != null);
        }
        public override string ToString()
        {
            string stringOfEyes = "";
            string heldDicesStr = "";
            foreach (Dice dice in rolledDices)
            {
                stringOfEyes += dice.CurrentEyes + ", ";
            }

            foreach (Dice dice in heldDices)
            {
                if (dice == null)
                {
                    heldDicesStr += "";
                }
                else
                {
                    heldDicesStr += dice.CurrentEyes + ",";
                }
            };
            return
                    "----------------------------" +
                    "\n" +
                    "\t" + "DICE CUP: " + "\t" +
                    "\n" +
                    "----------------------------" +
                    "\n" +
                    "You Roll: " +
                    stringOfEyes +
                    "\n" +
                    "Rolls left:  " +
                    amountOfRolls +
                    "\n" +
                    "held dices: " +
                    heldDicesStr +
                    "\n" +
                    "----------------------------" +
                    "\n" +
                    "COMBINATIONS: " +
                    "\n" +
                    values.CustomToString(rolledDices);
        }
    }
}
