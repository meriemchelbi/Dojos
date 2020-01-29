using DojoTemplateConsoleApp;
using FluentAssertions;
using System;
using Xunit;

namespace DojoTemplateTestProject
{
    public class LiftTests
    {
        [Theory]
        [InlineData(0, Direction.Up, 1)]
        [InlineData(10, Direction.Up, 10)]
        [InlineData(3, Direction.Down, 2)]
        [InlineData(0, Direction.Down, 0)]
        public void MoveUpdatesCurrentFloorAccordingToDirection(int currentFloor, Direction direction, int expectedResult)
        {
            var lift = new Lift(10)
            {
                CurrentFloor = currentFloor,
                Direction = direction
            };

            lift.Move();

            lift.CurrentFloor.Should().Be(expectedResult);
        }

        public void DirectionResetsToUpWhenLiftHitsGroundFloor()
        {

        }
        
        public void DirectionResetsToDownWhenLiftHitsTopFloor()
        {

        }
    }
}
