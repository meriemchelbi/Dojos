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

            // TODO add floor validator
            // TODO move validation to InputCapturer
            if (callerOrigin < -1 || callerOrigin > 6)
                return null;

            var callerDestination = _inputCapturer.GetDestination();

            if (callerDestination < -1 || callerDestination > 6)
                return null;

            return new Passenger(callerOrigin, callerDestination);
        }
    }
}