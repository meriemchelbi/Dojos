using DojoTemplateConsoleApp.BoardProperties;
using System.Collections.Generic;

namespace DojoTemplateConsoleApp
{
    class Program
    {
        static void Main()
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
            var communityChest = new Card[]
            {
                new Card(CardType.CommunityChest, "Advance to \"GO\". Collect £200."),
                new Card(CardType.CommunityChest, "Doctor's fees. Pay £50."),
                new Card(CardType.CommunityChest, "Get out of Jail free")
            };
            var chance = new Card[]
            {
                new Card(CardType.Chance, "Go to Jail. Go directly to Jail. Do not pass \"Go\""),
                new Card(CardType.Chance, "Take a trip to Reading Railroad.If you pass Go, collect £200."),
                new Card(CardType.Chance, "Your building loan matures. Receive £150.")
            };

            var board = new Board(city, communityChest, chance);
            var diceRoller = new DiceRoller();
            var renderer = new OutputRenderer();
            var playerSelector = new PlayerSelector();
            var game = new Game(board, diceRoller, playerSelector, renderer, "Tarquin");

            while (true)
            {
                game.TakeTurn();
            }
        }
    }
}
