using DojoTemplateConsoleApp;
using System;
using Xunit;

namespace DojoTemplateTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void PopulateBoardPopulates()
        {
            var dice = new DiceStub();
            var game = new Game(dice, "Tarquin");
            var endPosition = game.Players[0].Position;

            dice.dice = (1, 2);
            game.TakeTurn();

            Assert.Equal(new Property("Whitechapel Road"), endPosition);
        }

        internal class DiceStub : IRollDice
        {
            public (int, int) dice;

            public (int, int) RollDice()
            {
                return dice;
            }
        }
    }
}
