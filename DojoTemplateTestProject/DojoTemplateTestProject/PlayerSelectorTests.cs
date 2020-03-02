using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using DojoTemplateConsoleApp;

namespace DojoTemplateTestProject
{
    public class PlayerSelectorTests
    {
        [Fact]
        public void SetActivePlayerSelectsFirstPlayerOnFirstTurn()
        {
            var players = new List<Player> 
            { 
                new Player("Tarquin"),
                new Player("Wibble"),
                new Player("Kevin Costner")
            };
            var sut = new PlayerSelector();

            var result = sut.SelectPlayer(players, null);

            result.Should().BeEquivalentTo(new Player("Tarquin"));
        }
        
        [Fact]
        public void SetActivePlayerSelectsNextPlayerWhenActivePlayerSet()
        {
            var tarquin = new Player("Tarquin");
            var wibble = new Player("Wibble");
            var kevin = new Player("Kevin");

            var players = new List<Player> { tarquin, wibble, kevin };
            var sut = new PlayerSelector();

            var result = sut.SelectPlayer(players, new Player("Tarquin"));

            result.Should().BeEquivalentTo(new Player("Wibble"));
        }
        
        [Fact]
        public void SetActivePlayerSelectsFirstPlayerWhenLastPlayerActive()
        {
            var tarquin = new Player("Tarquin");
            var wibble = new Player("Wibble");
            var kevin = new Player("Kevin");

            var players = new List<Player> { tarquin, wibble, kevin };
            var sut = new PlayerSelector();

            var result = sut.SelectPlayer(players, new Player("Kevin Costner"));

            result.Should().BeEquivalentTo(new Player("Tarquin"));
        }
        
        [Fact]
        public void SetActivePlayerSelectsOnlyPlayerWhenSinglePlayer()
        {
            var players = new List<Player> { new Player("Tarquin") };
            var sut = new PlayerSelector();

            sut.SelectPlayer(players, players[0]);
            var result = sut.SelectPlayer(players, players[0]);

            result.Should().BeEquivalentTo(new Player("Tarquin"));
        }
    }
}
