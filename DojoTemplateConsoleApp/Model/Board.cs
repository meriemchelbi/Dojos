using System.Collections.Generic;

namespace DojoTemplateConsoleApp.Model
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
    }
}
