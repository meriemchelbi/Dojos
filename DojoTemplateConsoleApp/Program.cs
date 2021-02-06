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
            var engine = new Engine(lift);
            var callerInterface = new CallerInterface(console,floorValidator);
            var controlPanel = new CallChecker(callerInterface);

            while (true)
            {
                var caller = controlPanel.CheckForCaller();
                engine.MoveLift(caller);
            }
        }
    }
}
