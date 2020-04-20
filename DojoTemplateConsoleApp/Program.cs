namespace DojoTemplateConsoleApp
{
    class Program
    {
        static void Main()
        {
            var diceRoller = new DiceRoller();
            var renderer = new OutputRenderer();
            var playerSelector = new PlayerSelector();
            var game = new Game(diceRoller, playerSelector, renderer, "Tarquin");

            while (true)
            {
                game.TakeTurn();
            }
        }
    }
}
