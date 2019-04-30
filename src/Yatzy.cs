using System;
using System.Collections.Generic;
using foop_mini_project;
using foop_mini_project.src;

namespace foop_mini_project.src
{
    class Yatzy
    {
        DiceCup diceCup;
        UserInteraction userInteraction;
        ScoreBoard scoreBoard;
        private int _turnNo = 0;
        public Yatzy()
        {
            diceCup = new DiceCup();
            userInteraction = new UserInteraction();
            scoreBoard = new ScoreBoard();
        }
        public void StartGame()
        {
            Console.Clear();
            var input = userInteraction.UserStartGame();

            if (input == "yes" || input == "y")
            {
                NewTurn();
            }
            else if (input == "no" || input == "n")
            {
                Console.Clear();
                Console.WriteLine("Goodbye commander...");
                return;
            }
            else
            {
                throw new ArgumentException("Wrong input, try again");

            }
        }
        public void NewTurn()
        {
            diceCup.amountOfRolls = 3;
            _turnNo += 1;
            userInteraction.StartNewTurn();

            while (diceCup.amountOfRolls >= 0)
            {
                if (diceCup.amountOfRolls >= 3)
                {
                    scoreBoard.ToString();
                    diceCup.ThrowDice();
                }

                var rollHoldOrEnd = userInteraction.UserRollOrHold();
                if (diceCup.amountOfRolls > 0 && (rollHoldOrEnd == "hold" || rollHoldOrEnd == "HOLD" || rollHoldOrEnd == "h"))
                {
                    var holdDices = userInteraction.UserHoldDices();
                    diceCup.HoldDices(holdDices);
                    var rollAgain = userInteraction.CheckRollAgain();

                    if (rollAgain == "y" || rollAgain == "y")
                    {
                        diceCup.ReThrowDices();
                    }
                    else
                    {
                        EndTurn();
                    }
                }
                else if (diceCup.amountOfRolls > 0 && (rollHoldOrEnd == "roll" || rollHoldOrEnd == "Roll" || rollHoldOrEnd == "r"))
                {
                    diceCup.ReThrowDices();
                }
                else if (diceCup.amountOfRolls == 0)
                {
                    Console.WriteLine("No more rolls this turn!");
                    EndTurn();
                }
                else if (rollHoldOrEnd == "end" || rollHoldOrEnd == "e")
                {
                    EndTurn();
                }
            }

            EndTurn();
        }

        public void EndTurn()
        {
            scoreBoard.SaveScore(_turnNo, diceCup.rolledDices);
            diceCup.amountOfRolls = 0;
            diceCup.RemoveHeldDice();
            NewTurn();
        }
    }
}
