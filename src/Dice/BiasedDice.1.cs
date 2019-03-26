using System;
using foop_mini_project;

namespace foop_mini_project
{
    public class BiasedDice : Dice
    {
        public override int Roll()
        {
            return CurrentEyes = random.Next(1, numberOfSides + 1);
        }
    }
}