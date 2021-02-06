using System;

namespace DojoTemplateConsoleApp.UserInterface
{
    public class ConsoleWrapper : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
