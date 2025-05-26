using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProgPOEPart1
{
    internal static class Utilities
    {
        public static void TypeWriterEffect(string text, int delay = 10)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }

        public static void TypeWriterEffect(string text, ConsoleColor color, int delay = 10)
        {
            Console.ForegroundColor = color;
            TypeWriterEffect(text, delay);
            Console.ResetColor();
        }

        public static void PrintSectionHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n{new string('=', title.Length + 4)}");
            Console.WriteLine($"| {title} |");
            Console.WriteLine($"{new string('=', title.Length + 4)}\n");
            Console.ResetColor();
        }

        public static void PrintSectionDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"\n{new string('-', Console.WindowWidth - 1)}");
            Console.ResetColor();
        }

        public static string FormatResponsesWithHeadings(List<string> topics, List<string> responses)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < topics.Count; i++)
            {
                sb.AppendLine($"**{topics[i].ToUpper()}**: {responses[i]}\n");
            }
            return sb.ToString();
        }
    }
}
