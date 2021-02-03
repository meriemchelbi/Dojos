using DojoTemplateConsoleApp.UserInterface;

namespace DojoTemplateConsoleApp
{
    public class ControlPanel : IControlPanel
    {
        private readonly IInputCapturer _inputCapturer;

        public ControlPanel(IInputCapturer inputCapturer)
        {
            _inputCapturer = inputCapturer;
        }

        public Passenger CheckForCaller()
        {
            throw new System.NotImplementedException();
        }
    }
}