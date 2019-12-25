using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.IO;
using DojoTemplateConsoleApp.SpaceImage;
using DojoTemplateConsoleApp.OpCode;
using DojoTemplateConsoleApp.UniveralOrbit;
using DojoTemplateConsoleApp.FuelRequirements;

namespace DojoTemplateConsoleApp
{
    public class InputParser
    {
        public List<int> ParseModuleMass()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"FuelRequirements\ModuleMasses.txt");
            return File.ReadAllLines(path)
                       .Select(l => int.Parse(l))
                       .ToList();
        }

        public int[] ParseOpCode(OpCodeOperations opCodeOperations)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"OpCode\OpCode.txt");
            return opCodeOperations.Input = File.ReadAllText(path)
                                         .Split(",")
                                         .Select(c => int.Parse(c))
                                         .ToArray();
        }
        
        public void ParseSpaceImageArray(SpaceImageFormat spaceImageFormat)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"SpaceImage\SpaceImage.txt");
            spaceImageFormat.InputArray = File.ReadAllText(path).ToArray();
        }

        public void ParseSpaceBodies(Galaxy galaxy)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"UniversalOrbit\UniversalOrbit.txt");
            galaxy.Input = File.ReadAllLines(path).ToList();
        }

    }
}
