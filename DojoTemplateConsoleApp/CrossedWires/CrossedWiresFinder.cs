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
            //Intersections = new List<(int, int)>();
        }
        public List<string> WireOneDirections { get; set; }
        public List<string> WireTwoDirections { get; set; }
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

            WireOneSegments = WireOneDirections.Select(d => BuildSegment(d, ref start)).ToList();
            
            start = (0, 0);

            WireTwoSegments = WireTwoDirections.Select(d => BuildSegment(d, ref start)).ToList();
        }

        private Segment BuildSegment(string instruction, ref (int, int) startPosition)
        {
            var direction = instruction.Substring(0, 1);
            var incline = (direction == "U" || direction == "D")
                          ? "V"
                          : "H";

            var next = MoveWire(instruction, startPosition);

            var end = (startPosition.Item1 <= next.Item1) && (startPosition.Item2 <= next.Item2)
                      ? next
                      : startPosition;
            startPosition = (startPosition.Item1 <= next.Item1) && (startPosition.Item2 <= next.Item2)
                      ? startPosition
                      : next;

            var segment = new Segment(direction, incline, startPosition, end);
            
            startPosition = next;

            return segment;

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

        public void FindIntersectionsWithSegments()
        {
            Intersections = WireOneSegments.SelectMany(s => FindIntersections(s)).ToList();
        }

        private IEnumerable<(int, int)> FindIntersections(Segment segment)
        {
            if (segment.Incline == "H")
            {
                return WireTwoSegments.Where(s => s.Incline == "V")
                               .Where(s => segment.StartPoint.Item1 <= s.StartPoint.Item1
                                        && s.StartPoint.Item1 <= segment.EndPoint.Item1
                                        && s.StartPoint.Item2 <= segment.StartPoint.Item2
                                        && segment.StartPoint.Item2 < s.EndPoint.Item2)
                               .Select(s => (s.StartPoint.Item1, segment.StartPoint.Item2));
            }
            else
            {
                return WireTwoSegments.Where(s => s.Incline == "H")
                               .Where(s => segment.StartPoint.Item2 <= s.StartPoint.Item2
                                        && s.StartPoint.Item2 <= segment.EndPoint.Item2
                                        && s.StartPoint.Item1 <= segment.StartPoint.Item1
                                        && segment.StartPoint.Item1 < s.EndPoint.Item1)
                               .Select(s => (segment.StartPoint.Item1, s.StartPoint.Item2));
            }
        }

        public int FindClosestIntersection()
        {
            var lowestTotal = int.MaxValue;

            foreach (var point in Intersections)
            {
                var distance = Math.Abs(point.Item1) + Math.Abs(point.Item2);
                if (distance < lowestTotal && distance != 0)
                {
                    lowestTotal = distance;
                };
            }

            return lowestTotal;
        }
    }
}
