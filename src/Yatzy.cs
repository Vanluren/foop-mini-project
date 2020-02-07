using System;
using System.Text.RegularExpressions;

namespace foop_mini_project.src
{
    /// <summary>
    /// Yatzy. Represents the flow of a yatzy game. 
    /// This class uses the Regex class in the System package. This is 
    /// used to easily check the users input.
    /// </summary>
    class Yatzy
    {
        /// <summary>
        /// The dice cup used in the game
        /// </summary>
        DiceCup diceCup;

        readonly UserInteraction userInteraction;
        readonly ValueChecker values;
        readonly ScoreBoard scoreBoard;

        /// <summary>
        /// The current turn no.
        /// </summary>
        int _turnNo;

        /// <summary>
        /// The chosen rolls per turn.
        /// </summary>
        int _rollsPerTurn;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:foop_mini_project.src.Yatzy"/> class.
        /// </summary>
        public Yatzy()
        {
            userInteraction = new UserInteraction();
            scoreBoard = new ScoreBoard();
            values = new ValueChecker();
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame()
        {
            try
            {
                Console.Clear();
                var input = userInteraction.UserStartGame();
                if (userInteraction.IsAnswerYes(input))
                {
                    string biased = userInteraction.UseFairOrBiased();
                    string rolls = userInteraction.HowManyRolls();

                    if (Regex.IsMatch(rolls, @"^\d$"))
                    {
                        _rollsPerTurn = int.Parse(rolls);
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
            }
            catch (ArgumentException argumentException)
            {
                throw new ArgumentException("Wrong input, try again", argumentException);
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong!", e);
            }
        }

        /// <summary>
        /// Starts a New turn.
        /// </summary>
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
                    diceCup.ChangeBiasedDice(short.Parse(userInput));
                    NewTurn();
                }
                else if (userInput == "Help" || userInput == "help")
                {
                }
                else if (Regex.IsMatch(userInput, @"^([eE])([nN][dD](\s)*)*\b"))
                {
                    EndTurnAndSave();
                }
            }
            Console.WriteLine("No more rolls this turn!");
            EndTurnAndSave();
        }

        /// <summary>
        /// Ends the turn and saves a combo and score.
        /// </summary>
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
                    int comboIndex = int.Parse(userInput);
                    if (comboIndex <= values.combinations.Count)
                    {
                        scoreBoard.SaveScore(_turnNo, values.GetComboFromCombolist(comboIndex));
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

        /// <summary>
        /// Ends the game.
        /// </summary>
        public void EndGame()
        {
            Console.Clear();
            Console.WriteLine("YOU ARE FINISHED!!! \n");
            scoreBoard.ToString();
        }
    }
}
