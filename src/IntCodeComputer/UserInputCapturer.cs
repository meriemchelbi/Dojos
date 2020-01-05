using System;
using System.Collections.Generic;
using System.Text;

namespace IntCodeComputer
{
    public interface ICaptureInput
    {
        int GetUserInput();
    }

    public class UserInputCapturer: ICaptureInput
    {
        public int GetUserInput()
        {
            Console.WriteLine("Please provide a number between 1 and 10 > ");
            var input = int.Parse(Console.ReadLine());
            return input;
        }
    }
}
