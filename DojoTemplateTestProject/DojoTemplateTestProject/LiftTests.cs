using DojoTemplateConsoleApp;
using FluentAssertions;
using Xunit;

namespace DojoTemplateTestProject
{
    public class LiftTests
    {
        private readonly Lift _sut;

        public LiftTests()
        {
            _sut = new Lift();
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(2, 0)]
        public void Call_NoPassengers_MovesToCaller(int liftFloor, int callFloor)
        {
            var passenger = new Passenger(callFloor, 5);
            _sut.CurrentFloor = liftFloor;
            _sut.Call(passenger);

            _sut.CurrentFloor.Should().Be(callFloor);
            _sut.Passengers.Should().Contain(passenger);
            _sut.CurrentDestination.Should().Be(5);
        }

        [Fact]
        public void Move_ValidDestination_MovesToDestination_RemovesPassenger()
        {
            var passenger = new Passenger(0, 5);
            _sut.Passengers.Add(passenger);

            _sut.Move();

            _sut.CurrentFloor.Should().Be(5);
            _sut.Passengers.Should().BeEmpty();
        }

        [Fact]
        public void Move_DestinationTooHigh_DoesNotMove()
        {
            var passenger = new Passenger(0, 7);
            _sut.Passengers.Add(passenger);

            _sut.Move();

            _sut.CurrentFloor.Should().Be(0);
            _sut.Passengers.Should().BeEmpty();
        }

        [Fact]
        public void Move_DestinationTooLow_DoesNotMove()
        {
            var passenger = new Passenger(0, -2);
            _sut.Passengers.Add(passenger);

            _sut.Move();

            _sut.CurrentFloor.Should().Be(0);
            _sut.Passengers.Should().BeEmpty();
        }
        
        [Fact]
        public void Move_NoPassenger_DoesNotMove()
        {
            _sut.CurrentFloor = 2;
            _sut.Move();

            _sut.CurrentFloor.Should().Be(2);
        }
    }
}
