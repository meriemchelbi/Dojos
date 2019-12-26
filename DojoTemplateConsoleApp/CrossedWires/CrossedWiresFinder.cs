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
            WireOneSegments = new List<Segment>();
            WireTwoSegments = new List<Segment>();
        }
        public List<string> WireOneDirections { get; set; }
        public List<string> WireTwoDirections { get; set; }
        public List<(int, int)> WireOnePoints { get; set; }
        public List<(int, int)> WireTwoPoints { get; set; }
        public List<Segment> WireOneSegments { get; set; }
        public List<Segment> WireTwoSegments { get; set; }
        public List<(int, int)> Intersections { get; set; }

        public void ParseInput()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"CrossedWires\CrossedWiresInput.txt");
            var input = File.ReadAllLines(path);
            WireOneDirections = input[0].Split(",").ToList();
            WireTwoDirections = input[1].Split(",").ToList();
        }

        public void LoadSegments()
        {
            var start = (0, 0);

            for (int i = 0; i < WireOneDirections.Count; i++)
            {
                var direction = WireOneDirections[i].Substring(0, 1);
                var incline = (direction == "U" || direction == "D")
                              ? "V"
                              : "H";

                var next = MoveWire(WireOneDirections[i], start);

                var end = (start.Item1 <= next.Item1) && (start.Item2 <= next.Item2)
                          ? next
                          : start;
                start = (start.Item1 <= next.Item1) && (start.Item2 <= next.Item2)
                          ? start
                          : next;

                var segment = new Segment(direction, incline, start, end);

                WireOneSegments.Add(segment);

                start = next;
            }
            
            start = (0, 0);

            for (int i = 0; i < WireTwoDirections.Count; i++)
            {
                var direction = WireTwoDirections[i].Substring(0, 1);
                var incline = (direction == "U" || direction == "D")
                              ? "V"
                              : "H";
                var next = MoveWire(WireTwoDirections[i], start);

                var end = (start.Item1 <= next.Item1) && (start.Item2 <= next.Item2)
                          ? next
                          : start;
                
                start = (start.Item1 <= next.Item1) && (start.Item2 <= next.Item2)
                          ? start
                          : next;

                var segment = new Segment(direction, incline, start, end);

                WireTwoSegments.Add(segment);

                start = next;
            }

        }

        public void LoadPoints()
        {
            var (x, y) = (0, 0);
            WireOnePoints = WireOneDirections.Select(i => (x, y) = MoveWire(i, (x, y))).ToList();

            (x, y) = (0, 0);
            WireTwoPoints = WireTwoDirections.Select(i => (x, y) = MoveWire(i, (x, y))).ToList();
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
            for (int i = 0; i < (WireOnePoints.Count - 1); i++)
            {
                for (int j = 0; j < (WireTwoPoints.Count - 1); j++)
                {
                    var CurrentOne = (WireOnePoints[i].Item1, WireOnePoints[i].Item2);
                    var CurrentTwo = (WireTwoPoints[j].Item1, WireTwoPoints[j].Item2);
                    var NextOne = (WireOnePoints[i+1].Item1, WireOnePoints[i+1].Item2);
                    var NextTwo = (WireTwoPoints[j+1].Item1, WireTwoPoints[j+1].Item2);

                    var CurrentOneX = WireOnePoints[i].Item1;
                    var CurrentOneY = WireOnePoints[i].Item2;
                    var NextOneX = WireOnePoints[i+1].Item1;
                    var NextOneY = WireOnePoints[i+1].Item2;
                    
                    var CurrentTwoX = WireTwoPoints[j].Item1;
                    var CurrentTwoY = WireTwoPoints[j].Item2;
                    var NextTwoX = WireTwoPoints[j+1].Item1;
                    var NextTwoY = WireTwoPoints[j+1].Item2;

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
