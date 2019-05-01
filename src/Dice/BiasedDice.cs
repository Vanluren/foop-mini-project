using System;
using foop_mini_project;

namespace foop_mini_project
{
    public class BiasedDice : Dice
    {
        public int BiadedRollDice(int kicker = 0)
        {
            return CurrentEyes = (kicker % 2 == 0) ? 6 : 0;
        }
    }
}
