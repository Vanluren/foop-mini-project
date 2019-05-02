using System;
using System.Text.RegularExpressions;

namespace foop_mini_project.src
{
    public class UserInteraction : UserInput
    {

        public string UserStartGame()
        {
            return GetUserInput("Do you want to start the game(y/n)? \n");
        }
        public string UseFairOrBiased()
        {
            return GetUserInput("Do you want to: \n" +
                                " - Use a fair dice?('fair') \n" +
                                " - Use a biased dice?('biased') \n" +
                                "\n");
        }
        public string HowManyRolls()
        {
            return GetUserInput("How many Rolls Per turn? \n");
        }
        public string ChangeBiasedDice()
        {
            return GetUserInput("What should your dice eyes equal?\n");
        }
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
        public string UserHoldDices()
        {
            return GetUserInput("Which dice would you like to hold? (ex. 1,2,3) \n");
        }
        public string CheckRollAgain()
        {
            return GetUserInput("Should i roll the dice again?('y'/'n') \n");
        }
        public string EndTurnAndSaveCombo()
        {
            return GetUserInput("Should i Save a combo?(Combo No./'n') \n");
        }
        public void StartNewTurn()
        {
            Console.Clear();
            Console.WriteLine("New turn started!");
        }

        public bool IsAnswerNo(string input)
        {
            return Regex.IsMatch(input, @"^(([nN])([oO])*(\s)*)$");
        }
        public bool IsAnswerYes(string input)
        {
            return Regex.IsMatch(input, @"^(?:(y|Y)(([eE][sS]))*\b(\s)*)$");
        }
    }
}
