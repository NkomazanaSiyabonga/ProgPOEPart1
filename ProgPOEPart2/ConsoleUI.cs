using System;
using System.Media;
using System.Threading;

namespace ProgPOEPart1
{
    internal static class ConsoleUI
    {
        public static string UserName { get; private set; } = "";

        public static void ShowAsciiArt()
        {
            Console.Clear();
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
'.________________.'";
            Utilities.TypeWriterEffect(asciiArt, ConsoleColor.Cyan);
            Thread.Sleep(1000);
        }

        public static void PlayWelcomeMessage()
        {
            try
            {
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

        public static void GetUserName()
        {
            Utilities.PrintSectionHeader("Welcome to Cybersecurity Awareness Bot");
            Utilities.TypeWriterEffect("\nBefore we begin, may I know your name? ", ConsoleColor.Yellow);

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                string input = Console.ReadLine();
                Console.ResetColor();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    UserName = input;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Utilities.TypeWriterEffect($"\nNice to meet you, {UserName}! I'm here to help you stay safe online.\n", 20);
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
            Utilities.PrintSectionDivider();
        }

        public static void ShowTopics()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You can ask me about:");
            Console.WriteLine("- Password safety\n- Phishing scams\n- Online privacy\n- Digital footprint");
            Console.WriteLine("- Cyber bullying\n- Skills needed for Cyber Security Careers\n- Types of viruses");
            Console.WriteLine("- Incident response (In the event that you have been hacked)");
            Console.WriteLine("- General cybersecurity tips");
            Console.WriteLine(" * Or just say 'hi' to chat!");
            Console.WriteLine(" * Say 'bye' to end the chat!");
            Console.ResetColor();
            Utilities.PrintSectionDivider();
        }
    }
}
