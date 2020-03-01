using System.Collections.Generic;
using System.Linq;

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
            // if player in jail for less than 3 turns, move to next player
            // if player not in jail, roll dice
            var dice = _diceRoller.RollDice();
            MoveActivePlayer(dice);
            _activePlayer.Act();

            // if double rolled, roll again
            if (_diceRoller.IsDouble && _activePlayer.ConsecutiveDoubles < 2)
            {
                IncrementDoubleStreak();
                MoveActivePlayer(dice);
                _activePlayer.Act();
            }
            // if double rolled 3 times, go straight to jail
            else if (_diceRoller.IsDouble && _activePlayer.ConsecutiveDoubles == 2)
            {
                MoveActivePlayer("Jail");
                _activePlayer.ConsecutiveDoubles = 0;
            }
            else
            {
                _activePlayer.ConsecutiveDoubles = 0; // reset consecutive doubles
            }
        }

        private void MoveActivePlayer(string destination)
        {
            var newPosition = Board.City.First(l => l.Name == destination);
            _activePlayer.Position = newPosition;
            if (newPosition.Name == "Go") _activePlayer.Pay(200);
        }

        private void MoveActivePlayer((int, int) dice)
        {
            var newPosition = Board.FindDestination(_activePlayer.Position, dice);
            if (Board.City.IndexOf(_activePlayer.Position) > Board.City.IndexOf(newPosition))
            {
                _activePlayer.Pay(200);
            }
            _activePlayer.Position = newPosition;
        }

        private void IncrementDoubleStreak()
        {

        }
    }
}
