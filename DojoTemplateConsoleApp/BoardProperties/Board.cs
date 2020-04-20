using System.Collections.Generic;
using System.Linq;

namespace DojoTemplateConsoleApp.BoardProperties
{
    public class Board
    {
        public List<ILand> City { get; set; }
        internal IStackCards CommunityChest { get; }
        internal IStackCards Chance { get; set; }

        // TODO inject card decks and refactor tests
        public Board(List<ILand> city, Card[] communityChest, Card[] chance)
        {
            City = city;
            CommunityChest = new CardDeck(communityChest);
            Chance = new CardDeck(chance);
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
