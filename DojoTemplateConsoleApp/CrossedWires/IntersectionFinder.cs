using System;
using System.Collections.Generic;
using System.Linq;

namespace DojoTemplateConsoleApp.CrossedWires
{
    public class IntersectionFinder
    {
        public List<string> WireOneDirections { get; set; }
        public List<string> WireTwoDirections { get; set; }
        public List<Segment> WireOneSegments { get; set; }
        public List<Segment> WireTwoSegments { get; set; }
        public List<(int, int)> Intersections { get; set; }

        public void FindAllIntersections()
        {
            Intersections = WireOneSegments.SelectMany(s => FindIntersectionsForSegment(s, WireTwoSegments)).ToList();
        }

        private IEnumerable<(int, int)> FindIntersectionsForSegment(Segment segment, List<Segment> wireSegments)
        {
            if (segment.Incline == "H")
            {
                return wireSegments.Where(s => s.Incline == "V")
                                      .Where(s => segment.StartPoint.Item1 <= s.StartPoint.Item1
                                             && s.StartPoint.Item1 <= segment.EndPoint.Item1
                                             && s.StartPoint.Item2 <= segment.StartPoint.Item2
                                             && segment.StartPoint.Item2 < s.EndPoint.Item2)
                                      .Select(s => (s.StartPoint.Item1, segment.StartPoint.Item2));
            }
            else
            {
                return wireSegments.Where(s => s.Incline == "H")
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
