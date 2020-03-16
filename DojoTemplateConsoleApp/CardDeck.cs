using System;
using System.Collections.Generic;
using System.Linq;

namespace DojoTemplateConsoleApp
{
    public class CardDeck
    {
        private Card[] _cards;

        public readonly LinkedList<Card> ShuffledDeck;
        private LinkedListNode<Card> _topCard;

        public CardDeck(Card[] cards)
        {
            _cards = cards;
            ShuffledDeck = new LinkedList<Card>(Shuffle(_cards));
        }

        // TODO refactor and remove IsTopOfDeck if not used
        public Card Draw()
        {
            if (_topCard is null)
            {
                _topCard = ShuffledDeck.First;
                _topCard.Value.IsTopOfDeck = true;
            }

            else if (_topCard == ShuffledDeck.Last)
            {
                _topCard.Value.IsTopOfDeck = false;
                _topCard = ShuffledDeck.First;
                _topCard.Value.IsTopOfDeck = true;
            }

            else
            {
                _topCard.Value.IsTopOfDeck = false;
                _topCard = _topCard.Next;
                _topCard.Value.IsTopOfDeck = true;
            }

            return _topCard.Value;
        }

        private IEnumerable<Card> Shuffle(Card[] cards)
        {
            var random = new Random();
            return cards.OrderBy(x => random.Next());
        }
    }
}
