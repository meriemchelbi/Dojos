using DojoTemplateConsoleApp;
using Xunit;

namespace DojoTemplateTestProject.UserInterface
{
    public class ControlPanelTests
    {
        private readonly ControlPanel _sut;

        public ControlPanelTests()
        {
            _sut = new ControlPanel();
        }

        [Fact]
        public void CheckForCaller_NoNewInput_ReturnsNull()
        {

        }

        [Fact]
        public void CheckForCaller_ValidInput_ReturnsValidPassenger()
        {

        }

        [Fact]
        public void CheckForCaller_InvalidInput_ReturnsNull()
        {

        }
    }
}
