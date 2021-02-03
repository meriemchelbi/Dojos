namespace DojoTemplateConsoleApp.UserInterface
{
    public interface IInputCapturer
    {
        bool CheckForCall();
        int GetOrigin();
        int GetDestination();
    }
}
