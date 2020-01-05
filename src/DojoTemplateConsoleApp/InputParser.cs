using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.IO;
using DojoTemplateConsoleApp.SpaceImage;
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
