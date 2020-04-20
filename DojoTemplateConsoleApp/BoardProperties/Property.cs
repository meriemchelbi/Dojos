namespace DojoTemplateConsoleApp.BoardProperties
{
    public class Property : Land
    {
        // This covers streets, stations, utilities
        public bool Owned { get; set; }
        public int FaceValue { get; set; }
        public Suite Suite { get; set; }
        public string Name { get; private set; }

        public Property(string name) : base(name)
        {
        }
    }
}
