namespace DojoTemplateConsoleApp.UserInterface
{
    public interface ICallerInterface
    {
        bool CheckForCall();
        int GetOrigin();
        int GetDestination();
    }
}
