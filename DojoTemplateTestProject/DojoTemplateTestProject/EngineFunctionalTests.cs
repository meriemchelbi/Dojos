using DojoTemplateConsoleApp;
using FluentAssertions;
using Xunit;

namespace DojoTemplateTestProject
{
    public class EngineFunctionalTests
    {
        private readonly ILift _lift;
        private readonly Engine _sut;

        public EngineFunctionalTests()
        {
            _lift = new Lift();
            _sut = new Engine(_lift);
        }

        [Fact]
        public void NoPassengerInLift_MovesLiftToCaller()
        {
            var passenger = new Passenger(0, 5);
            _lift.CurrentFloor = 2;
            _sut.MoveLift(passenger);

            _lift.CurrentFloor.Should().Be(0);
            _lift.Passengers.Should().Contain(passenger);
        }
        
        [Fact]
        public void PassengerInLift_CallerOnWay_GoingSameDirection_MovesLiftToNewCaller()
        {
            var passenger = new Passenger(0, 5);
            var caller = new Passenger(3, 6);
            _lift.Passengers.Add(passenger);
            _lift.CurrentFloor = 0;

            _sut.MoveLift(caller);

            _lift.CurrentFloor.Should().Be(3);
            _lift.Passengers.Should().Contain(caller);
        }
        
        [Fact]
        public void PassengerInLift_CallerNotOnWay_GoingSameDirection_MovesLiftToPassengerDestination()
        {
            var passenger = new Passenger(0, 5);
            var caller = new Passenger(-1, 6);
            _lift.Passengers.Add(passenger);
            _lift.CurrentFloor = 0;

            _sut.MoveLift(caller);

            _lift.CurrentFloor.Should().Be(5);
            _lift.Passengers.Should().NotContain(passenger);
            _lift.Passengers.Should().NotContain(caller);
            _sut.JobQueue.Should().Contain(caller);
        }
        
        [Fact]
        public void PassengerInLift_CallerGoingDifferentDirection_MovesLiftToPassengerDestination()
        {
            var passenger = new Passenger(0, 5);
            var caller = new Passenger(3, -1);
            _lift.Passengers.Add(passenger);
            _lift.CurrentFloor = 0;

            _sut.MoveLift(caller);

            _lift.CurrentFloor.Should().Be(5);
            _lift.Passengers.Should().NotContain(passenger);
            _lift.Passengers.Should().NotContain(caller);
            _sut.JobQueue.Should().Contain(caller);
        }

        [Fact]
        public void TwoPassengersInLift_MovesLiftToClosestPassengerDestination()
        {

        }
        
        [Fact]
        public void NoPassengerInLift_SingleQueuedJob_PicksUpWaitingCaller()
        {

        }
        
        [Fact]
        public void NoPassengerInLift_SingleQueuedJob_OneNewCallerOnWayToQueued_PicksUpNewCaller()
        {

        }
        
        [Fact]
        public void NoPassengerInLift_SingleQueuedJob_NewCaller_GoingSameDirectionAsQueued_PicksUpNewCaller()
        {

        }
        
        [Fact]
        public void NoPassengerInLift_SingleQueuedJob_NewCaller_GoingDifferentDirectionToQueued_PicksUpQueued()
        {

        }
        
        [Fact]
        public void NoPassengerInLift_TwoQueuedJobs_PicksUpClosestCaller()
        {

        }
    }
}
