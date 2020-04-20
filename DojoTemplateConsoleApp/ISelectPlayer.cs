using DojoTemplateConsoleApp.Model;
using System.Collections.Generic;

namespace DojoTemplateConsoleApp
{
    public interface ISelectPlayer
    {
        Player SelectPlayer(List<Player> players, Player activePlayer);
    }
}