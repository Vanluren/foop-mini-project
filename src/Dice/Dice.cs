using System;

namespace foop_mini_project
{
    public class Dice
    {
        public Random random;
        public int numberOfSides = 6;
        public int CurrentEyes { get; set; }

        public bool HoldDice { get; set; }
        public Dice()
        {
            //add seed as to get an actual random value.
            random = new Random(Guid.NewGuid().GetHashCode());
            CurrentEyes = 0;
        }
        public virtual int Roll()
        {
            return CurrentEyes = random.Next(1, numberOfSides + 1);
        }
    }
}