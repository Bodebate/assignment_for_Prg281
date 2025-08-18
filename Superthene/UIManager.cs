using System;
using System.Collections.Generic;

namespace Superthene
{
    // Handles all UI-related features for the Superthene application.
    internal static class UIManager
    {
        public static void DisplayTitle()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\r\n▒█▀▀▀█ ▒█░▒█ ▒█▀▀█ ▒█▀▀▀ ▒█▀▀█ ▀▀█▀▀ ▒█░▒█ ▒█▀▀▀ ▒█▄░▒█ ▒█▀▀▀ \r\n░▀▀▀▄▄ ▒█░▒█ ▒█▄▄█ ▒█▀▀▀ ▒█▄▄▀ ░▒█░░ ▒█▀▀█ ▒█▀▀▀ ▒█▒█▒█ ▒█▀▀▀ \r\n▒█▄▄▄█ ░▀▄▄▀ ▒█░░░ ▒█▄▄▄ ▒█░▒█ ░▒█░░ ▒█░▒█ ▒█▄▄▄ ▒█░░▀█ ▒█▄▄▄");
            Console.ResetColor();
            Console.WriteLine("\n\t\tPress any key to continue...");
            Console.ReadKey();
        }

        public static void PrintBoxedTitle(string title)
        {
            int width = title.Length + 4; // Calculate box width based on title length
            string top = "╔" + new string('═', width - 2) + "╗";    // Top border
            string mid = $"║ {title} ║";                            // Middle line with title
            string bot = "╚" + new string('═', width - 2) + "╝";    // Bottom border
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine(top); 
            Console.WriteLine(mid); 
            Console.WriteLine(bot); 
            Console.ResetColor(); 
        }

        public static void WaitForKey(string message = "Press any key to continue...")
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        public static void ClearAndShowTitle(string title)
        {
            Console.Clear();
            PrintBoxedTitle(title);
        }
       
    }
}
