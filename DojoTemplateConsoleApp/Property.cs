using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class Property : ILand
    {
        // This covers streets, stations, utilities
        public bool Owned { get; set; }
        public int FaceValue { get; set; }
        public Suite Suite { get; set; }
        public string Name { get; private set; }

        public Property(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return this.Name == ((ILand)obj).Name;
        }
    }
}
