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
        public List<Intersection> Intersections { get; set; }

        public void FindAllIntersections()
        {
            Intersections = WireOneSegments.SelectMany(s => FindIntersectionsForSegment(s, WireTwoSegments)).ToList();
        }

        private IEnumerable<Intersection> FindIntersectionsForSegment(Segment segment, List<Segment> wireSegments)
        {
            if (segment.Incline == "H")
            {
                return wireSegments.Where(s => s.Incline == "V")
                                      .Where(s => segment.StartPoint.Item1 <= s.StartPoint.Item1
                                             && s.StartPoint.Item1 <= segment.EndPoint.Item1
                                             && s.StartPoint.Item2 <= segment.StartPoint.Item2
                                             && segment.StartPoint.Item2 < s.EndPoint.Item2)
                                      .Select(s => new Intersection()
                                      {
                                          Coordinates = (s.StartPoint.Item1, segment.StartPoint.Item2),
                                          OverlappingSegmentW1 = segment,
                                          OverlappingSegmentW2 = s
                                      });
            }
            else
            {
                return wireSegments.Where(s => s.Incline == "H")
                                      .Where(s => segment.StartPoint.Item2 <= s.StartPoint.Item2
                                            && s.StartPoint.Item2 <= segment.EndPoint.Item2
                                            && s.StartPoint.Item1 <= segment.StartPoint.Item1
                                            && segment.StartPoint.Item1 < s.EndPoint.Item1)
                                      .Select(s => new Intersection()
                                      {
                                          Coordinates= (segment.StartPoint.Item1, s.StartPoint.Item2),
                                          OverlappingSegmentW1 = segment,
                                          OverlappingSegmentW2 = s
                                      });
            }
        }

        public int FindClosestIntersection()
        {
            var lowestTotal = int.MaxValue;

            foreach (var intersection in Intersections)
            {
                var distance = Math.Abs(intersection.Coordinates.Item1) + Math.Abs(intersection.Coordinates.Item2);
                if (distance < lowestTotal && distance != 0)
                {
                    lowestTotal = distance;
                };
            }

            return lowestTotal;
        }
    }
}
