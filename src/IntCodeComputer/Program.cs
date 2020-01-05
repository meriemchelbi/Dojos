using System;

namespace IntCodeComputer
{
    class Program
    {
        static void Main(string[] args)
        {
            var opCodeParser = new OpCodeParser();
            var inputCapturer = new UserInputCapturer();
            var opCodeOps = new OpCodeOperations(inputCapturer);
            var output = new OutputRenderer();

            opCodeParser.ParseOpCode(opCodeOps, @"Input\DiagnosticProgramInput.txt");
            opCodeOps.RunProgramme();
            output.DisplayDiagnosticOutput(opCodeOps);
        }
    }
}
