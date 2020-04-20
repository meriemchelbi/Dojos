using DojoTemplateConsoleApp.Model;
using System.Linq;

namespace DojoTemplateConsoleApp
{
    internal class PlayerMover
    {
        private readonly Board _board;
        private readonly OutputRenderer _renderer;
        private readonly Banker _banker;

        public PlayerMover(Board board, OutputRenderer renderer, Banker banker)
        {
            _board = board;
            _renderer = renderer;
            _banker = banker;
        }

        internal void Move(Player player, string destination)
        {
            var newPosition = _board.City.First(l => l.Name == destination);
            player.Position = newPosition;
            if (newPosition.Name == "Go") _banker.Pay(player, 200);
            _renderer?.StatePlayerPosition(player);
        }

        internal void Move(Player player, (int, int) dice)
        {
            var newPosition = FindDestination(player.Position, dice);
            if (_board.City.IndexOf(player.Position) > _board.City.IndexOf(newPosition))
            {
                var message = "You passed Go!";
                _renderer?.Announce(message);
                _banker.Pay(player, 200);
            }
            player.Position = newPosition;
            _renderer?.StatePlayerPosition(player);
        }

        // n.b. this will break if the player does more than one lap in a single turn, but not catering for this as not possible in Monopoly.
        internal ILand FindDestination(ILand position, (int, int) dice)
        {
            var currentPosition = _board.City.IndexOf(position);
            var distance = dice.Item1 + dice.Item2;

            var destinationIndex = currentPosition + distance > _board.City.Count - 1
                ? distance - (_board.City.Count - currentPosition)
                : currentPosition + distance;

            return _board.City.ElementAt(destinationIndex);
        }
    }
}
