using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class Board
    {
        public List<Property> City { get; set; }

        public Board()
        {
            City = new List<Property>
            {
                new Property("Go"),
                new Property("Old Kent Road"),
                new Property("Community Chest"),
                new Property("Whitechapel Road"),
                new Property("Income Tax"),
                new Property("King's Cross Station"),
                new Property("The Angel Islington"),
                new Property("Chance"),
                new Property("Euston Road"),
                new Property("Pentonville Road"),
                new Property("Jail")
            };
        }

        internal Property FindDestination(Property position, (int, int) dice)
        {
            var currentPosition = City.IndexOf(position);
            var distance = dice.Item1 + dice.Item2;
            return City.ElementAt(currentPosition + distance);
        }
    }
}
