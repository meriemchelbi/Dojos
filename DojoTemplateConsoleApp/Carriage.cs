using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
     public class Carriage
    {
        public string CarriageName { get; }
        public int NumberOfSeatsRemaining { get; set; }

        public Carriage(string carriageName)
        {
            CarriageName = carriageName;
        }

        public void Alight()
        {
            NumberOfSeatsRemaining++;

        }

        public void Board()
        {
            NumberOfSeatsRemaining--;
        }
    }
}
