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

        public void CalculateStepsToAllIntersections()
        {
            Intersections.ForEach(i => CalculateStepsToIntersection(i));
        }

        private void CalculateStepsToIntersection(Intersection intersection)
        {
            intersection.StepsToIntersectionW1 = CalculateStepsForSegment(intersection.OverlappingSegmentW1, intersection.Coordinates);

            intersection.StepsToIntersectionW2 = CalculateStepsForSegment(intersection.OverlappingSegmentW2, intersection.Coordinates);

        }

        private int CalculateStepsForSegment(Segment segment, (int, int) intersectionCoordinates)
        {
            var total = 0;
            var wireSegments = new List<Segment>();

            switch (segment.Wire)
            {
                case 1:
                    wireSegments = WireOneSegments;
                    break;
                case 2:
                    wireSegments = WireTwoSegments;
                    break;
                default:
                    break;
            }

            foreach (var currentSegment in wireSegments)
            {
                if (!currentSegment.Equals(segment))
                {
                    total += currentSegment.NumOfSteps;
                }
                else break;
            }

            switch (segment.Direction)
            {
                case "U":
                    total += Math.Abs(intersectionCoordinates.Item2 - segment.StartPoint.Item2);
                    break;
                case "D":
                    total += Math.Abs(intersectionCoordinates.Item2 - segment.EndPoint.Item2);
                    break;
                case "L":
                    total += Math.Abs(intersectionCoordinates.Item1 - segment.EndPoint.Item1);
                    break;
                case "R":
                    total += Math.Abs(intersectionCoordinates.Item1 - segment.StartPoint.Item1);
                    break;
                default:
                    break;
            }

            return total;
        }

        public int FindShortestDistanceToIntersection()
        {
            var result = int.MaxValue;

            foreach (var intersection in Intersections)
            {
                var totalSteps = intersection.StepsToIntersectionW1 + intersection.StepsToIntersectionW2;

                result = (totalSteps < result && totalSteps != 0)
                    ? totalSteps
                    : result;
            }

            return result;
        }
    }
}
