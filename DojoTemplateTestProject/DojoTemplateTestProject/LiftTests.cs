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
            _sut.NextStop.Should().Be(5);
        }

        [Fact]
        public void Move_ValidDestination_MovesToDestination_RemovesPassenger()
        {
            var passenger = new Passenger(0, 5);
            _sut.Passengers.Add(passenger);

            _sut.Move();

            _sut.CurrentFloor.Should().Be(5);
            _sut.Passengers.Should().BeEmpty();
            _sut.NextStop.Should().Be(0);
        }

        [Fact]
        public void Move_DestinationTooHigh_DoesNotMove()
        {
            var passenger = new Passenger(0, 7);
            _sut.Passengers.Add(passenger);

            _sut.Move();

            _sut.CurrentFloor.Should().Be(0);
            _sut.Passengers.Should().BeEmpty();
            _sut.NextStop.Should().Be(0);
        }

        [Fact]
        public void Move_DestinationTooLow_DoesNotMove()
        {
            var passenger = new Passenger(0, -2);
            _sut.Passengers.Add(passenger);

            _sut.Move();

            _sut.CurrentFloor.Should().Be(0);
            _sut.Passengers.Should().BeEmpty();
            _sut.NextStop.Should().Be(0);
        }
        
        [Fact]
        public void Move_NoPassenger_DoesNotMove()
        {
            _sut.CurrentFloor = 2;
            
            _sut.Move();

            _sut.CurrentFloor.Should().Be(2);
            _sut.NextStop.Should().Be(0);
        }
        
        [Fact]
        public void Move_DestinationSameAsOrigin_DoesNotMove()
        {
            var passenger = new Passenger(2, 2);
            _sut.Passengers.Add(passenger);
            _sut.CurrentFloor = 2;
            
            _sut.Move();

            _sut.CurrentFloor.Should().Be(2);
            _sut.NextStop.Should().Be(0);
            _sut.Passengers.Should().BeEmpty();
        }

        [Fact]
        public void Move_MultiplePassengers_MovesToClosestDestination()
        {
            var passenger1 = new Passenger(0, 5);
            var passenger2 = new Passenger(1, 3);
            var passenger3 = new Passenger(0, 6);
            _sut.Passengers.Add(passenger1);
            _sut.Passengers.Add(passenger2);
            _sut.Passengers.Add(passenger3);

            _sut.Move();

            _sut.CurrentFloor.Should().Be(3);
            _sut.Passengers.Should().Contain(passenger1);
            _sut.Passengers.Should().Contain(passenger3);
            _sut.Passengers.Should().NotContain(passenger2);
            _sut.NextStop.Should().Be(5);
        }
    }
}
