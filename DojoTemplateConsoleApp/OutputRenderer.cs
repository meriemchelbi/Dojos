using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    // TODO: add interface for type & tests?
    public class OutputRenderer
    {
        public void AnnounceActivePlayer(string activePlayer)
        {
            Console.WriteLine($"{activePlayer}, you're up!");
        }

        internal void DiceSummary((int, int) dice)
        {
            Console.WriteLine($"You have rolled {dice.Item1} & {dice.Item2}. Move {dice.Item1 + dice.Item2} spaces!");
        }

        internal void StatePlayerPosition(Player activePlayer)
        {
            Console.WriteLine($"{activePlayer.Name}, you are now on {activePlayer.Position.Name}!");
        }

        internal void AnnounceBalanceUpdate(Player player)
        {
            Console.WriteLine($"Your new balance is {player.Balance}!");
        }
    }
}
