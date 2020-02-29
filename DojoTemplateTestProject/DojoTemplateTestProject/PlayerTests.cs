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
            var player = new Player("Tarquin")
            {
                Position = new Property("Home") { Owned = true }
            };

            player.Act();

            player.Balance.Should().Be(1400);
        }

        [Fact]
        public void PlayerOnUnownedPropertyPaysNothing()
        {
            var player = new Player("Tarquin")
            {
                Position = new Property("Home") { Owned = false }
            };

            player.Act();

            player.Balance.Should().Be(1500);
        }
    }
}
