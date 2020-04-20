using DojoTemplateConsoleApp;
using Xunit;
using FluentAssertions;
using System.Linq;
using DojoTemplateConsoleApp.BoardProperties;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace DojoTemplateTestProject
{
    public class GameTests
    {
        private readonly OutputRenderer _renderer;
        private readonly ISelectPlayer _playerSelector;
        private readonly DiceStub _dice;
        private readonly Board _board;

        public GameTests()
        {
            var city = new List<ILand>
            {
                new Land("Go"),
                new Property("Old Kent Road") { Owned = true },
                new CardTile("Community Chest 1", CardType.CommunityChest),
                new Property("Whitechapel Road"),
                new Land("Income Tax"),
                new Property("King's Cross Station") { Owned = true },
                new Property("The Angel Islington"),
                new CardTile("Chance 1", CardType.Chance),
                new Property("Euston Road"),
                new Property("Pentonville Road") { Owned = true },
                new Land("Jail")
            };
            _board = new Board(city, new Card[0], new Card[0]);
            _renderer = new OutputRenderer();
            _playerSelector = new PlayerSelector();
            _dice = new DiceStub();
        }

        [Fact]
        public void TakeTurnMovesActivePlayerByDiceAmount()
        {
            var game = new Game(_board, _dice, _playerSelector, _renderer, "Tarquin");

            //var endPosition = game.Players[0].Position;

            _dice.dice = (1, 2);
            game.TakeTurn();

            _dice.dice = (2, 3);
            game.TakeTurn();

            // why does the value assigned to this variable vary depending on where the variable is declared? Not expected from reference type
            var endPosition = game.Players[0].Position;

            endPosition.Should().BeEquivalentTo(new Property("Euston Road"));
        }

        [Fact]
        public void ThreeDoublesSendsPlayerToJail()
        {
            var game = new Game(_board, _dice, _playerSelector, _renderer, "Tarquin");

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
            var game = new Game(_board, _dice, _playerSelector, _renderer, "Tarquin");
            var player = game.Players.First();
            player.Position = new Land("Jail");

            _dice.dice = (2, 2);
            game.TakeTurn();
            
            player.Balance.Should().Be(1700);
        }

        [Fact]
        public void PlayerOnOwnedPropertyPaysRent()
        {
            var game = new Game(_board, _dice, _playerSelector, _renderer, "Tarquin");
            var player = game.Players.First();
            player.Position = new Property("Go");

            _dice.dice = (0, 1);
            game.TakeTurn();

            player.Balance.Should().Be(1400);
        }

        [Fact]
        public void PlayerOnUnownedPropertyPaysNothing()
        {
            var game = new Game(_board, _dice, _playerSelector, _renderer, "Tarquin");
            var player = game.Players.First();
            player.Position = new Property("Go");

            _dice.dice = (2, 1);
            game.TakeTurn();

            player.Balance.Should().Be(1500);
        }

        [Fact]
        public void DrawCardReturnsTopCardInstruction()
        {
            var sut = new Game(_board, _dice, _playerSelector, _renderer, "Tarquin");
            _board.Chance = Substitute.For<IStackCards>();
            var action = new Action<int>(i => i = 2);
            var card = new Card(CardType.Chance, "chance") { Instruction = action };
            _board.Chance.GetTopCard().Returns(card);

            var instruction = sut.DrawCard(CardType.Chance);

            instruction.Should().BeSameAs(action);
        }

    }
}
