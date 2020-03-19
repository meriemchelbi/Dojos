using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class Board
    {
        public List<ILand> City { get; set; }
        public CardDeck CommunityChest { get; }
        public CardDeck Chance { get; }
        private readonly Card[] _chance;
        private readonly Card[] _communityChest;

        public Board()
        {
            City = new List<ILand>
            {
                new Land("Go"),
                new Property("Old Kent Road") { Owned = true },
                new Land("Community Chest 1"),
                new Property("Whitechapel Road"),
                new Land("Income Tax"),
                new Property("King's Cross Station") { Owned = true },
                new Property("The Angel Islington"),
                new Land("Chance 1"),
                new Property("Euston Road"),
                new Property("Pentonville Road") { Owned = true },
                new Land("Jail")
            };
            _communityChest = new Card[]
            {
                new Card(CardType.CommunityChest, "Advance to \"GO\". Collect £200."),
                new Card(CardType.CommunityChest, "Doctor's fees. Pay £50."),
                new Card(CardType.CommunityChest, "Get out of Jail free")
            };
            _chance = new Card[]
            {
                new Card(CardType.Chance, "Go to Jail. Go directly to Jail. Do not pass \"Go\""),
                new Card(CardType.Chance, "Take a trip to Reading Railroad.If you pass Go, collect £200."),
                new Card(CardType.Chance, "Your building {and} loan matures. Receive {Collect} £150.")
            };
            CommunityChest = new CardDeck(_communityChest);
        }

        // n.b. this will break if the player does more than one lap in a single turn, but not catering for this as not possible in Monopoly.
        internal ILand FindDestination(ILand position, (int, int) dice)
        {
            var currentPosition = City.IndexOf(position);
            var distance = dice.Item1 + dice.Item2;

            var destinationIndex = currentPosition + distance > City.Count - 1
                ? distance - (City.Count - currentPosition)
                : currentPosition + distance;

            return City.ElementAt(destinationIndex);
        }
    }
}
