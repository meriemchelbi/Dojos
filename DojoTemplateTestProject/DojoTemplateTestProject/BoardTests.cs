using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using DojoTemplateConsoleApp.BoardProperties;

namespace DojoTemplateTestProject
{
    public class BoardTests
    {
        [Theory]
        [InlineData("origin", "destination", 1, 3)]
        [InlineData("middle bit 3", "origin", 2, 1)]
        [InlineData("origin", "destination", 5, 5)]
        public void FindDestinationReturnsCorrectLand(string currentPositionName, string expectedDestinationName, int dice1, int dice2)
        {
            var sut = new Board()
            {
                City = new List<ILand>
                {
                    new Land("Go"),
                    new Land("origin"),
                    new Land("middle bit 1"),
                    new Land("middle bit 2"),
                    new Land("middle bit 3"),
                    new Land("destination")
                }
            };
            
            var currentPosition = new Land(currentPositionName);
            var expectedDestination = new Land(expectedDestinationName);

            var destination = sut.FindDestination(currentPosition, (dice1, dice2));

            destination.Should().BeEquivalentTo(expectedDestination);
        }
    }
}
