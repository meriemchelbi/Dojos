using System;
using System.Collections.Generic;
using System.Linq;

namespace DojoTemplateConsoleApp
{
    public class CardDeck
    {
        private Card[] _cards;

        public readonly List<Card> ShuffledDeck;
        private Card _topCard;

        public CardDeck(Card[] cards)
        {
            _cards = cards;
            ShuffledDeck = Shuffle(_cards);
        }

        public Card Draw()
        {
            var topCard = ShuffledDeck.FirstOrDefault(c => c.IsTopOfDeck == true);
            if (topCard is null)
            {
                topCard = ShuffledDeck[0];
                topCard.IsTopOfDeck = true;
                return topCard;
            }

            else
            {
                var topCardIndex = ShuffledDeck.FindLastIndex(c => c.IsTopOfDeck == true);
                ShuffledDeck[topCardIndex].IsTopOfDeck = false;

                var newCardIndex = topCardIndex == ShuffledDeck.Count - 1
                    ? 0
                    : topCardIndex + 1;

                var newCard = ShuffledDeck[newCardIndex];
                newCard.IsTopOfDeck = true;
                
                return newCard;
            }
        }

        private List<Card> Shuffle(Card[] cards)
        {
            var random = new Random();
            return cards.OrderBy(x => random.Next()).ToList();
        }
    }
}
