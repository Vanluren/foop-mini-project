using System;
using System.Collections.Generic;

namespace foop_mini_project.src
{
    /// <summary>
    /// Dice cup.
    /// </summary>
    public class DiceCup
    {
        public List<Dice> rolledDices = new List<Dice>();
        public List<Dice> heldDices = new List<Dice>();
        public int amountOfRolls;
        public bool useBiased;
        int _biasedDiceKicker = 2;
        int _numberOfDices = 6;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:foop_mini_project.src.DiceCup"/> class.
        /// </summary>
        /// <param name="shouldUseBiasedDice">If set to <c>true</c> should use biased dices.</param>
        /// <param name="rollsPerTurn">Rolls per turn.</param>
        public DiceCup(bool shouldUseBiasedDice = false, int rollsPerTurn = 3)
        {
            useBiased = shouldUseBiasedDice;
            amountOfRolls = rollsPerTurn;
            for (var i = 0; i < _numberOfDices; i++)
            {
                if (useBiased)
                {
                    BiasedDice biased = new BiasedDice();
                    biased.SetKicker(_biasedDiceKicker);
                    rolledDices.Add(new BiasedDice());
                }
                else
                {
                    rolledDices.Add(new Dice());
                }
            }
        }
        /// <summary>
        /// Throws the dice in the cup.
        /// </summary>
        public void ThrowDice()
        {
            amountOfRolls--;
            for (var i = 0; i < _numberOfDices; i++)
            {
                rolledDices[i].RollDice();
            }
            Console.WriteLine(ToString());
        }
        /// <summary>
        /// Rethrow dices in the dicecup. Print action.
        /// </summary>
        public void ReThrowDices()
        {
            if (amountOfRolls > 0)
            {
                Console.WriteLine("Rolling Again...");
                ThrowDice();
            }
        }
        /// <summary>
        /// Holds the chosen dices, based on the users.
        /// </summary>
        /// <param name="userInput">Input from the user.</param>
        public void HoldDices(string userInput)
        {
            string[] indexFromInput = userInput.Split(",");
            for (int i = 0; i < indexFromInput.Length; i++)
            {
                int indexOfDiceToHold = int.Parse(indexFromInput[i]) - 1;
                Dice dice = rolledDices[indexOfDiceToHold];
                dice.HoldDice(true);
                heldDices.Insert(i, dice);
            }

        }
        /// <summary>
        /// Removes the held dice property from the dice in the cup.
        /// </summary>
        public void RemoveHeldDice()
        {
            foreach (Dice dice in heldDices)
            {
                dice.HoldDice(false);
            }
            heldDices.RemoveAll(item => item != null);
        }
        /// <summary>
        /// Resets the amount of rolls to the initial value.
        /// </summary>
        /// <param name="amount">Amount.</param>
        private void ResetAmountOfRolls(int amount)
        {
            System.Console.WriteLine(amount);
            amountOfRolls = amount;
        }
        /// <summary>
        /// Resets the dice cup.
        /// </summary>
        /// <param name="amount">Amount.</param>
        public void ResetDiceCup(int amount)
        {
            ResetAmountOfRolls(amount);
            RemoveHeldDice();
        }
        /// <summary>
        /// Changes the biased dice, based on the int from ther users input.
        /// </summary>
        /// <param name="change">Change.</param>
        public void ChangeBiasedDice(int change)
        {
            foreach (BiasedDice dice in rolledDices)
            {
                dice.SetKicker(change);
            }
        }
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:foop_mini_project.src.DiceCup"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:foop_mini_project.src.DiceCup"/>.</returns>
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
                    "Your Roll: " +
                    stringOfEyes +
                    "\n" +
                    "Rolls left:  " +
                    amountOfRolls +
                    "\n" +
                    "held dices: " +
                    heldDicesStr +
                    "\n" +
                    "----------------------------";
        }
    }
}
