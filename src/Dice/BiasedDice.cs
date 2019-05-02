using System;
using foop_mini_project;

namespace foop_mini_project
{
    /// <summary>
    /// Biased dice.
    /// </summary>
    public class BiasedDice : Dice
    {
        int kicker;
        /// <summary>
        /// Rolls the dice, sets the eyes based on the biased randomizer
        /// </summary>
        /// <returns>The dice. with newly set eyes</returns>
        public override int RollDice()
        {
            if (Held == false)
            {
                return CurrentEyes = kicker != 0 ? kicker : 6;
            }
            return CurrentEyes;
        }
        /// <summary>
        /// Sets the kicker. The <paramref name="newKicker"/> sets what the eyes of the biased dice should be
        /// </summary>
        /// <param name="newKicker">New kicker.</param>
        public void SetKicker(int newKicker)
        {
            kicker = newKicker;
        }
    }
}
