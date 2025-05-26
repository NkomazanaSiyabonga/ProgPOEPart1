using System;

namespace ProgPOEPart1
{
    internal class Program
    {
        static void Main()
        {
            ConsoleUI.ShowAsciiArt();
            ConsoleUI.PlayWelcomeMessage();
            ConsoleUI.GetUserName();
            Bot.RunChatLoop();
        }
    }
}
