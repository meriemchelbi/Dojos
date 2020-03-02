using DojoTemplateConsoleApp;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace DojoTemplateTestProject
{
    public class GameTests
    {
        private readonly OutputRenderer _renderer;
        private readonly ISelectPlayer _playerSelector;
        private readonly DiceStub _dice;

        public GameTests()
        {
            _renderer = new OutputRenderer();
            _playerSelector = new PlayerSelector();
            _dice = new DiceStub();
        }

        [Fact]
        public void TakeTurnMovesActivePlayerByDiceAmount()
        {
            var game = new Game(_dice, _playerSelector, _renderer, "Tarquin");

            //var endPosition = game.Players[0].Position;

            _dice.dice = (1, 2);
            game.TakeTurn();

            _dice.dice = (2, 2);
            game.TakeTurn();

            // why does the value assigned to this variable vary depending on where the variable is declared? Not expected from reference type
            var endPosition = game.Players[0].Position;

            endPosition.Should().BeEquivalentTo(new Land("Chance 1"));
        }

        [Fact]
        public void ThreeDoublesSendsPlayerToJail()
        {
            var game = new Game(_dice, _playerSelector, _renderer, "Tarquin");

            _dice.dice = (2, 2);
            _dice.IsDouble = true;
            game.TakeTurn();

            _dice.dice = (4, 4);
            _dice.IsDouble = true;
            game.TakeTurn();

            _dice.dice = (1, 1);
            _dice.IsDouble = true;
            game.TakeTurn();

            var endPosition = game.Players[0].Position;

            endPosition.Should().BeEquivalentTo(new Land("Jail"));
        }

        [Fact]
        public void RollsAgainWhenRollsADouble()
        {
            // How do I want this to work? Automatically roll & move? Or ask player to roll again?
            // might be dependent on player incrementing
        }

        [Fact]
        public void ActivePlayerGetsPaidWhenPassesGo()
        {
            var game = new Game(_dice, _playerSelector, _renderer, "Tarquin");
            var player = game.Players.First();
            player.Position = new Land("Jail");

            _dice.dice = (2, 2);
            game.TakeTurn();
            
            player.Balance.Should().Be(1700);
        }
    }
}
