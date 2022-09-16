using System;
using System.IO;

namespace KonsoleHelper
{
    public static class Konsole
    {
        // Can change this via reflection to a mocked IConsole so I can test stuff like WriteLine
        private static IConsole _console = new Console();


        /// <summary>
        /// Writes lines from array specified. Option to add lines between or lines after.
        /// </summary>
        public static void WriteLines(string[] messages, int linesAfter = 1, int linesInBetween = 0)
        {
            var length = messages.Length;

            if (length == 1 && linesInBetween > 0) 
            {
                throw new ArgumentException("Cannot have linesInBetween 1 line");
            }

            for(var messageIndex = 0; messageIndex < length; messageIndex++)
            {
                var message = messages[messageIndex];
                _console.WriteLine(message);

                // Isn't last item in array
                if (messageIndex != length - 1)
                {
                    // Add lines between
                    for (var i = 0; i < linesInBetween; i++)
                    {
                        _console.WriteLine();
                    }
                }
            }

            WriteLinesAfter(linesAfter);
        }

        /// <summary>
        /// Writes x number of empty lines by default, or can specifiy a string to repeat.
        /// </summary>
        public static void WriteLines(int numberOfLines, string repeatedLine = "", int linesAfter = 0)
        {
            for (var i = 0; i < numberOfLines; i++)
            {
                _console.WriteLine(repeatedLine);
            }

            WriteLinesAfter(linesAfter);
        }

        public static void WriteLine(string message, int linesAfter = 1)
        {
            // Writes message into console
            _console.WriteLine(message);

            // Adds lines after message
            WriteLinesAfter(linesAfter);
        }

        /// <summary>
        /// Ask user for input of the specified type. linesAfter will come after their input.
        /// </summary>
        public static T AskForInput<T>(string request, string invalidInputMessage = "Unable to parse input.", int linesAfter = 1)
        {
            T userInputAsT = (T)Convert.ChangeType("0", typeof(T));
            bool successfulCast = false;
            while (!successfulCast)
            {
                // Requests information from user
                WriteLine(request, 0);
                var userInput = _console.ReadLine();

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

            WriteLinesAfter(linesAfter);

            return userInputAsT;
        }

        public static string AskForPath(string request = "Please enter a path", string emptyPathMessage = "Path input is empty", string pathDoesNotExistMessage = "Path does not exist", bool includeSlashAtEnd = true, int linesAfter = 1)
        {
            var path = string.Empty;
            var pathExists = !Directory.Exists(path);
            var pathIsEmpty = path == string.Empty;
            do
            {
                path = AskForInput<string>(request);

                if (pathIsEmpty)
                {
                    WriteLine(emptyPathMessage);
                }
                if (!pathExists)
                {
                    WriteLine(pathDoesNotExistMessage);
                }
            } while (pathIsEmpty || !pathExists);

            var endsWithSlash = path.EndsWith("/");
            if (includeSlashAtEnd)
            {
                if (!endsWithSlash)
                {
                    path.Remove(path.Length - 1);
                }
            } else
            {
                if (endsWithSlash)
                {
                    path += "/";
                }
            }

            WriteLinesAfter(linesAfter);

            return path;
        }

        private static void WriteLinesAfter(int linesAfter)
        {
            if (linesAfter > 0)
                WriteLines(linesAfter, linesAfter: 0);
        }
    }
}
