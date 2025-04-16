using System;
using System.Media;
using System.Threading;
using System.Text;

namespace ProgPOEPart1
{
    internal class Program
    {
        // Initializes colours
        private static ConsoleColor titleColor = ConsoleColor.Magenta;
        private static ConsoleColor botColor = ConsoleColor.White;
        private static ConsoleColor userColor = ConsoleColor.Cyan;
        private static ConsoleColor warningColor = ConsoleColor.Red;
        private static ConsoleColor infoColor = ConsoleColor.Blue;
        static string userName = "";
        static bool shouldExit = false;

        static void Main()
        {
            // Display ASCII art with typing effect
            ShowAsciiArt();

            // Play welcome message
            PlayWelcomeMessage();

            // Get user's name and personalize interaction
            GetUserName();

            // Main chat loop
            RunChatLoop();
        }

        static void ShowAsciiArt()
        {
            Console.Clear();

            // Cybersecurity-themed ASCII art
            string asciiArt = @"
      .--------.
     / .------. \
    / /        \ \
    | |        | |
   _| |________| |_ _
 /  |_|        |_|  /|               
'._____ ____ _____./ |
|     .'____'.     | |
'.__.'.'    '.'.__.' |
'.__  |      |  __.' |
|   '.'.____.'.'   | |
'.____'.____.'____.' |
'.________________.'
";

            // Type out the ASCII art with delay
            TypeWriterEffect(asciiArt, ConsoleColor.Cyan);

            Thread.Sleep(1000); // Pause to let user see the art
        }

        static void PlayWelcomeMessage()
        {
            try
            {
                // Play the welcome message asynchronously
                SoundPlayer soundPlayer = new SoundPlayer("C:\\Users\\lab_services_student\\Documents\\Programming 2A\\ProgPOEPart1\\Audio\\Welcome.wav");
                soundPlayer.Play();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nCould not play welcome message: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void GetUserName()
        {
            PrintSectionHeader("Welcome to Cybersecurity Awareness Bot");

            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeWriterEffect("\nBefore we begin, may I know your name? ", ConsoleColor.Yellow);
            Console.ResetColor();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                userName = Console.ReadLine();
                Console.ResetColor();

                if (!string.IsNullOrWhiteSpace(userName))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    TypeWriterEffect($"\nNice to meet you, {userName}! ", 20);
                    TypeWriterEffect("I'm here to help you stay safe online.\n", 20);
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease enter a valid name.");
                    Console.ResetColor();
                }
            }

            PrintSectionDivider();
        }

        static void RunChatLoop()
        {
            PrintSectionHeader("How can I help you today?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You can ask me about:");
            Console.WriteLine("- Password safety");
            Console.WriteLine("- Phishing scams");
            Console.WriteLine("- Safe browsing");
            Console.WriteLine("- General cybersecurity tips");
            Console.WriteLine(" * Or just say 'hi' to chat!");
            Console.WriteLine(" * say 'bye' to end the chat!");
            Console.ResetColor();
            PrintSectionDivider();

            while (!shouldExit)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{userName}> ");
                Console.ResetColor();

                string input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a question or message.");
                    Console.ResetColor();
                    continue;
                }

                string response = GetBotResponse(input);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nBot> ");
                TypeWriterEffect(response + "\n", 20);
                Console.ResetColor();

                PrintSectionDivider();

                if (shouldExit)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    TypeWriterEffect($"Goodbye, {userName}! Stay safe online!\n", 20);
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    return;
                }
            }
        }

        
    }
}