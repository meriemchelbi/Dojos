using System;

namespace DojoTemplateConsoleApp.UserInterface
{
    public class ConsoleWrapper : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string lineToWrite)
        {
            Console.WriteLine(lineToWrite);
        }
    }
}
