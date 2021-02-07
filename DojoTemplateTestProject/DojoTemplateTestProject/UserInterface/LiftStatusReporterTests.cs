using DojoTemplateConsoleApp;
using DojoTemplateConsoleApp.Model;
using DojoTemplateConsoleApp.UserInterface;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace DojoTemplateTestProject.UserInterface
{
    public class LiftStatusReporterTests
    {
        private readonly ILift _lift;
        private readonly IConsole _console;
        private readonly WaitingPassengers _waiting;
        private readonly LiftStatusReporter _sut;

        public LiftStatusReporterTests()
        {
            _lift = Substitute.For<ILift>();
            _console = Substitute.For<IConsole>();
            _waiting = new WaitingPassengers();
            _sut = new LiftStatusReporter(_console, _waiting, _lift);
        }

        [Fact]
        public void ReportLiftStatus_CallsConsole()
        {
            _sut.ReportLiftStatus();

            _console.Received(1).WriteLine(_lift.ToString());
            _lift.Received(1).ToString();
        }
    }
}
