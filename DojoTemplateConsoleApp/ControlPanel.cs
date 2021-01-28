namespace DojoTemplateConsoleApp
{
    internal interface IControlPanel
    {
        bool CheckForNewJob();

    }

    internal class ControlPanel : IControlPanel
    {
        public bool CheckForNewJob()
        {
            throw new System.NotImplementedException();
        }
    }
}