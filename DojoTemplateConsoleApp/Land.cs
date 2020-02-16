using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class Land
    {
        public string Name { get; private set; }

        public Land(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return this.Name == ((Land)obj).Name;
        }
    }
}
