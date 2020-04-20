using System;
using System.Collections.Generic;
using System.Linq;

namespace DojoTemplateConsoleApp
{
    public class CardDeck
    {
        private Card[] _cards;
        public readonly LinkedList<Card> ShuffledDeck;
        public LinkedListNode<Card> TopCard { get; set; }

        public CardDeck(Card[] cards)
        {
            _cards = cards;
            ShuffledDeck = new LinkedList<Card>(Shuffle(_cards));
        }

        public Card Draw()
        {
            if (TopCard is null)
                TopCard = ShuffledDeck.First;
            else if (TopCard == ShuffledDeck.Last)
                TopCard = ShuffledDeck.First;
            else
                TopCard = TopCard.Next;

            return TopCard.Value;
        }

        // TODO look up Fischer-Yates shuffle
        private IEnumerable<Card> Shuffle(Card[] cards)
        {
            var random = new Random();
            return cards.OrderBy(x => random.Next());
        }
    }
}
