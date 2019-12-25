using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using DojoTemplateConsoleApp.CrossedWires;

namespace DojoTemplateTestProject
{
    public class CrossedWiresTests
    {
        [Fact]
        public void InputParserParsesDirectionsToLists()
        {
            var crossedWires = new CrossedWires();
            crossedWires.ParseInput();

            crossedWires.WireOneDirections[0].Should().Be("R992");
            crossedWires.WireTwoDirections[0].Should().Be("L998");

        }

        [Fact]
        public void LoadPathsLoadsPathsToListOfCoordinates()
        {
            var crossedWires = new CrossedWires()
            {
                WireOneDirections = new List<string> { "R8", "U5", "L5", "D3" },
                WireTwoDirections = new List<string> { "U7", "R6", "D4", "L4" }
            };
            var expectedWireOnePath = new List<(int, int)> 
            {
                //(0, 0),
                (8, 0),
                (8, 5),
                (3, 5),
                (3, 2)
            };
            var expectedWireTwoPath = new List<(int, int)> 
            { 
                //(0, 0),
                (0, 7),
                (6, 7),
                (6, 3),
                (2, 3)
            };

            crossedWires.LoadPaths();

            crossedWires.WireOnePath.Should().BeEquivalentTo(expectedWireOnePath);
            crossedWires.WireTwoPath.Should().BeEquivalentTo(expectedWireTwoPath);
        }

        [Fact]
        public void FindIntersectionsFindsCorrectIntersections()
        {

        }

        public void FindClosestIntersectionsFindsIntersectionAtClosestManhattan()
        {

        }
    }
}
