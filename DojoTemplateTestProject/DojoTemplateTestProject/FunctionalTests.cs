using DojoTemplateConsoleApp;
using FluentAssertions;
using Xunit;

namespace DojoTemplateTestProject
{
    public class FunctionalTests
    {
        private readonly ILift _lift;
        private readonly Engine _sut;

        public FunctionalTests()
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
            var passenger1 = new Passenger(0, 5);
            var passenger2 = new Passenger(0, 3);
            _lift.Passengers.Add(passenger1);
            _lift.Passengers.Add(passenger2);
            _lift.CurrentFloor = 2;

            _sut.MoveLift();

            _lift.CurrentFloor.Should().Be(3);
            _lift.Passengers.Should().Contain(passenger1);
            _lift.Passengers.Should().NotContain(passenger2);
        }
        
        [Fact]
        public void NoPassengerInLift_SingleQueuedJob_PicksUpWaitingCaller()
        {
            var queued = new Passenger(4, 6);
            _sut.JobQueue.Enqueue(queued);
            _lift.CurrentFloor = 2;

            _sut.MoveLift();

            _lift.CurrentFloor.Should().Be(4);
            _lift.Passengers.Should().Contain(queued);
            _sut.JobQueue.Should().BeEmpty();
        }
        
        [Fact]
        public void NoPassenger_SingleQueuedJob_CallerOnWayToQueuedSameDirection_PicksUpQueued_EnqueuesNewCaller()
        {
            var queued = new Passenger(4, 6);
            _sut.JobQueue.Enqueue(queued);
            var caller = new Passenger(3, 5);
            _lift.CurrentFloor = 2;

            _sut.MoveLift(caller);

            _lift.CurrentFloor.Should().Be(4);
            _lift.Passengers.Should().Contain(queued);
            _sut.JobQueue.Should().Contain(caller);
        }

        [Fact]
        public void NoPassengerInLift_TwoQueuedJobs_PicksUpFrontOfQueue()
        {
            var queued1 = new Passenger(4, 6);
            var queued2 = new Passenger(3, 5);
            _sut.JobQueue.Enqueue(queued1);
            _sut.JobQueue.Enqueue(queued2);
            _lift.CurrentFloor = 2;

            _sut.MoveLift();

            _lift.CurrentFloor.Should().Be(4);
            _lift.Passengers.Should().Contain(queued1);
            _sut.JobQueue.Should().Contain(queued2);
            _sut.JobQueue.Should().NotContain(queued1);
        }
    }
}
