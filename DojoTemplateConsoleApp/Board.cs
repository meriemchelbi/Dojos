using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class Board
    {
        public List<ILand> City { get; set; }

        public Board()
        {
            City = new List<ILand>
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

        // n.b. this will break if the player does more than one lap in a single turn, but not catering for this as not possible in Monopoly.
        internal ILand FindDestination(ILand position, (int, int) dice)
        {
            var currentPosition = City.IndexOf(position);
            var distance = dice.Item1 + dice.Item2;

            var destinationIndex = currentPosition + distance > City.Count - 1
                ? distance - (City.Count - currentPosition)
                : currentPosition + distance;

            return City.ElementAt(destinationIndex);
        }
    }
}
