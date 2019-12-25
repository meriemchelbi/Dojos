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

            crossedWires.wireOneDirections[0].Should().Be("R992");
            crossedWires.wireTwoDirections[0].Should().Be("L998");

        }

        [Fact]
        public void LoadPathsLoadsPathsToListOfCoordinates()
        {

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
