using DojoTemplateConsoleApp;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace DojoTemplateTestProject
{
    public class EngineTests
    {
        private readonly ILift _lift;
        private readonly Engine _sut;

        public EngineTests()
        {
            _lift = Substitute.For<ILift>();
            _sut = new Engine(_lift);
        }

        [Fact]
        public void MoveLift_NoPassengers_CallsLift()
        {
            var caller = new Passenger(0, 3);
            _lift.Passengers.Returns(new List<Passenger>());

            _sut.MoveLift(caller);

            _lift.Received(1).Call(caller);
        }
        
        [Fact]
        public void MoveLift_Passenger_CallerOnWay_CallsLift()
        {
            var caller = new Passenger(0, 3);
            var passengers = new List<Passenger> { new Passenger(-1, 4) };
            _lift.Passengers.Returns(passengers);

            _sut.MoveLift(caller);

            _lift.Received(1).Call(caller);
        }
        
        [Fact]
        public void MoveLift_Passenger_CallerOppositeWay_MovesLift_EnqueuesJob()
        {
            var caller = new Passenger(-1, 3);
            var passengers = new List<Passenger> { new Passenger(0, 4) };
            _lift.Passengers.Returns(passengers);

            _sut.MoveLift(caller);

            _lift.Received(1).Move();
            _sut.JobQueue.Should().Contain(caller);
        }
        
        [Fact]
        public void MoveLift_Passenger_CallerDifferentDirection_MovesLift_EnqueuesJob()
        {
            var caller = new Passenger(2, -1);
            var passengers = new List<Passenger> { new Passenger(1, 4) };
            _lift.Passengers.Returns(passengers);

            _sut.MoveLift(caller);

            _lift.Received(1).Move();
            _sut.JobQueue.Should().Contain(caller);
        }

        [Fact]
        public void MoveLift_NoCaller_MovesLift()
        {
            var passengers = new List<Passenger> { new Passenger(1, 4) };
            _lift.Passengers.Returns(passengers);

            _sut.MoveLift();

            _lift.Received(1).Move();
            _sut.JobQueue.Should().BeEmpty();
        }
    }
}
