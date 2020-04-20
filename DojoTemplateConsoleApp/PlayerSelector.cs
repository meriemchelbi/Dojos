using DojoTemplateConsoleApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace DojoTemplateConsoleApp
{
    public class PlayerSelector : ISelectPlayer
    {
        public Player SelectPlayer(List<Player> players, Player activePlayer)
        {
            var activePlayerIndex = players.IndexOf(activePlayer);

            if ( (players.Count == 1) || (activePlayerIndex == players.Count - 1))
            {
                return players[0];
            }

            if (activePlayer is null)
            {
                return players.First();
            }

            else
            {
                return players[activePlayerIndex + 1];
            }
        }
    }
}
