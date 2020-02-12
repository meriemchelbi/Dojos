using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class Game 
    {
        public Game(IRollDice diceRoller, params string[] playerNames)
        {
            Board = new Board();
            Players = playerNames.Select(p => new Player(p)).ToList();
            _diceRoller = diceRoller;
            _activePlayer = Players.First();
        }

        public Board Board { get; private set; }
        public List<Player> Players { get; private set; }
        private Player _activePlayer;
        private readonly IRollDice _diceRoller;

        public void TakeTurn()
        {
            var dice = _diceRoller.RollDice();
            MoveActivePlayer(dice);
        }

        private void MoveActivePlayer((int, int) dice)
        {
            _activePlayer.Position = Board.FindDestination(_activePlayer.Position, dice);
        }

        private void MovePlayer()
        {

        }

    }
}
