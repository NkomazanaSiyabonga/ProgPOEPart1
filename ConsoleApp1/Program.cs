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

        static string GetBotResponse(string input)
        {
            if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey"))
                return $"Hello, {userName}! How can I help you with cybersecurity today?";

            if (input.Contains("how are you"))
                return "I'm just a bot, I do not have any feelings but I'm functioning quite well! Ready to help you with cybersecurity.";

            if (input.Contains("purpose") || input.Contains("what do you do"))
                return "My purpose is to educate people about cybersecurity best practices and help them stay safe online.";

            if (input.Contains("password") || input.Contains("safe password"))
                return "A strong password should:\n- Be at least 12 characters long\n- Include uppercase, lowercase, numbers, and symbols\n- Not contain personal information\n- Be unique for each account\nConsider using a password manager!  \n \n Would you like to explore another topic? (Yes/No)?";

            if (input.Contains("phishing") || input.Contains("scam"))
                return "Phishing scams try to trick you into giving personal information. Watch for:\n- Urgent or threatening language\n- Spelling mistakes\n- Suspicious links\n- Requests for sensitive data\nWhen in doubt, verify through official channels! \n  \n Would you like to explore another topic? (Yes/No)?";

            if (input.Contains("browsing") || input.Contains("internet safety"))
                return "For safe browsing:\n1. Look for 'https://' and padlock icon\n2. Keep browser/OS updated\n3. Use ad-blockers\n4. Avoid public WiFi for sensitive tasks\n5. Be cautious with downloads \n. \n7. Would you like to explore another topic? (Yes/No)?";

            if (input.Contains("general cybersecurity") || input.Contains("cybersecurity") || input.Contains("cybersecurity tips"))
                return "General Cybersecurity Tips:\n"
                     + "- Use strong, unique passwords & enable 2FA\n"
                     + "- Keep software & devices updated\n"
                     + "- Be cautious with email attachments/links\n"
                     + "- Backup important data regularly\n"
                     + "- Use a VPN on public networks\n"
                     + "- Monitor accounts for suspicious activity\n\n"
                     + "Would you like to explore another topic? (Yes/No)";

            if (input.Contains("thank") || input.Contains("thanks"))
                return $"You're welcome, {userName}! Please let me know if there's anything else I can help you with.";

            if (input.Contains("no") || input.Contains("no thanks"))
            {
                return $"Alright {userName}, I'll be here if you need anything else. You can say 'bye' or 'exit' to end the chat!";

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou can ask me about:");
                Console.WriteLine("- Password safety");
                Console.WriteLine("- Phishing scams");
                Console.WriteLine("- Safe browsing");
                Console.WriteLine("- General cybersecurity tips");
                Console.WriteLine(" * Or just say 'hi' to chat!");
                Console.WriteLine(" * say 'bye' to end the chat!");
                Console.ResetColor();
                PrintSectionDivider();
                return "What would you like to know about?";
            }

            if (input.Contains("bye") || input.Contains("exit"))
            {
                shouldExit = true;
                return $"Goodbye, {userName}! Stay safe online!";
            }

            if (input.Contains("yes"))
                return "Great! What would you like to know more about?";


            return "I didn't quite understand that. I can help with:\n- Password safety\n- Phishing scams\n- Safe browsing\n General Cybersecurity tips\n Could you rephrase or ask about one of these topics?";
        }

        static void TypeWriterEffect(string text, int delay = 10)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }

        static void TypeWriterEffect(string text, ConsoleColor color, int delay = 10)
        {
            Console.ForegroundColor = color;
            TypeWriterEffect(text, delay);
            Console.ResetColor();
        }

        static void PrintSectionHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n{new string('=', title.Length + 4)}");
            Console.WriteLine($"| {title} |");
            Console.WriteLine($"{new string('=', title.Length + 4)}\n");
            Console.ResetColor();
        }

        static void PrintSectionDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"\n{new string('-', Console.WindowWidth - 1)}");
            Console.ResetColor();
        }
    }
}