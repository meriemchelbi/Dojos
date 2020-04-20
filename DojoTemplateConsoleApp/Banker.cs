using DojoTemplateConsoleApp.Model;

namespace DojoTemplateConsoleApp
{
    internal class Banker
    {
        private OutputRenderer _renderer;

        public Banker(OutputRenderer renderer)
        {
            _renderer = renderer;
        }

        internal void Pay(Player player, int amount)
        {
            player.Balance += amount;
            _renderer?.AnnounceBalanceUpdate(player.Balance);
        }

        internal void Charge(Player player, int amount)
        {
            player.Balance -= amount;
            _renderer?.AnnounceBalanceUpdate(player.Balance);
        }
    }
}
