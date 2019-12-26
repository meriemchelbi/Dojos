using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DojoTemplateConsoleApp.CrossedWires
{
    public class CrossedWiresFinder
    {
        public CrossedWiresFinder()
        {
            Intersections = new List<(int, int)>();
        }
        public List<string> WireOneDirections { get; set; }
        public List<string> WireTwoDirections { get; set; }
        public List<(int, int)> WireOnePath { get; set; }
        public List<(int, int)> WireTwoPath { get; set; }
        public List<(int, int)> Intersections { get; set; }

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

        public void FindIntersections()
        {
            for (int i = 0; i < (WireOnePath.Count - 1); i++)
            {
                for (int j = 0; j < (WireTwoPath.Count - 1); j++)
                {
                    var CurrentOne = (WireOnePath[i].Item1, WireOnePath[i].Item2);
                    var CurrentTwo = (WireTwoPath[j].Item1, WireTwoPath[j].Item2);
                    var NextOne = (WireOnePath[i+1].Item1, WireOnePath[i+1].Item2);
                    var NextTwo = (WireTwoPath[j+1].Item1, WireTwoPath[j+1].Item2);

                    var CurrentOneX = WireOnePath[i].Item1;
                    var CurrentOneY = WireOnePath[i].Item2;
                    var NextOneX = WireOnePath[j+1].Item1;
                    var NextOneY = WireOnePath[j+1].Item2;
                    
                    var CurrentTwoX = WireTwoPath[i].Item1;
                    var CurrentTwoY = WireTwoPath[i].Item2;
                    var NextTwoX = WireTwoPath[j+1].Item1;
                    var NextTwoY = WireTwoPath[j+1].Item2;

                    var wibble = ((CurrentTwoY <= CurrentOneY && CurrentOneY <= NextTwoY) || (CurrentTwoY >= CurrentOneY && CurrentOneY >= NextTwoY))
                                && ((CurrentOneX <= CurrentTwoX && CurrentTwoX <= NextOneX) || (CurrentOneX >= CurrentTwoX && CurrentTwoX >= NextOneX));
                    
                    var wobble = ((CurrentOneY <= CurrentTwoY && CurrentTwoY <= NextOneY) || (CurrentOneY >= CurrentTwoY && CurrentTwoY >= NextOneY))
                                && ((CurrentTwoX <= CurrentOneX && CurrentOneX <= NextTwoX) || (CurrentTwoX >= CurrentOneX && CurrentOneX >= NextTwoX));

                    if (wibble)
                    {
                        var intersection = (CurrentTwoX, CurrentOneY);

                        if (Intersections.Contains(intersection)) continue;
                        else Intersections.Add(intersection);
                    }
                    if (wobble)
                    {
                        var intersection = (CurrentOneX, CurrentTwoY);

                        if (Intersections.Contains(intersection)) continue;
                        else Intersections.Add(intersection);
                    }
                }
            }
        }

        public int FindClosestIntersection()
        {
            var lowestTotal = int.MaxValue;

            foreach (var point in Intersections)
            {
                var distance = Math.Abs(point.Item1) + Math.Abs(point.Item2);
                if (distance < lowestTotal)
                {
                    lowestTotal = distance;
                };
            }

            return lowestTotal;
        }
    }
}
