using System.Collections.Generic;
using System.Linq;

namespace DojoTemplateConsoleApp
{
    public class Game 
    {
        public Game(IRollDice diceRoller, ISelectPlayer playerSelector, OutputRenderer renderer, params string[] playerNames)
        {
            Board = new Board();
            Players = playerNames.Select(p => new Player(renderer, p)).ToList();
            _diceRoller = diceRoller;
            _playerSelector = playerSelector;
            _renderer = renderer;
        }

        public Board Board { get; private set; }
        public List<Player> Players { get; private set; }
        private Player _activePlayer;
        private readonly IRollDice _diceRoller;
        private readonly ISelectPlayer _playerSelector;
        private readonly OutputRenderer _renderer;

        public void TakeTurn()
        {
            _activePlayer = _playerSelector.SelectPlayer(Players, _activePlayer);
            _renderer.AnnounceActivePlayer(_activePlayer.Name);
            
            var dice = _diceRoller.RollDice();
            _renderer.DiceSummary(dice);
            
            MoveActivePlayer(dice);
            _renderer.StatePlayerPosition(_activePlayer);

            _activePlayer.Act();

            if (_diceRoller.IsDouble && _activePlayer.ConsecutiveDoubles < 2)
            {
                IncrementDoubleStreak();
                // TODO roll again
                // TODO if player not in Jail, move
                MoveActivePlayer(dice);
                _activePlayer.Act();
            }
            // if double rolled 3 times & player not in Jail, go straight to jail
            else if (_diceRoller.IsDouble && _activePlayer.ConsecutiveDoubles == 2)
            {
                // TODO roll again
                // TODO if player not in Jail, move to Jail
                MoveActivePlayer("Jail");
                // TODO if player in Jail, move to Jail (visiting)
                ResetDoubleStreak();
            }
            else
            {
                ResetDoubleStreak();
            }

            // end turn : change active player        
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
            _activePlayer.ConsecutiveDoubles++;
        }
        
        private void ResetDoubleStreak()
        {
            _activePlayer.ConsecutiveDoubles = 0;
        }
    }
}
