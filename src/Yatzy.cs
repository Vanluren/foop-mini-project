using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using foop_mini_project;
using foop_mini_project.src;

namespace foop_mini_project.src
{
    class Yatzy
    {
        DiceCup diceCup;
        UserInteraction userInteraction;
        ValueChecker values;
        ScoreBoard scoreBoard;
        private int _turnNo = 0;

        public Yatzy()
        {
            diceCup = new DiceCup();
            userInteraction = new UserInteraction();
            scoreBoard = new ScoreBoard();
            values = new ValueChecker();
        }
        public void StartGame()
        {
            Console.Clear();
            var input = userInteraction.UserStartGame();

            if (userInteraction.IsAnswerYes(input))
            {
                NewTurn();
            }
            else if (userInteraction.IsAnswerNo(input))
            {
                Console.Clear();
                Console.WriteLine("Goodbye commander...");
                return;
            }
            else
            {
                StartGame();
                throw new ArgumentException("Wrong input, try again");
            }
        }
        public void NewTurn()
        {
            diceCup.amountOfRolls = 3;
            _turnNo += 1;
            userInteraction.StartNewTurn();
            scoreBoard.ToString();
            diceCup.ThrowDice();
            while (diceCup.amountOfRolls <= 3)
            {
                var rollHoldOrEnd = userInteraction.UserRollOrHold();
                if (diceCup.amountOfRolls > 0 && (Regex.IsMatch(rollHoldOrEnd, @"^([hH]([oO][lL][dD])*)(\s)*$")))
                {
                    var holdDices = userInteraction.UserHoldDices();
                    diceCup.HoldDices(holdDices);
                    var rollAgain = userInteraction.CheckRollAgain();

                    if (userInteraction.IsAnswerYes(rollAgain))
                    {
                        diceCup.ReThrowDices();
                    }
                    else
                    {
                        EndTurnAndSave();
                    }
                }
                else if (diceCup.amountOfRolls > 0 && Regex.IsMatch(rollHoldOrEnd, @"^([rR]([oO][lL][lL])*)(\s)*$"))
                {
                    diceCup.ReThrowDices();
                }
                else if (Regex.IsMatch(rollHoldOrEnd, @"^([eE])([nN][dD](\s)*)*\b"))
                {
                    EndTurnAndSave();
                }
            }
            Console.WriteLine("No more rolls this turn!");
            EndTurnAndSave();
        }
        public void EndTurnAndSave()
        {
            Console.WriteLine(values.PossibleComboList(diceCup.rolledDices, scoreBoard.upperLocked));
            var userInput = userInteraction.EndTurnAndSaveCombo();
            if (userInteraction.IsAnswerNo(userInput))
            {
                scoreBoard.SaveScore(_turnNo);
            }
            else if (Regex.IsMatch(userInput, @"^\d$"))
            {
                int comboIndex = Int32.Parse(userInput);
                if (comboIndex <= values.combinations.Count)
                {
                    scoreBoard.SaveScore(_turnNo, values.GetCombo(comboIndex), userInput);
                }
                else
                {
                    Console.WriteLine("Please choose one of the combos! \n");
                    EndTurnAndSave();
                }
            }
            else
            {
                Console.WriteLine("Wrong input! try again... \n");
                EndTurnAndSave();
            }

            diceCup.amountOfRolls = 0;
            diceCup.RemoveHeldDice();
            NewTurn();
        }
    }
}
