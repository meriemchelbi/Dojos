using DojoTemplateConsoleApp;
using DojoTemplateConsoleApp.UserInterface;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DojoTemplateTestProject.UserInterface
{
    public class CallerInterfaceTests
    {
        private readonly ICallerInterface _sut;
        private readonly IFloorValidator _floorValidator;
        private readonly IConsole _console;

        public CallerInterfaceTests()
        {
            _floorValidator = Substitute.For<IFloorValidator>();
            _console = Substitute.For<IConsole>();
            _sut = new CallerInterface(_console, _floorValidator);
        }

        [Fact]
        public void CheckForCall_ValidYesInput_ReturnsTrue()
        {
            _console.ReadLine().Returns("y");

            var result = _sut.CheckForCall();

            result.Should().BeTrue();
        }

        [Fact]
        public void CheckForCall_ValidNoInput_ReturnsFalse()
        {
            _console.ReadLine().Returns("N");

            var result = _sut.CheckForCall();

            result.Should().BeFalse();
        }

        [Fact]
        public void CheckForCall_InvalidInput_ReturnsFalse()
        {
            _console.ReadLine().Returns("wibble");

            var result = _sut.CheckForCall();

            result.Should().BeFalse();
        }

        [Fact]
        public void GetOrigin_ValidFloor_ReturnsFloor()
        {
            _console.ReadLine().Returns("3");
            _floorValidator.ValidateFloor(3).Returns(true);

            var result = _sut.GetOrigin();

            result.Should().Be(3);
        }

        [Fact]
        public void GetDestination_ValidFloor_ReturnsFloor()
        {
            _console.ReadLine().Returns("3");
            _floorValidator.ValidateFloor(3).Returns(true);

            var result = _sut.GetOrigin();

            result.Should().Be(3);
        }
    }
}
