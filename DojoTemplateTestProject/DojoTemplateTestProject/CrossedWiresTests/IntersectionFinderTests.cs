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
                    new Segment("R", "H", (0, 0), (8, 0), 1),
                    new Segment("U", "V", (8, 0), (8, 5), 1),
                    new Segment("L", "H", (3, 5), (8, 5), 1),
                    new Segment("D", "V", (3, 2), (3, 5), 1)
                },
                WireTwoSegments = new List<Segment>
                {
                    new Segment("U", "V", (0, 0), (0, 7), 2),
                    new Segment("R", "H", (0, 7), (6, 7), 2),
                    new Segment("D", "V", (6, 3), (6, 7), 2),
                    new Segment("L", "H", (2, 3), (6, 3), 2)
                }
        };
            var expectedIntersections = new List<Intersection>
                {
                    new Intersection()
                    {
                        Coordinates = (0, 0),
                        OverlappingSegmentW1 = new Segment("R", "H", (0, 0), (8, 0), 1),
                        OverlappingSegmentW2 = new Segment("U", "V", (0, 0), (0, 7), 2)
                    },
                    new Intersection()
                    {
                        Coordinates = (3, 3),
                        OverlappingSegmentW1 = new Segment("D", "V", (3, 2), (3, 5), 1),
                        OverlappingSegmentW2 = new Segment("L", "H", (2, 3), (6, 3), 2)
                    },
                    new Intersection()
                    { 
                        Coordinates = (6, 5),
                        OverlappingSegmentW1 = new Segment("L", "H", (3, 5), (8, 5), 1),
                        OverlappingSegmentW2 = new Segment("D", "V", (6, 3), (6, 7), 2)
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

        [Fact]
        public void CalculateStepsToAllIntersectionsReturnsCorrectSteps()
        {
            var intersectionFinder = new IntersectionFinder();
            intersectionFinder.Intersections = new List<Intersection>()
            {
                    new Intersection()
                    {
                        Coordinates = (0, 0),
                        OverlappingSegmentW1 = new Segment("R", "H", (0, 0), (8, 0), 1) { NumOfSteps = 8 },
                        OverlappingSegmentW2 = new Segment("U", "V", (0, 0), (0, 7), 2) { NumOfSteps = 7 }
                    },
                    new Intersection()
                    {
                        Coordinates = (3, 3),
                        OverlappingSegmentW1 = new Segment("D", "V", (3, 2), (3, 5), 1) { NumOfSteps = 3 },
                        OverlappingSegmentW2 = new Segment("L", "H", (2, 3), (6, 3), 2) { NumOfSteps = 4 }
                    },
                    new Intersection()
                    {
                        Coordinates = (6, 5),
                        OverlappingSegmentW1 = new Segment("L", "H", (3, 5), (8, 5), 1) { NumOfSteps = 5 },
                        OverlappingSegmentW2 = new Segment("D", "V", (6, 3), (6, 7), 2) { NumOfSteps = 4 }
                    }
            };
            intersectionFinder.WireOneSegments = new List<Segment>
            {
                new Segment("R", "H", (0, 0), (8, 0), 1) { NumOfSteps = 8 },
                new Segment("U", "V", (8, 0), (8, 5), 1) { NumOfSteps = 5 },
                new Segment("L", "H", (3, 5), (8, 5), 1) { NumOfSteps = 5 },
                new Segment("D", "V", (3, 2), (3, 5), 1) { NumOfSteps = 3 }
            };
            intersectionFinder.WireTwoSegments = new List<Segment>
            {
                new Segment("U", "V", (0, 0), (0, 7), 2) { NumOfSteps = 7 },
                new Segment("R", "H", (0, 7), (6, 7), 2) { NumOfSteps = 6 },
                new Segment("D", "V", (6, 3), (6, 7), 2) { NumOfSteps = 4 },
                new Segment("L", "H", (2, 3), (6, 3), 2) { NumOfSteps = 4 }
            };
            var expectedIntersections = new List<Intersection>()
            {
                    new Intersection()
                    {
                        Coordinates = (0, 0),
                        OverlappingSegmentW1 = new Segment("R", "H", (0, 0), (8, 0), 1) { NumOfSteps = 8 },
                        OverlappingSegmentW2 = new Segment("U", "V", (0, 0), (0, 7), 2) { NumOfSteps = 7 },
                        StepsToIntersectionW1 = 0,
                        StepsToIntersectionW2 = 0
                    },
                    new Intersection()
                    {
                        Coordinates = (3, 3),
                        OverlappingSegmentW1 = new Segment("D", "V", (3, 2), (3, 5), 1) { NumOfSteps = 3 },
                        OverlappingSegmentW2 = new Segment("L", "H", (2, 3), (6, 3), 2) { NumOfSteps = 4 },
                        StepsToIntersectionW1 = 20,
                        StepsToIntersectionW2 = 20
                    },
                    new Intersection()
                    {
                        Coordinates = (6, 5),
                        OverlappingSegmentW1 = new Segment("L", "H", (3, 5), (8, 5), 1) { NumOfSteps = 5 },
                        OverlappingSegmentW2 = new Segment("D", "V", (6, 3), (6, 7), 2) { NumOfSteps = 4 },
                        StepsToIntersectionW1 = 15,
                        StepsToIntersectionW2 = 15
                    }
            };
            intersectionFinder.CalculateStepsToAllIntersections();

            intersectionFinder.Intersections.Should().BeEquivalentTo(expectedIntersections);
        }
        
        [Theory]
        [InlineData("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        [InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void Part1TestEndToEnd(string wireOneInput, string wireTwoInput, int shortestDistance)
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
