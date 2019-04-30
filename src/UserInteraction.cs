using System;

namespace foop_mini_project.src
{
    public class UserInteraction : UserInput
    {

        public string UserStartGame()
        {
            return GetUserInput("Do you want to start the game(y/n)? \n");
        }
        public string UserRollOrHold()
        {
            return GetUserInput(
                                "Do you want to end the turn('end'/'e'), \n" +
                                "hold some dices('hold'/'h'), \n" +
                                "or roll the dices again('roll/'r')? \n" +
                                "----------------------------" +
                                "\n"
                            );
        }
        public string UserHoldDices()
        {
            return GetUserInput("Which dice would you like to hold(comma seperated list)? \n");
        }
        public string CheckRollAgain()
        {
            return GetUserInput("Should i roll the dice again?(y/n) \n");
        }
        public void StartNewTurn()
        {
            Console.Clear();
            Console.WriteLine("New turn started!");
        }
    }
}
