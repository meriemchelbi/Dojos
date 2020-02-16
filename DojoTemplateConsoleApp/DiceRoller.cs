using System;

namespace DojoTemplateConsoleApp
{
    public class DiceRoller : IRollDice
    {
        public bool IsDouble { get; private set; }

        public (int, int) RollDice()
        {
            var random = new Random();
            var dice1 = random.Next(0, 6);
            var dice2 = random.Next(0, 6);

            IsDouble = dice1 == dice2;

            return (dice1, dice2);
        }
    }
}
