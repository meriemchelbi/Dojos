using DojoTemplateConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DojoTemplateConsoleApp
{
    public class Game 
    {
        public Board Board { get; private set; }
        public List<Player> Players { get; private set; }
        private Player _activePlayer;
        private readonly IRollDice _diceRoller;
        private readonly ISelectPlayer _playerSelector;
        private readonly OutputRenderer _renderer;
        private readonly PlayerMover _playerMover;
        private readonly Banker _banker;

        public Game(Board board, IRollDice diceRoller, ISelectPlayer playerSelector, OutputRenderer renderer, params string[] playerNames)
        {
            Board = board;
            Players = playerNames.Select(p => new Player(p)).ToList();
            _diceRoller = diceRoller;
            _playerSelector = playerSelector;
            _renderer = renderer;
            _banker = new Banker(_renderer);
            _playerMover = new PlayerMover(Board, _renderer, _banker);
        }

        public void TakeTurn()
        {
            _activePlayer = _playerSelector.SelectPlayer(Players, _activePlayer);
            _renderer.AnnounceActivePlayer(_activePlayer.Name);
            
            var dice = _diceRoller.RollDice();
            _renderer.DiceSummary(dice);
            
            _playerMover.Move(_activePlayer, dice);

            // TODO ILand could return an action (more interfacey) /delegate depending on the type of land you land on
            // TODO give responsibility of deciding whether to charge to banker
            if (_activePlayer.Position.GetType() == typeof(Property) && ((Property)_activePlayer.Position).Owned)
                _banker.Charge(_activePlayer, 100);

            if (_activePlayer.Position.GetType() == typeof(CardTile))
            {
                var position = (CardTile)_activePlayer.Position;
                var instruction = DrawCard(position.TileCardType);
                // TODO execute action. Possibly in form of helper methods?
            }

            if (_diceRoller.IsDouble && _activePlayer.ConsecutiveDoubles < 2)
            {
                IncrementDoubleStreak();
                // TODO roll again
                // TODO if player not in Jail, move
                _playerMover.Move(_activePlayer, dice);
            }
            // if double rolled 3 times & player not in Jail, go straight to jail
            else if (_diceRoller.IsDouble && _activePlayer.ConsecutiveDoubles == 2)
            {
                // TODO roll again
                // TODO if player not in Jail, move to Jail
                _playerMover.Move(_activePlayer, "Jail");
                // TODO if player in Jail, move to Jail (visiting)
                ResetDoubleStreak();
            }
            else
            {
                ResetDoubleStreak();
            }

            // end turn : change active player        
        }

        private void IncrementDoubleStreak()
        {
            _activePlayer.ConsecutiveDoubles++;
        }
        
        private void ResetDoubleStreak()
        {
            _activePlayer.ConsecutiveDoubles = 0;
        }

        internal string DrawCard(CardType deckType)
        {
            var cardDeck = deckType == CardType.Chance
                ? Board.Chance
                : Board.CommunityChest;
            var topCard = cardDeck.GetTopCard();

            return topCard.Instruction;
        }
    }
}
