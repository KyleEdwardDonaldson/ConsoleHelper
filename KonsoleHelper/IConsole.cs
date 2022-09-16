using System;
using System.Collections.Generic;
using System.Text;

namespace KonsoleHelper
{
    public interface IConsole
    {
        void WriteLine(string message = "");

        string ReadLine();
    }
}
