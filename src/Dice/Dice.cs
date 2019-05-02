using System;

namespace foop_mini_project
{
    public class Dice
    {
        protected Random random;
        protected int numberOfSides;
        protected bool Held = false;
        public int CurrentEyes;
        public Dice(int sides = 6)
        {
            numberOfSides = sides;
            //add seed as to get an actual random value. Stolen from slides.
            random = new Random(Guid.NewGuid().GetHashCode());
        }
        public virtual int RollDice()
        {
            if (Held == false)
            {
                return CurrentEyes = random.Next(1, numberOfSides + 1);
            }
            return CurrentEyes;
        }
        public void HoldDice(bool holdDice)
        {
            Held = holdDice;
        }
    }
}
