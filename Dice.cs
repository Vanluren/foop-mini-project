using System;

namespace FoopMiniProject
{
    public class Dice
    {
        private Random random;
        public int numberOfSides { get; private set; }
        public int Current { get; private set; }
        public Dice(int sides)
        {
            //add seed as to get an actual random value.
            random = new Random(Guid.NewGuid().GetHashCode());
            Current = 0;
            numberOfSides = sides;
        }
        public int Roll()
        {
            return Current = random.Next(1, numberOfSides + 1);
        }
    }
}