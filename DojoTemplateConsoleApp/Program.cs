using System;

namespace DojoTemplateConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var opCodeOps = new OpCodeOperations(); 
            var inputParser = new InputParser(opCodeOps);
            inputParser.ParseOpCode();
            //opCodeOps.ExecuteOpCode();
            //Console.WriteLine($"Day 2 part 1 result is {opCodeOps.OpCodes[0]}.");

            opCodeOps.FindNounVerb(19690720);
            Console.WriteLine($"Day 2 part 2 noun & verb are noun: {opCodeOps.OpCodes[1]} & verb {opCodeOps.OpCodes[2]}.");


        }
    }
}
