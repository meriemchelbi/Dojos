using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class Train
    {
        public List<Carriage> Carriages { get; }
        public Train(IEnumerable<string> namesOfCarriages)
        {
            Carriages = namesOfCarriages.Select(name => new Carriage(name)).ToList();
        }
    }
}
