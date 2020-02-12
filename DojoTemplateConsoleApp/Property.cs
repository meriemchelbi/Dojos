using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class Property
    {
        public string Name { get; private set; }

        public Property(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return this.Name == ((Property)obj).Name;
        }
    }
}
