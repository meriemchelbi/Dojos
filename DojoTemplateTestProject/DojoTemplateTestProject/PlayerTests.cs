using DojoTemplateConsoleApp;
using DojoTemplateConsoleApp.BoardProperties;
using FluentAssertions;
using System;
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

        [Fact]
        public void PlayerOnCardTileDrawsTopCard()
        {
            var player = new Player("Tarquin")
            {
                Position = new CardTile("Chance tile", CardType.Chance)
            };

            Action<Player,int> instruction1 = (player, amount) => IncreaseBalance(player, 5);
            Action<Player,int> instruction2 = (player, amount) => IncreaseBalance(player, 500);
            Action<Player,int> instruction3 = (player, amount) => IncreaseBalance(player, 1000);

            var cards = new Card[]
            {
                new Card(CardType.Chance, "Chance card 1") { Instruction = instruction1 },
                new Card(CardType.Chance, "Chance card 2") { Instruction = instruction2 },
                new Card(CardType.Chance, "Chance card 3") { Instruction = instruction3 }
            };
            var cardDeck = new CardDeck(cards);

            player.Act();

            ;
        }

        private void IncreaseBalance(Player activeplayer, int amount)
        {
            activeplayer.Pay(amount);
        }
    }
}
