using System;

namespace foop_mini_project
{
    /// <summary>  
    ///  The Dice-class represents the dices that are use by the game.
    /// <param name="sides">Inits the number of sides the dice should have</param>  
    /// </summary>  
    public class Dice
    {
        protected Random random;
        protected int numberOfSides;
        protected bool Held = false;
        public int CurrentEyes;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:foop_mini_project.Dice"/> class.
        /// </summary>
        /// <param name="sides">Sides.</param>
        public Dice(int sides = 6)
        {
            numberOfSides = sides;
            //add seed as to get an actual random value. Stolen from slides.
            random = new Random(Guid.NewGuid().GetHashCode());
        }
        /// <summary>
        /// Rolls the dice.
        /// </summary>
        /// <returns>The dice with the newly set eyes</returns>
        public virtual int RollDice()
        {
            if (Held == false)
            {
                return CurrentEyes = random.Next(1, numberOfSides + 1);
            }
            return CurrentEyes;
        }
        /// <summary>
        /// Holds the dice.
        /// </summary>
        /// <param name="holdDice">If set to <c>true</c> hold dice.</param>
        public void HoldDice(bool holdDice)
        {
            Held = holdDice;
        }
    }
}
