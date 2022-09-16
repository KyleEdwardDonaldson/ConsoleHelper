using System;
using System.Collections.Generic;
using System.Text;

namespace KonsoleHelper
{
    public class Console : IConsole
    {
        public void WriteLine(string message = "")
        {
            System.Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}
