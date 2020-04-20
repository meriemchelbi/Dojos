using DojoTemplateConsoleApp;
using Xunit;
using FluentAssertions;

namespace DojoTemplateTestProject
{
    public class CardDeckTests
    {
        [Fact]
        public void ShuffleGeneratesEquivalentButDifferentDeck()
        {
            Card[] cards = new Card[]
            {
                new Card(CardType.Chance, "Chance 1"),
                new Card(CardType.Chance, "Chance 2"),
                new Card(CardType.CommunityChest, "Community 1"),
                new Card(CardType.CommunityChest, "Community 2"),
            };
            var sut = new CardDeck(cards);

            sut.ShuffledDeck.Should().NotBeNull();
            sut.ShuffledDeck.Count.Should().Be(cards.Length);
            sut.ShuffledDeck.Should().OnlyHaveUniqueItems();
        }

        [Fact]
        public void DrawDrawsFirstCardAtStart()
        {
            Card[] cards = new Card[]
            {
                new Card(CardType.Chance, "Chance 1"),
                new Card(CardType.Chance, "Chance 2"),
                new Card(CardType.CommunityChest, "Community 1"),
                new Card(CardType.CommunityChest, "Community 2"),
            };
            var sut = new CardDeck(cards);
            var drawn = sut.GetTopCard();

            drawn.Should().NotBeNull();
            drawn.Should().BeEquivalentTo(sut.ShuffledDeck.First.Value);
        }

        [Fact]
        public void DrawDrawsNextCardWhenNotLastCard()
        {
            Card[] cards = new Card[]
            {
                new Card(CardType.Chance, "Chance 1"),
                new Card(CardType.Chance, "Chance 2"),
                new Card(CardType.CommunityChest, "Community 1"),
                new Card(CardType.CommunityChest, "Community 2"),
            };
            var sut = new CardDeck(cards);
            sut.GetTopCard();
            var drawn = sut.GetTopCard();

            drawn.Should().NotBeNull();
            drawn.Should().BeEquivalentTo(sut.ShuffledDeck.First.Next.Value);
        }

        [Fact]
        public void DrawDrawsFirstCardWhenEndOfDeckReached()
        {
            Card[] cards = new Card[]
            {
                new Card(CardType.Chance, "Chance 1"),
                new Card(CardType.Chance, "Chance 2"),
                new Card(CardType.CommunityChest, "Community 1"),
                new Card(CardType.CommunityChest, "Community 2"),
            };
            var sut = new CardDeck(cards);
            sut.GetTopCard();
            sut.GetTopCard();
            sut.GetTopCard();
            sut.GetTopCard();
            var drawn = sut.GetTopCard();

            drawn.Should().NotBeNull();
            drawn.Should().BeEquivalentTo(sut.ShuffledDeck.First.Value);
        }
    }
}
