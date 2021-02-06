using DojoTemplateConsoleApp;
using DojoTemplateConsoleApp.UserInterface;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DojoTemplateTestProject.UserInterface
{
    public class CallCheckerTests
    {
        private readonly IInputCapturer _inputCapturer;
        private readonly CallChecker _sut;

        public CallCheckerTests()
        {
            _inputCapturer = Substitute.For<IInputCapturer>();
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
        public void CheckForCaller_ValidInput_ReturnsValidPassenger()
        {
            _inputCapturer.CheckForCall().Returns(true);
            _inputCapturer.GetOrigin().Returns(0);
            _inputCapturer.GetDestination().Returns(3);

            var expected = new Passenger(0, 3);

            var result = _sut.CheckForCaller();

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void CheckForCaller_OriginTooLow_ReturnsNull()
        {
            _inputCapturer.CheckForCall().Returns(true);
            _inputCapturer.GetOrigin().Returns(-5);
            _inputCapturer.GetDestination().Returns(3);

            var result = _sut.CheckForCaller();

            result.Should().BeNull();
        }
        
        [Fact]
        public void CheckForCaller_OriginTooHigh_ReturnsNull()
        {
            _inputCapturer.CheckForCall().Returns(true);
            _inputCapturer.GetOrigin().Returns(10);
            _inputCapturer.GetDestination().Returns(3);

            var result = _sut.CheckForCaller();

            result.Should().BeNull();
        }
        
        [Fact]
        public void CheckForCaller_DestinationTooHigh_ReturnsNull()
        {
            _inputCapturer.CheckForCall().Returns(true);
            _inputCapturer.GetOrigin().Returns(2);
            _inputCapturer.GetDestination().Returns(10);

            var result = _sut.CheckForCaller();

            result.Should().BeNull();
        }
        
        [Fact]
        public void CheckForCaller_DestinationTooLow_ReturnsNull()
        {
            _inputCapturer.CheckForCall().Returns(true);
            _inputCapturer.GetOrigin().Returns(2);
            _inputCapturer.GetDestination().Returns(-10);

            var result = _sut.CheckForCaller();

            result.Should().BeNull();
        }
    }
}
