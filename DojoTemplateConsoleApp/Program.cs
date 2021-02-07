using DojoTemplateConsoleApp.Model;
using DojoTemplateConsoleApp.UserInterface;

namespace DojoTemplateConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var floorValidator = new FloorValidator();
            var console = new ConsoleWrapper();
            var lift = new Lift();
            var queue = new WaitingPassengers();
            var engine = new Engine(queue, lift);
            var callerInterface = new CallerInterface(console,floorValidator);
            var statusReporter = new LiftStatusReporter(console, queue, lift);
            var callChecker = new CallChecker(callerInterface);

            statusReporter.ReportLiftStatus();
            
            while (true)
            {
                var caller = callChecker.CheckForCaller();
                engine.MoveLift(caller);
                statusReporter.ReportLiftStatus();
            }
        }
    }
}
