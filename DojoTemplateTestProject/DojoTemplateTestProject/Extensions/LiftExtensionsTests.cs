using DojoTemplateConsoleApp;
using DojoTemplateConsoleApp.Extensions;
using FluentAssertions;
using Xunit;

namespace DojoTemplateTestProject.Extensions
{
    public class LiftExtensionsTests
    {
        [Theory]
        [InlineData(3, 5)]
        [InlineData(1, -1)]
        public void CallerOnWay_CallerInOppositeDirection_ReturnsFalse(int currentFloor, int destination)
        {
            var lift = new Lift
            {
                CurrentFloor = currentFloor,
                CurrentDestination = destination
            };
            var caller = new Passenger(2, 5);

            var result = lift.CallerOnWay(caller);

            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(3, 5)]
        [InlineData(3, 6)]
        public void CallerOnWay_CallerInSameDirection_ReturnsTrue(int callerOrigin, int callerDestination)
        {
            var lift = new Lift
            {
                CurrentFloor = 1,
                CurrentDestination = 5
            };
            var caller = new Passenger(callerOrigin, callerDestination);

            var result = lift.CallerOnWay(caller);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(2, 5, 1, 5)]
        [InlineData(4, -1, 5, 0)]
        public void GoingSameDirection_CallerSameDirectionAsLift_ReturnsTrue(int callerOrigin,
                                                                             int callerDestination,
                                                                             int currentFloor,
                                                                             int currentDestination)
        {
            var caller = new Passenger(callerOrigin, callerDestination);
            var lift = new Lift
            {
                CurrentFloor = currentFloor,
                CurrentDestination = currentDestination
            };

            var result = lift.GoingSameDirection(caller);

            result.Should().BeTrue();
        }
        
        [Theory]
        [InlineData(2, 5, 5, 0)]
        [InlineData(4, -1, 1, 5)]
        public void GoingSameDirection_CallerDifferentDirectionToLift_ReturnsFalse(int callerOrigin,
                                                                             int callerDestination,
                                                                             int currentFloor,
                                                                             int currentDestination)
        {
            var caller = new Passenger(callerOrigin, callerDestination);
            var lift = new Lift
            {
                CurrentFloor = currentFloor,
                CurrentDestination = currentDestination
            };

            var result = lift.GoingSameDirection(caller);

            result.Should().BeFalse();
        }
    }
}
