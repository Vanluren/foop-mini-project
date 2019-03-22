using System;
using FoopMiniProject;

namespace foop_mini_project
{
     class TestYatzy
    {
        static void Main(string[] args)
        {
            Yatzy yatzyGame = new Yatzy();
            yatzyGame.Roll();
            Console.WriteLine("[{0}]", string.Join(", ", yatzyGame.rolledDices));
        }
    }
}