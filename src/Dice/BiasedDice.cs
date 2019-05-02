using System;
using foop_mini_project;

namespace foop_mini_project
{
    public class BiasedDice : Dice
    {
        int kicker;
        public override int RollDice()
        {
            if (Held == false)
            {
                return CurrentEyes = kicker != 0 ? kicker : 6;
            }
            return CurrentEyes;
        }
        public void SetKicker(int newKicker)
        {
            kicker = newKicker;
        }
    }
}
