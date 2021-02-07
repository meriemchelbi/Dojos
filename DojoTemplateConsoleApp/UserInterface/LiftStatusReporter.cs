using DojoTemplateConsoleApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace DojoTemplateConsoleApp.UserInterface
{
    public class LiftStatusReporter : ILiftStatusReporter
    {
        private readonly IConsole _console;
        private readonly WaitingPassengers _waiting;
        private readonly IEnumerable<ILift> _lifts;

        public LiftStatusReporter(IConsole console,
                                  WaitingPassengers waiting,
                                  params ILift[] lifts)
        {
            _console = console;
            _waiting = waiting;
            _lifts = lifts;
        }

        public void ReportLiftStatus()
        {
            var lift = _lifts.FirstOrDefault();

            _console.WriteLine(lift.ToString());
            _console.WriteLine(_waiting.ToString());
        }
    }
}
