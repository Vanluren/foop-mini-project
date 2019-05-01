using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace foop_mini_project.src
{
    public class UserInput
    {
        protected string GetUserInput(string userMessage)
        {
            Console.WriteLine(userMessage);
            var input = Console.ReadLine();
            return input;
        }
    }
}
