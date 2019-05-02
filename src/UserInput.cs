using System;
namespace foop_mini_project.src
{
    /// <summary>
    /// User input.
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// Gets the user input.
        /// </summary>
        /// <returns>The user input.</returns>
        /// <param name="userMessage">User message.</param>
        protected string GetUserInput(string userMessage)
        {
            Console.WriteLine(userMessage);
            var input = Console.ReadLine();
            return input;
        }
    }
}
