namespace DojoTemplateConsoleApp.BoardProperties
{
    class CardTile : ILand
    {
        public string Name { get; private set; }
        public CardType TileCardType { get; }

        public CardTile(string name, CardType tileType)
        {
            Name = name;
            TileCardType = tileType;
        }

        public override bool Equals(object obj)
        {
            return Name == ((ILand)obj).Name;
        }
    }
}
