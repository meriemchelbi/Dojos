using System;

namespace DojoTemplateConsoleApp.Model
{
    public class Card
    {
        public CardType Type { get; }
        public string Description { get; set; }
        public Action<int> Instruction { get; set; }
        public bool IsTopOfDeck { get; set; }

        public Card(CardType type, string description)
        {
            Type = type;
            Description = description;
        }
    }

    public enum CardType
    {
        CommunityChest,
        Chance
    }
}
