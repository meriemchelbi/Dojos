using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DojoTemplateTestProject")]
namespace DojoTemplateConsoleApp.Model
{
    public class Player
    {
        public string Name { get; private set; }
        public int Balance { get; set; }
        public List<ILand> Properties { get; set; }
        public ILand Position { get; set; }
        public int ConsecutiveDoubles { get; set; }
        private readonly OutputRenderer _renderer;
        private readonly Board _board;

        public Player(string name)
        {
            Balance = 1500;
            Name = name;
            Position = new Land("Go");
        }




    }
}
