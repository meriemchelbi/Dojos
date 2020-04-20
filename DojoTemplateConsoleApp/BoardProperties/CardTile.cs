namespace DojoTemplateConsoleApp.BoardProperties
{
    class CardTile : Land
    {
        public string Name { get; private set; }
        public CardType TileCardType { get; }

        public CardTile(string name, CardType tileType) : base(name)
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
