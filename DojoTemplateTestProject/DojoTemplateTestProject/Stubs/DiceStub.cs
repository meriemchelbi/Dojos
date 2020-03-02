using DojoTemplateConsoleApp;

namespace DojoTemplateTestProject
{
    internal class DiceStub : IRollDice
    {
        public bool IsDouble { get; set; }
        public (int, int) dice;

        public (int, int) RollDice()
        {
            return dice;
        }
    }
}
