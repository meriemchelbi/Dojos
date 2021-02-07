using DojoTemplateConsoleApp;
using DojoTemplateConsoleApp.Model;
using DojoTemplateConsoleApp.UserInterface;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DojoTemplateTestProject.UserInterface
{
    public class CallCheckerTests
    {
        private readonly ICallerInterface _inputCapturer;
        private readonly CallChecker _sut;

        public CallCheckerTests()
        {
            _inputCapturer = Substitute.For<ICallerInterface>();
            _sut = new CallChecker(_inputCapturer);
        }

        [Fact]
        public void CheckForCaller_NoNewInput_ReturnsNull()
        {
            _inputCapturer.CheckForCall().Returns(false);

            var result = _sut.CheckForCaller();

            result.Should().BeNull();
        }

        [Fact]
        public void CheckForCaller_ReturnsValidPassenger()
        {
            _inputCapturer.CheckForCall().Returns(true);
            _inputCapturer.GetOrigin().Returns(0);
            _inputCapturer.GetDestination().Returns(3);

            var expected = new Passenger(0, 3);

            var result = _sut.CheckForCaller();

            result.Should().BeEquivalentTo(expected);
        }
    }
}
