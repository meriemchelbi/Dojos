using DojoTemplateConsoleApp;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace DojoTemplateTestProject
{
    public class GameTests
    {
        [Fact]
        public void TakeTurnMovesActivePlayerByDiceAmount()
        {
            var dice = new DiceStub();
            var game = new Game(dice, "Tarquin");

            //var endPosition = game.Players[0].Position;

            dice.dice = (1, 2);
            game.TakeTurn();

            dice.dice = (2, 2);
            game.TakeTurn();

            // why does the value assigned to this variable vary depending on where the variable is declared? Not expected from reference type
            var endPosition = game.Players[0].Position;

            endPosition.Should().BeEquivalentTo(new Land("Chance 1"));
        }

        [Fact]
        public void ThreeDoublesSendsPlayerToJail()
        {
            //var dice = new DiceStub();
            //var game = new Game(dice, "Tarquin");

            //dice.dice = (2, 2);
            //game.TakeTurn();

            //dice.dice = (4, 4);
            //game.TakeTurn();
            
            //dice.dice = (1, 1);
            //game.TakeTurn();

            //var endPosition = game.Players[0].Position;

            //endPosition.Should().BeEquivalentTo(new Land("Jail"));
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
            var dice = new DiceStub();
            var game = new Game(dice, "Tarquin");
            var player = game.Players.First();
            player.Position = new Land("Jail");

            dice.dice = (2, 2);
            game.TakeTurn();
            
            player.Balance.Should().Be(1700);
        }
    }
}
