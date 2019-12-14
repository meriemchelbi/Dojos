using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.IO;
using DojoTemplateConsoleApp.SpaceImage;
using DojoTemplateConsoleApp.OpCode;
using DojoTemplateConsoleApp.UniveralOrbit;

namespace DojoTemplateConsoleApp
{
    public class InputParser
    {
        public List<int> ParseModuleMass()
        {
            var moduleMasses = new List<int>();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ModuleMasses.txt");
            var input = System.IO.File.ReadAllLines(path);
            foreach (var line in input)
            {
                var moduleMass = int.Parse(line);
                moduleMasses.Add(moduleMass);
            }

            return moduleMasses;
        
        }

        public int[] ParseOpCode(OpCodeOperations opCodeOperations)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"OpCode\OpCode.txt");
            var commaDelimitedInput = File.ReadAllText(path);
            var inputArray = commaDelimitedInput.Split(",");
            
            opCodeOperations.Input = inputArray.Select(c => int.Parse(c)).ToArray();
   
            return opCodeOperations.Input;
        }
        
        public void ParseSpaceImageArray(SpaceImageFormat spaceImageFormat)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"SpaceImage\SpaceImage.txt");
            spaceImageFormat.InputArray = File.ReadAllText(path).ToArray();
        }

        public void ParseSpaceBodies(Galaxy galaxy)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"UniversalOrbit\UniversalOrbit.txt");
            var input = System.IO.File.ReadAllLines(path);
            galaxy.Input = input.ToList();
        }

    }
}
