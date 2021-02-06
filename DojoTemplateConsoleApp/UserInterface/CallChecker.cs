using DojoTemplateConsoleApp.UserInterface;

namespace DojoTemplateConsoleApp
{
    public class CallChecker : ICallChecker
    {
        private readonly IInputCapturer _inputCapturer;

        public CallChecker(IInputCapturer inputCapturer)
        {
            _inputCapturer = inputCapturer;
        }

        public Passenger CheckForCaller()
        {
            var isNewCaller = _inputCapturer.CheckForCall();

            if (!isNewCaller)
                return null;

            var callerOrigin = _inputCapturer.GetOrigin();
            var callerDestination = _inputCapturer.GetDestination();

            return new Passenger(callerOrigin, callerDestination);
        }
    }
}