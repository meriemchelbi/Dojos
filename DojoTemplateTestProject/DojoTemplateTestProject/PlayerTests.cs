using DojoTemplateConsoleApp;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DojoTemplateTestProject
{
    public class PlayerTests
    {
        [Fact]
        public void PlayerOnOwnedPropertyPaysRent()
        {
            var dice = new DiceStub();
            var game = new Game(dice, "Tarquin");
            ((Property)game.Board.City[3]).Owned = true;

            dice.dice = (1, 2);
            game.TakeTurn();

            game.Players[0].Balance.Should().Be(1400);
        }

        [Fact]
        public void PlayerOnUnownedPropertyPaysNothing()
        {
            var dice = new DiceStub();
            var game = new Game(dice, "Tarquin");
            ((Property)game.Board.City[3]).Owned = false;

            dice.dice = (1, 2);
            game.TakeTurn();

            game.Players[0].Balance.Should().Be(1500);
        }
    }
}
