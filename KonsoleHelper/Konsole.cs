using System;

namespace KonsoleHelper
{
    public static class Konsole
    {
        public static void WriteLines(string[] messages, int linesInBetween = 0)
        {
            foreach(var message in messages)
            {
                Console.WriteLine(message);

                for (var i = 0; i < linesInBetween; i++)
                {
                    Console.WriteLine();
                }
            }
        }

        public static void WriteLines(int numberOfLines, string repeatedLine = "")
        {
            for (var i = 0; i < numberOfLines; i++)
            {
                Console.WriteLine(repeatedLine);
            }
        }

        public static void WriteLine(string message, int linesAfter = 1)
        {
            // Writes message into console
            Console.WriteLine(message);

            // Adds lines after message
            WriteLines(linesAfter);
        }

        public static T AskForInput<T>(string request, string invalidInputMessage = "Unable to parse input.", int linesAfter = 1)
        {
            T userInputAsT = (T)Convert.ChangeType("0", typeof(T));
            bool successfulCast = false;
            while (!successfulCast)
            {
                // Requests information from user
                WriteLine(request, 0);
                var userInput = Console.ReadLine();

                try
                {
                    // Attempts to convert user input to requested type
                    userInputAsT = (T)Convert.ChangeType(userInput, typeof(T));
                    successfulCast = true;
                }
                catch
                {
                    // Prompts the user that their input was unable to be parsed
                    successfulCast = false;
                    WriteLine(invalidInputMessage, 1);
                }
            }

            WriteLines(linesAfter);

            return userInputAsT;
        }
    }
}
