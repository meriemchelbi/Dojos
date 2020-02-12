using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class Player
    {
        public string Name { get; private set; }
        public int Balance { get; private set;  }
        public List<Property> Properties { get; set; }
        public Property Position { get; set; }

        public Player(string name)
        {
            Balance = 1500;
            Name = name;
            Position = new Property("Go");
        }
    }
}
