using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using DojoTemplateConsoleApp.CrossedWires;
using System.Linq;

namespace DojoTemplateTestProject.CrossedWiresTests
{
    public class IntersectionFinderTests
    {
        [Fact]
        public void FindIntersectionsWithSegmentsFindsCorrectIntersections()
        {
            var crossedWires = new IntersectionFinder()
            {
                WireOneSegments = new List<Segment>
                {
                    new Segment("R", "H", (0, 0), (8, 0)),
                    new Segment("U", "V", (8, 0), (8, 5)),
                    new Segment("L", "H", (3, 5), (8, 5)),
                    new Segment("D", "V", (3, 2), (3, 5))
                },
                WireTwoSegments = new List<Segment>
                {
                    new Segment("U", "V", (0, 0), (0, 7)),
                    new Segment("R", "H", (0, 7), (6, 7)),
                    new Segment("D", "V", (6, 3), (6, 7)),
                    new Segment("L", "H", (2, 3), (6, 3))
                }
        };

            var expectedIntersections = new List<Intersection>
                {
                    new Intersection()
                    {
                        Coordinates = (0, 0),
                        OverlappingSegmentW1 = new Segment("R", "H", (0, 0), (8, 0)),
                        OverlappingSegmentW2 = new Segment("U", "V", (0, 0), (0, 7))
                    },
                    new Intersection()
                    {
                        Coordinates = (3, 3),
                        OverlappingSegmentW1 = new Segment("D", "V", (3, 2), (3, 5)),
                        OverlappingSegmentW2 = new Segment("L", "H", (2, 3), (6, 3))
                    },
                    new Intersection()
                    { 
                        Coordinates = (6, 5),
                        OverlappingSegmentW1 = new Segment("L", "H", (3, 5), (8, 5)),
                        OverlappingSegmentW2 = new Segment("D", "V", (6, 3), (6, 7))
                    }
                };

            crossedWires.FindAllIntersections();

            crossedWires.Intersections.Should().BeEquivalentTo(expectedIntersections);
        }

        [Fact]
        public void FindClosestIntersectionReturnsShortestDistance()
        {
            var crossedWires = new IntersectionFinder()
            {
                Intersections = new List<Intersection>
                {
                    new Intersection(){ Coordinates = (0, 0) },
                    new Intersection(){ Coordinates = (3, 3) },
                    new Intersection(){ Coordinates = (6, 5) }
                }
            };

            var result = crossedWires.FindClosestIntersection();

            result.Should().Be(6);
        }

        [Theory]
        [InlineData("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        [InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void TestEndToEnd(string wireOneInput, string wireTwoInput, int shortestDistance)
        {
            var crossedWires = new IntersectionFinder();
            var segmentFactory = new SegmentFactory(crossedWires);
            crossedWires.WireOneDirections = wireOneInput.Split(",").ToList();
            crossedWires.WireTwoDirections = wireTwoInput.Split(",").ToList();

            segmentFactory.LoadSegments();
            crossedWires.FindAllIntersections();
            var result = crossedWires.FindClosestIntersection();

            result.Should().Be(shortestDistance);
        }
    }
}
