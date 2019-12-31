using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.OpCode
{
    public class InputCapturer
    {
        public int GetUserInput()
        {
            Console.WriteLine("Please provide a number between 1 and 10 > ");
            var input = int.Parse(Console.ReadLine());
            return input;
        }
    }
}
