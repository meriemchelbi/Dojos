using DojoTemplateConsoleApp;
using System;
using Xunit;

namespace DojoTemplateTestProject
{
    public class GameTests
    {
        [Fact]
        public void TakeTurnMovesActivePlayerByDiceAmount()
        {
            var dice = new DiceStub();
            var game = new Game(dice, "Tarquin");

            var endPosition = game.Players[0].Position;

            dice.dice = (1, 2);
            game.TakeTurn();

            dice.dice = (2, 2);
            game.TakeTurn();

            // why does the value assigned to this variable vary depending on where the variable is declared? Not expected from reference type
            endPosition = game.Players[0].Position;

            Assert.Equal(new Land("Chance 1"), endPosition);
        }

        [Fact]
        public void ThreeDoublesSendsPlayerToJail()
        {

        }

        [Fact]
        public void RollsAgainWhenRollsADouble()
        {
            // test one double
            // test two doubles
        }

        [Fact]
        public void ActivePlayerGetsPaidWhenPassesGo()
        {

        }

        [Fact]

    }
}
