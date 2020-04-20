using DojoTemplateConsoleApp;
using DojoTemplateConsoleApp.Model;
using System.Collections.Generic;

namespace DojoTemplateTestProject
{
    public class PlayerSelectorStub : ISelectPlayer
    {
        public Player SelectPlayer(List<Player> players, Player activePlayer)
        {
            return activePlayer;
        }
    }
}
