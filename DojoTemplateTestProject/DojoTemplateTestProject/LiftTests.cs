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
        public void CallLift_MovesLift_ToCaller(int liftFloor, int callFloor)
        {
            var passenger = new Passenger(callFloor, 5);
            _sut.CurrentFloor = liftFloor;
            _sut.Call(passenger);

            _sut.CurrentFloor.Should().Be(callFloor);
            _sut.Passengers.Should().Contain(passenger);
        }

        [Fact]
        public void MoveLift_ValidDestination_MovesToDestination()
        {
            _sut.Move(5);

            _sut.CurrentFloor.Should().Be(5);
        }

        [Fact]
        public void MoveLift_DestinationTooHigh_DoesNotMove()
        {
            _sut.Move(7);

            _sut.CurrentFloor.Should().Be(0);
        }

        [Fact]
        public void MoveLift_DestinationTooLow_DoesNotMove()
        {
            _sut.Move(-2);

            _sut.CurrentFloor.Should().Be(0);
        }
    }
}
