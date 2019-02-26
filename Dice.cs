using System;

namespace FoopMiniProject
{
    public class Dice
    {
        private Random random;
        public int Current { get; private set; }
        public Dice()
        {
            //add seed as to get an actual random value.
            random = new Random(Guid.NewGuid().GetHashCode());
            Current = 0;
        }

        public int Roll()
        {
            Current = random.Next(1, 7);
            return Current;
        }
    }
}