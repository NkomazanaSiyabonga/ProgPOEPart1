using System;
using System.Collections.Generic;
using System.Threading;

namespace ProgPOEPart1
{
    internal static class Bot
    {
        private static string favoriteTopic = "";
        private static bool shouldExit = false;
        private static bool userIsCurious = false;

        public static void RunChatLoop()
        {
            Utilities.PrintSectionHeader("How can I help you today?");
            ConsoleUI.ShowTopics();

            while (!shouldExit)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{ConsoleUI.UserName}> ");
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
                Utilities.TypeWriterEffect(response + "\n", 20);
                Console.ResetColor();

                Utilities.PrintSectionDivider();

                if (shouldExit)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Utilities.TypeWriterEffect($"Goodbye, {ConsoleUI.UserName}! Stay safe online!\n", 20);
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    return;
                }

                if (!input.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nIs there anything else you'd like to learn?");
                    Console.ResetColor();
                }
            }
        }

        private static string GetBotResponse(string input)
        {
            string sentimentResponse = DetectSentiment(input);
            string topicResponse = GetTopicResponse(input);

            if (!string.IsNullOrEmpty(sentimentResponse) || !string.IsNullOrEmpty(topicResponse))
                return $"{sentimentResponse}\n\n{topicResponse}".Trim();

            if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey"))
                return $"Hello, {ConsoleUI.UserName}! How can I help you with cybersecurity today?";

            if (input.Contains("how are you"))
                return "I'm just a bot, I do not feel anything but I'm functioning well and ready to assist you!";

            if (input.Contains("purpose") || input.Contains("what do you do"))
                return "My purpose is to educate people about cybersecurity best practices and help them stay safe online.";

            if (input.Contains("thank"))
                return $"You're welcome, {ConsoleUI.UserName}! Is there anything else you'd like to ask me?";

            if (input.Contains("no") || input.Contains("no thanks"))
                return $"Alright {ConsoleUI.UserName}, feel free to ask me anything else or say 'bye' to exit.";

            if (input.Contains("yes"))
                return $"Great! What would you like to know more about? You mentioned '{favoriteTopic}' earlier.";

            if (input.Contains("bye") || input.Contains("exit"))
            {
                shouldExit = true;
                return $"Goodbye, {ConsoleUI.UserName}! Stay safe online!";
            }

            return "I'm not sure I understood that. You can ask me about passwords, phishing, privacy, cyber bullying, viruses, or other cybersecurity tips.";
        }

        private static string DetectSentiment(string input)
        {
            userIsCurious = false;

            if (input.Contains("worried") || input.Contains("scared") || input.Contains("anxious"))
                return "It's completely understandable to feel that way. Let me share some tips to help you stay safe.";

            if (input.Contains("curious") || input.Contains("interested"))
            {
                userIsCurious = true;
                return "I'm glad to know that you're curious! Cybersecurity is an important topic.";
            }

            if (input.Contains("frustrated") || input.Contains("confused") || input.Contains("overwhelmed"))
                return "Don't worry, these topics can be tricky. I'm here to explain things clearly—just let me know what you need help with.";

            return "";
        }

        private static string GetTopicResponse(string input)
        {
            var matchedTopics = new List<string>();
            var responses = new List<string>();

            foreach (var alias in ChatData.TopicAliases)
            {
                if (input.Contains(alias.Key) && ChatData.TopicResponses.ContainsKey(alias.Value))
                {
                    if (!matchedTopics.Contains(alias.Value))
                    {
                        matchedTopics.Add(alias.Value);
                        var responseList = ChatData.TopicResponses[alias.Value];
                        var rnd = new Random();
                        responses.Add(responseList[rnd.Next(responseList.Count)]);
                    }
                }
            }

            if (matchedTopics.Count > 0)
            {
                favoriteTopic = matchedTopics[0];

                return userIsCurious
                    ? "I noticed you're interested in the following topic(s):\n\n" + Utilities.FormatResponsesWithHeadings(matchedTopics, responses)
                      + "\n\nIs there anything else you'd like to ask me about?"
                    : string.Join("\n\n", responses);
            }

            return "";
        }
    }
}
