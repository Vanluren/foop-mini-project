using System;
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
