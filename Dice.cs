using System;

namespace FoopMiniProject
{
    public class Dice
    {
        private Random random;
        public int Current { get; private set; }
        public Dice()
        {
            random = new Random();
            Current = 0;
        }

        public int Roll()
        {
            Current = random.Next(1, 7);
            return Current;
        }
    }
}