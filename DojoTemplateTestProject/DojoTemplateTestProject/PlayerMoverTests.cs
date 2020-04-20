using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using DojoTemplateConsoleApp;
using DojoTemplateConsoleApp.Model;

namespace DojoTemplateTestProject
{
    public class PlayerMoverTests
    {
        [Theory]
        [InlineData("origin", "destination", 1, 3)]
        [InlineData("middle bit 3", "origin", 2, 1)]
        [InlineData("origin", "destination", 5, 5)]
        public void FindDestinationReturnsCorrectLand(string currentPositionName, string expectedDestinationName, int dice1, int dice2)
        {
            var city = new List<ILand>
                {
                    new Land("Go"),
                    new Land("origin"),
                    new Land("middle bit 1"),
                    new Land("middle bit 2"),
                    new Land("middle bit 3"),
                    new Land("destination")
                };
            var board = new Board(city, new Card[0], new Card[0]);
            var sut = new PlayerMover(board, new OutputRenderer(), new Banker(new OutputRenderer()));
            
            var currentPosition = new Land(currentPositionName);
            var expectedDestination = new Land(expectedDestinationName);

            var destination = sut.FindDestination(currentPosition, (dice1, dice2));

            destination.Should().BeEquivalentTo(expectedDestination);
        }
    }
}
