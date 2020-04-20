namespace DojoTemplateConsoleApp
{
    public interface IRollDice
    {
        public bool IsDouble { get; }
        (int, int) RollDice();
    }
}
