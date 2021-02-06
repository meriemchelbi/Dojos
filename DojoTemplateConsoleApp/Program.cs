using DojoTemplateConsoleApp.UserInterface;

namespace DojoTemplateConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var floorValidator = new FloorValidator();
            var lift = new Lift();
            var engine = new Engine(lift);
            var inputCapturer = new CallerInterface(floorValidator);
            var controlPanel = new CallChecker(inputCapturer);

            while (true)
            {
                var caller = controlPanel.CheckForCaller();
                engine.MoveLift(caller);
            }
        }
    }
}
