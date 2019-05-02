using System;
using System.Text.RegularExpressions;
namespace foop_mini_project.src
{
    /// <summary>
    /// User interaction. Handles all the interactions with the user
    /// </summary>
    public class UserInteraction : UserInput
    {

        /// <summary>
        /// Does the user want to start the game?
        /// </summary>
        /// <returns>The start game.</returns>
        public string UserStartGame()
        {
            return GetUserInput("Do you want to start the game(y/n)? \n");
        }

        /// <summary>
        /// Does the user want to use the fair or biased dice?
        /// </summary>
        /// <returns>The fair or biased.</returns>
        public string UseFairOrBiased()
        {
            return GetUserInput("Do you want to: \n" +
                                " - Use a fair dice?('fair') \n" +
                                " - Use a biased dice?('biased') \n" +
                                "\n");
        }

        /// <summary>
        /// How many rolls should be in each turn?
        /// </summary>
        /// <returns>The many rolls.</returns>
        public string HowManyRolls()
        {
            return GetUserInput("How many rolls per turn?(Default: 3) \n");
        }

        /// <summary>
        /// Changes the biased dice.
        /// </summary>
        /// <returns>The biased dice.</returns>
        public string ChangeBiasedDice()
        {
            return GetUserInput("What should your dice eyes equal?\n");
        }

        /// <summary>
        /// Roll again or hold a dice?
        /// </summary>
        /// <returns>The roll or hold.</returns>
        /// <param name="usingBiased">If set to <c>true</c> using biased.</param>
        public string UserRollOrHold(bool usingBiased = false)
        {
            string toPrint = "Do you want to: \n" +
                                " - hold some dices('Hold'/'h'), \n" +
                                " - roll the dices again('Roll/'r')? \n" +
                                " - End the turn, and save a combo('End/'e')? \n";

            if (usingBiased == true)
            {
                toPrint += " - Change the biased dice? ('change') \n";
            }

            return GetUserInput(toPrint + "----------------------------" + "\n");
        }

        /// <summary>
        /// Which dices should be held?
        /// </summary>
        /// <returns>The hold dices.</returns>
        public string UserHoldDices()
        {
            return GetUserInput(
            "Which dice would you like to hold? \n" +
            "(Please input the placenumber of the dice, you would to hold. \n" +
            "Multiple dice, should be inputted in the form of a comma seperated list(ex. 1,2,3). \n" +
            "You may only hold a dice once.) \n"
            );
        }
        /// <summary>
        /// Checks if the user wants to roll again.
        /// </summary>
        /// <returns>The roll again.</returns>
        public string CheckRollAgain()
        {
            return GetUserInput("Should i roll the dice again?('y'/'n') \n");
        }
        /// <summary>
        /// Ends the turn and save a combo.
        /// </summary>
        /// <returns>The turn and save combo.</returns>
        public string EndTurnAndSaveCombo()
        {
            return GetUserInput("Should i Save a combo?(Combo No./'n') \n");
        }

        /// <summary>
        /// Starts the new turn.
        /// </summary>
        public void StartNewTurn()
        {
            Console.Clear();
            Console.WriteLine("New turn started!");
        }

        /// <summary>
        /// Generic method to check if the user inputs the answer no.
        /// </summary>
        /// <returns><c>true</c>, if answer no was ised, <c>false</c> otherwise.</returns>
        /// <param name="input">Input.</param>
        public bool IsAnswerNo(string input)
        {
            return Regex.IsMatch(input, @"^(([nN])([oO])*(\s)*)$");
        }
        /// <summary>
        /// Generic method to check if the user inputs the answer yes.
        /// </summary>
        /// <returns><c>true</c>, if answer yes was ised, <c>false</c> otherwise.</returns>
        /// <param name="input">Input.</param>
        public bool IsAnswerYes(string input)
        {
            return Regex.IsMatch(input, @"^(?:(y|Y)(([eE][sS]))*\b(\s)*)$");
        }
    }
}
