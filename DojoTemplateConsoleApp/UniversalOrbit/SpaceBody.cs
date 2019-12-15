using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.UniveralOrbit
{
    public class SpaceBody
    {
        public SpaceBody(string name)
        {
            Name = name;
            Satellites = new List<SpaceBody>();
        }

        public string Name { get; }
        public List<SpaceBody> Satellites { get; set; }
    }
}
