using DojoTemplateConsoleApp.UserInterface;

namespace DojoTemplateConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var lift = new Lift();
            var engine = new Engine(lift);
            var inputCapturer = new InputCapturer();
            var controlPanel = new CallChecker(inputCapturer);

            while (true)
            {
                var caller = controlPanel.CheckForCaller();
                engine.MoveLift(caller);
            }
        }
    }
}
