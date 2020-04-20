namespace DojoTemplateConsoleApp.BoardProperties
{
    public class Land : ILand
    {
        public string Name { get; private set; }

        public Land(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return Name == ((ILand)obj).Name;
        }
    }
}
