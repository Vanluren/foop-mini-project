using System;

namespace FoopMiniProject
{
    public class Dice
    {
        private Random random;
        public int numberOfSides { get; private set; }
        public int CurrentEyes { get; private set; }
        public Dice(int sides)
        {
            //add seed as to get an actual random value.
            random = new Random(Guid.NewGuid().GetHashCode());
            CurrentEyes = 0;
            numberOfSides = sides;
        }
        public int Roll()
        {
            return CurrentEyes = random.Next(1, numberOfSides + 1);
        }
    }
}