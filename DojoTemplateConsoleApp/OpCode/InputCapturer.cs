using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.OpCode
{
    public interface ICaptureInput
    {
        int GetUserInput();
    }

    public class InputCapturer: ICaptureInput
    {
        public int GetUserInput()
        {
            Console.WriteLine("Please provide a number between 1 and 10 > ");
            var input = int.Parse(Console.ReadLine());
            return input;
        }
    }
}
