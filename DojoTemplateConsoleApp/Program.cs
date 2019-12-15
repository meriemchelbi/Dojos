using System;
using DojoTemplateConsoleApp.OpCode;
using DojoTemplateConsoleApp.SpaceImage;

namespace DojoTemplateConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            #region OpCode
            //var opCodeOps = new OpCodeOperations();
            //var inputParser = new InputParser();
            //inputParser.ParseOpCode(opCodeOps);
            //opCodeOps.ExecuteOpCode();
            //Console.WriteLine($"Day 2 part 1 result is {opCodeOps.OpCodes[0]}.");

            //opCodeOps.FindNounVerb(19690720);
            //Console.WriteLine($"Day 2 part 2 noun & verb are noun: {opCodeOps.OpCodes[1]} & verb {opCodeOps.OpCodes[2]}.");
            #endregion

            #region SpaceImage
            //var inputParser = new InputParser();
            //var spaceImageFormat = new SpaceImageFormat();

            //inputParser.ParseSpaceImageArray(spaceImageFormat);
            //spaceImageFormat.IsolateLayersList(25, 6);
            //var layerWithFewestZeros = spaceImageFormat.FindLayerWithFewestInstancesOfDigit('0');
            //var numberOfOnes = spaceImageFormat.CountInstancesOfDigit(layerWithFewestZeros, '1');
            //var numberOfTwos = spaceImageFormat.CountInstancesOfDigit(layerWithFewestZeros, '2');

            //Console.WriteLine($"Layer {layerWithFewestZeros.LayerID} has the fewest zeros.");
            //Console.WriteLine($"Layer {layerWithFewestZeros.LayerID} has {numberOfOnes} instances of '1' and {numberOfTwos} instances of '2'.");
            //Console.WriteLine($"The final result is {numberOfOnes * numberOfTwos}");

            #endregion

            #region SecureContainer

            var secureContainer = new SecureContainer();
            var result = secureContainer.FindNumberOfMatches(156218, 652527);
            Console.WriteLine($"The number of eligible passwords is {result}.");

            #endregion

        }
    }
}
