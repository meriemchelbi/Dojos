using DojoTemplateConsoleApp.BoardProperties;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DojoTemplateTestProject")]
namespace DojoTemplateConsoleApp
{
    public class Player
    {
        public string Name { get; private set; }
        public int Balance { get; private set;  }
        public List<ILand> Properties { get; set; }
        public ILand Position { get; set; }
        public int ConsecutiveDoubles { get; set; }
        private readonly OutputRenderer _renderer;

        public Player(OutputRenderer renderer, string name)
        {
            Balance = 1500;
            Name = name;
            Position = new Land("Go");
            _renderer = renderer;
        }
        public Player(string name)
        {
            Balance = 1500;
            Name = name;
            Position = new Land("Go");
        }

        internal void Pay(int amount)
        {
            this.Balance += amount;
            _renderer?.AnnounceBalanceUpdate(Balance);
        }

        internal void Charge(int amount)
        {
            Balance -= amount;
            _renderer?.AnnounceBalanceUpdate(Balance);
        }
    }
}
