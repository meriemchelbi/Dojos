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
            opCodeOps.ExecuteOpCode();

            Console.WriteLine(opCodeOps.OpCodes[0]);
        }
    }
}
