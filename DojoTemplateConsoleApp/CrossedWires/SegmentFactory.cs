using System.IO;
using System.Linq;
using System.Reflection;

namespace DojoTemplateConsoleApp.CrossedWires
{
    public class SegmentFactory
    {
        public SegmentFactory(IntersectionFinder intersectionFinder)
        {
            _intersectionFinder = intersectionFinder;
        }

        private readonly IntersectionFinder _intersectionFinder;
        public void ParseInput()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"CrossedWires\CrossedWiresInput.txt");
            var input = File.ReadAllLines(path);
            _intersectionFinder.WireOneDirections = input[0].Split(",").ToList();
            _intersectionFinder.WireTwoDirections = input[1].Split(",").ToList();
        }

        public void LoadSegments()
        {
            var start = (0, 0);

            _intersectionFinder.WireOneSegments = _intersectionFinder.WireOneDirections.Select(d => BuildSegment(d, ref start, 1)).ToList();

            start = (0, 0);

            _intersectionFinder.WireTwoSegments = _intersectionFinder.WireTwoDirections.Select(d => BuildSegment(d, ref start, 2)).ToList();
        }

        private Segment BuildSegment(string instruction, ref (int, int) startPosition, int wire)
        {
            var direction = instruction.Substring(0, 1);
            var numOfSteps = int.Parse(instruction.Substring(1));
            var incline = (direction == "U" || direction == "D")
                          ? "V"
                          : "H";

            var next = MoveWire(direction, numOfSteps, startPosition);

            var end = (startPosition.Item1 <= next.Item1) && (startPosition.Item2 <= next.Item2)
                      ? next
                      : startPosition;
            startPosition = (startPosition.Item1 <= next.Item1) && (startPosition.Item2 <= next.Item2)
                      ? startPosition
                      : next;

            var segment = new Segment(direction, incline, startPosition, end, wire) { NumOfSteps = numOfSteps};

            startPosition = next;

            return segment;

        }

        private (int, int) MoveWire(string direction, int distance, (int, int) position)
        {
            var (x, y) = position;

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
