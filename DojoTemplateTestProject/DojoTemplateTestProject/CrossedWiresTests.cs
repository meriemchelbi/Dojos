using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using DojoTemplateConsoleApp.CrossedWires;
using System.Linq;

namespace DojoTemplateTestProject
{
    public class CrossedWiresTests
    {
        [Fact]
        public void InputParserParsesDirectionsToLists()
        {
            var crossedWires = new CrossedWiresFinder();
            crossedWires.ParseInput();

            crossedWires.WireOneDirections[0].Should().Be("R992");
            crossedWires.WireTwoDirections[0].Should().Be("L998");

        }

        [Fact]
        public void LoadPointsLoadsPointsToListOfCoordinates()
        {
            var crossedWires = new CrossedWiresFinder()
            {
                WireOneDirections = new List<string> { "R8", "U5", "L5", "D3" },
                WireTwoDirections = new List<string> { "U7", "R6", "D4", "L4" }
            };
            var expectedWireOnePath = new List<(int, int)> 
            {
                (8, 0),
                (8, 5),
                (3, 5),
                (3, 2)
            };
            var expectedWireTwoPath = new List<(int, int)> 
            { 
                (0, 7),
                (6, 7),
                (6, 3),
                (2, 3)
            };

            crossedWires.LoadPoints();

            crossedWires.WireOnePoints.Should().BeEquivalentTo(expectedWireOnePath);
            crossedWires.WireTwoPoints.Should().BeEquivalentTo(expectedWireTwoPath);
        }
        
        [Fact]
        public void LoadSegmentsLoadsSegmentsToCorrectList()
        {
            var crossedWires = new CrossedWiresFinder()
            {
                WireOneDirections = new List<string> { "R8", "U5", "L5", "D3" },
                WireTwoDirections = new List<string> { "U7", "R6", "D4", "L4" }
            };
            var expectedWireOneSegments = new List<Segment>
            {
                new Segment("R", "H", (0, 0), (8, 0)),
                new Segment("U", "V", (8, 0), (8, 5)),
                new Segment("L", "H", (3, 5), (8, 5)),
                new Segment("D", "V", (3, 2), (3, 5))
            };
            var expectedWireTwoSegments = new List<Segment> 
            {
                new Segment("U", "V", (0, 0), (0, 7)),
                new Segment("R", "H", (0, 7), (6, 7)),
                new Segment("D", "V", (6, 3), (6, 7)),
                new Segment("L", "H", (2, 3), (6, 3))
            };

            crossedWires.LoadSegments();

            crossedWires.WireOneSegments.Should().BeEquivalentTo(expectedWireOneSegments);
            crossedWires.WireTwoSegments.Should().BeEquivalentTo(expectedWireTwoSegments);
        }

        [Fact]
        public void FindIntersectionsFindsCorrectIntersections()
        {
            var crossedWires = new CrossedWiresFinder()
            {
                WireOnePoints = new List<(int, int)>
                {
                    (8, 0),
                    (8, 5),
                    (3, 5),
                    (3, 2)
                },
                WireTwoPoints = new List<(int, int)>
                {
                    (0, 7),
                    (6, 7),
                    (6, 3),
                    (2, 3)
                }
            };

            var expectedIntersections = new List<(int, int)>
            {
                (3, 3),
                (6, 5)
            };

            crossedWires.FindIntersections();

            crossedWires.Intersections.Should().BeEquivalentTo(expectedIntersections);
        }

        [Fact]
        public void FindClosestIntersectionReturnsShortestDistance()
        {
            var crossedWires = new CrossedWiresFinder()
            {
                Intersections = new List<(int, int)>
                {
                    (3, 3),
                    (6, 5)
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
            var crossedWires = new CrossedWiresFinder();
            crossedWires.WireOneDirections = wireOneInput.Split(",").ToList();
            crossedWires.WireTwoDirections = wireTwoInput.Split(",").ToList();

            crossedWires.LoadPoints();
            crossedWires.FindIntersections();
            var result = crossedWires.FindClosestIntersection();

            result.Should().Be(shortestDistance);
        }
    }
}
