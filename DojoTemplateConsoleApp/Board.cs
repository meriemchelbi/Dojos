using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class Board
    {
        public List<Land> City { get; set; }

        public Board()
        {
            City = new List<Land>
            {
                new Land("Go"),
                new Property("Old Kent Road"),
                new Land("Community Chest 1"),
                new Property("Whitechapel Road"),
                new Land("Income Tax"),
                new Property("King's Cross Station"),
                new Property("The Angel Islington"),
                new Land("Chance 1"),
                new Property("Euston Road"),
                new Property("Pentonville Road"),
                new Land("Jail")
            };
        }

        internal Land FindDestination(Land position, (int, int) dice)
        {
            var currentPosition = City.IndexOf(position);
            var distance = dice.Item1 + dice.Item2;
            return City.ElementAt(currentPosition + distance);
        }
    }
}
