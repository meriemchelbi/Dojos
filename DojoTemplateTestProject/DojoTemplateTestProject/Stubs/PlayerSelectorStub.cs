using DojoTemplateConsoleApp;
using System;
using System.Collections.Generic;
using System.Text;

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
