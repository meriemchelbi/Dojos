using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class PrivateProperty : Property
    {
        // This covers streets, stations, utilities
        public bool Owned { get; set; }
        public int FaceValue { get; set; }
        public Suite Suite { get; set; }

        public PrivateProperty(string name) : base(name)
        {

        }
    }
}
