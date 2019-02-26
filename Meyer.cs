using System;
namespace FoopMiniProject
{
    class Meyer
    {
        public Meyer()
        {
            FirstDie = new Dice();
            SecondDie = new Dice();
        }
        public Dice FirstDie { get; }
        public Dice SecondDie { get; }
        public bool HasMeyer
        {
            get
            {
                return FirstDie.Current + SecondDie.Current == 3;
            }
        }
        public void Roll()
        {
            FirstDie.Roll();
            SecondDie.Roll();
        }
    }

    class MeyerDemo
    {
        public static float LikelyhoodMeyer(float rounds = 10000)
        {
            var m = new Meyer();
            float hasMeyer = 0;
            float noMeyer = 0;

            for (var i = 0; i < rounds; i++)
            {
                m.Roll();
                if (m.HasMeyer) hasMeyer++;
                else noMeyer++;
            }
            return hasMeyer / rounds * 100;
        }
        static void Main(String[] args)
        {
            System.Console.WriteLine("Meyer:");
            System.Console.WriteLine(LikelyhoodMeyer() + "%");
        }
    }
}