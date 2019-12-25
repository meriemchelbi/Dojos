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
        public List<string> WireOneDirections { get; set; }
        public List<string> WireTwoDirections { get; set; }
        public object WireOnePath { get; set; }
        public object WireTwoPath { get; set; }

        public void ParseInput()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"CrossedWires\CrossedWiresInput.txt");
            var input = File.ReadAllLines(path);
            WireOneDirections = input[0].Split(",").ToList();
            WireTwoDirections = input[1].Split(",").ToList();
        }

        public void LoadPaths()
        {
            var (x, y) = (0, 0);
            WireOnePath = WireOneDirections.Select(i => (x, y) = MoveWire(i, (x, y))).ToList();

            (x, y) = (0, 0);
            WireTwoPath = WireTwoDirections.Select(i => (x, y) = MoveWire(i, (x, y))).ToList();
        }

        private (int, int) MoveWire(string instruction, (int, int) position)
        {
            var (x, y) = position;
            var direction = instruction.Substring(0, 1);
            var distance = int.Parse(instruction.Substring(1));

            switch (direction)
            {
                case "U":
                    y += distance;
                    break;
                case "D":
                    y -= distance;
                    break;
                case "L":
                    x -= distance;
                    break;
                case "R":
                    x += distance;
                    break;
                default:
                    break;
            }

            return (x, y);
        }
    }
}
