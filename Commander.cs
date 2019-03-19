using System;
using System.Collections.Generic;
using Cintio;

namespace foop_mini_project
{
    public class Commander
    {
        public static string InputHandler(List<string> strCmd, List<string> listCmd)
        {
            var handleInput = "(((--> " + strCmd + " <--)))";
            return handleInput + Environment.NewLine;
        }
        static void Main(string[] args)
        {
            var prompt = "cool> ";
            var startupMsg = "Welcome to my interactive Prompt!";
            List<string> completionList = new List<string> { "contracts", "contractearnings", "cancels", "cancellationInfo", "cantankerous" };
            InteractivePrompt.Run(() => {{
                    var handleInput = "(((--> " + strCmd + " <--)))";
                    return handleInput + Environment.NewLine;
                }}, prompt, startupMsg, completionList);
        }
    }
}