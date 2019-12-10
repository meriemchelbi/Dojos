using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.IO;
using DojoTemplateConsoleApp.SpaceImage;
using DojoTemplateConsoleApp.OpCode;

namespace DojoTemplateConsoleApp
{
    public class InputParser
    {
        public InputParser() { }
        public InputParser(OpCodeOperations opCodeOperations)
        {
            _opCodeOps = opCodeOperations;
        }

        private readonly OpCodeOperations _opCodeOps;
        
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

        public List<int> ParseOpCode()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"OpCode\OpCode.txt");
            var commaDelimitedInput = File.ReadAllText(path);
            var inputArray = commaDelimitedInput.Split(",");
            
            _opCodeOps.OpCodes = inputArray.Select(c => int.Parse(c)).ToList();
               
            return _opCodeOps.OpCodes;
        }
        
        public void ParseSpaceImageArray(SpaceImageFormat spaceImageFormat)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"SpaceImage\SpaceImage.txt");
            spaceImageFormat.InputArray = File.ReadAllText(path).ToArray();
        }
    }
}
