using System;
using foop_mini_project;
using foop_mini_project.src;

namespace foop_mini_project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new yatzy game
            Yatzy yatzy = new Yatzy();

            // Start the yatzy game ;-)
            yatzy.StartGame();
        }
    }
}
