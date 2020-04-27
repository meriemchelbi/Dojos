using DojoTemplateConsoleApp.Model;
using System;
using System.Collections.Generic;

namespace DojoTemplateConsoleApp
{
    internal class CardInstructionRepository
    {
        public Dictionary<string, Action<Player, string>> Instructions;
        private PlayerMover _mover;
        private Banker _banker;

        public CardInstructionRepository(PlayerMover mover, Banker banker)
        {
            _mover = mover;
            _banker = banker;
            Instructions = new Dictionary<string, Action<Player, string>>
            {
                { "Straight to Jail" , new Action<Player, string>( (p, d) => _mover.Move(p, d)) },
                { "Move to X" , new Action<Player, string>((p, d) => _mover.Move(p, d)) },
                { "Player Wins" , new Action<Player, string>((p, d) => _mover.Move(p, d)) },
                { "Player Pays" , new Action<Player, string>((p, d) => _mover.Move(p, d)) },
                { "Keep Card" , new Action<Player, string>((p, d) => _mover.Move(p, d)) }
            };
        }
    }
}
