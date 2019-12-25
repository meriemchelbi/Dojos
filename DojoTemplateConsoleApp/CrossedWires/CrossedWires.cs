using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DojoTemplateConsoleApp.CrossedWires
{
    public class CrossedWires
    {
        public List<string> wireOneDirections { get; set; }
        public List<string> wireTwoDirections { get; set; }

        public void ParseInput()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"CrossedWires\CrossedWiresInput.txt");
            var input = File.ReadAllLines(path);
            wireOneDirections = input[0].Split(",").ToList();
            wireTwoDirections = input[1].Split(",").ToList();
        }
    }
}
