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
        int _rollsPerTurn;

        public Yatzy()
        {
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
                string biased = userInteraction.UseFairOrBiased();
                string rolls = userInteraction.HowManyRolls();

                if (Regex.IsMatch(rolls, @"^\d$"))
                {
                    _rollsPerTurn = Int16.Parse(rolls);
                    diceCup = new DiceCup(biased == "biased", _rollsPerTurn);
                }
                else
                {
                    _rollsPerTurn = 3;
                    diceCup = new DiceCup(biased == "biased", _rollsPerTurn);
                }

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
            _turnNo += 1;
            userInteraction.StartNewTurn();
            scoreBoard.ToString();
            diceCup.ThrowDice();
            while (_turnNo < 13)
            {
                var userInput = userInteraction.UserRollOrHold(diceCup.useBiased);
                if (diceCup.amountOfRolls > 0 && (Regex.IsMatch(userInput, @"^([hH]([oO][lL][dD])*)(\s)*$")))
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
                else if (diceCup.amountOfRolls > 0 && Regex.IsMatch(userInput, @"^([rR]([oO][lL][lL])*)(\s)*$"))
                {
                    diceCup.ReThrowDices();
                }
                else if (diceCup.useBiased && Regex.IsMatch(userInput, @"^([cC]([hH][aA][nN][gG][eE])*)(\s)*$"))
                {
                    userInput = userInteraction.ChangeBiasedDice();
                    diceCup.ChangeBiasedDice(Int16.Parse(userInput));
                    NewTurn();
                }
                else if (Regex.IsMatch(userInput, @"^([eE])([nN][dD](\s)*)*\b"))
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
            if (_turnNo >= 13)
            {
                EndGame();
            }
            else
            {
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
                diceCup.ResetDiceCup(_rollsPerTurn);
                NewTurn();
            }
        }
        public void EndGame()
        {
            Console.Clear();
            System.Console.WriteLine("YOU ARE FINISHED!!! \n");
            scoreBoard.ToString();
        }
    }
}
