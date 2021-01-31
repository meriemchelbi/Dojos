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
    }
}
