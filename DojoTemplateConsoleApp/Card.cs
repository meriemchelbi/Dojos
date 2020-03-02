using System;

namespace DojoTemplateConsoleApp
{
    public class Card
    {
        public CardType Type { get; }
        public string Description { get; set; }
        public Action Instruction { get; private set; }
        public bool IsTopOfDeck { get; set; }

        public Card(CardType type, string description)
        {
            Type = type;
            Description = description;
        }
    }
}

public enum CardType
{
    CommunityChest,
    Chance
}