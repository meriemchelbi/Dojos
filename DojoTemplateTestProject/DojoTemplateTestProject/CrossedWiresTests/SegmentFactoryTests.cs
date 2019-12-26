using DojoTemplateConsoleApp.CrossedWires;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace DojoTemplateTestProject.CrossedWiresTests
{
    public class SegmentFactoryTests
    {
        [Fact]
        public void InputParserParsesDirectionsToLists()
        {
            var crossedWires = new IntersectionFinder();
            var segmentFactory = new SegmentFactory(crossedWires);
            segmentFactory.ParseInput();

            crossedWires.WireOneDirections[0].Should().Be("R992");
            crossedWires.WireTwoDirections[0].Should().Be("L998");

        }

        [Fact]
        public void LoadSegmentsLoadsSegmentsToCorrectList()
        {
            var crossedWires = new IntersectionFinder()
            {
                WireOneDirections = new List<string> { "R8", "U5", "L5", "D3" },
                WireTwoDirections = new List<string> { "U7", "R6", "D4", "L4" }
            };
            var segmentFactory = new SegmentFactory(crossedWires);
            var expectedWireOneSegments = new List<Segment>
            {
                new Segment("R", "H", (0, 0), (8, 0)) { NumOfSteps = 8 },
                new Segment("U", "V", (8, 0), (8, 5)) { NumOfSteps = 5 },
                new Segment("L", "H", (3, 5), (8, 5)) { NumOfSteps = 5 },
                new Segment("D", "V", (3, 2), (3, 5)) { NumOfSteps = 3 }
            };
            var expectedWireTwoSegments = new List<Segment>
            {
                new Segment("U", "V", (0, 0), (0, 7)) { NumOfSteps = 7 },
                new Segment("R", "H", (0, 7), (6, 7)) { NumOfSteps = 6 },
                new Segment("D", "V", (6, 3), (6, 7)) { NumOfSteps = 4 },
                new Segment("L", "H", (2, 3), (6, 3)) { NumOfSteps = 4 }
            };

            segmentFactory.LoadSegments();

            crossedWires.WireOneSegments.Should().BeEquivalentTo(expectedWireOneSegments);
            crossedWires.WireTwoSegments.Should().BeEquivalentTo(expectedWireTwoSegments);
        }
    }
}
