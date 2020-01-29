using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class Lift
    {
        private HashSet<int> _stops;
        private bool IsIdle = true;
        private Direction _direction;
        private int _currentFloor;
        private int _topFloor;

        public int CurrentFloor
        {
            get
            {
                if (_currentFloor > 0)
                {
                    return _currentFloor;
                }
                else return 0;
            }
            set { _currentFloor = value; }
        }
        public Direction Direction 
        { 
            get 
            {
                if (CurrentFloor == _topFloor) _direction = Direction.Down;
                else if (CurrentFloor == 0) _direction =  Direction.Up;
                return _direction;
            }
            set { _direction = value; }
        }

        public Lift(int topFloor)
        {
            _stops = new HashSet<int>();
            _direction = Direction.Up; // assumes starting on ground floor
            _topFloor = topFloor;
        }

        public void Move()
        {
            if (Direction == Direction.Up)
            {
                CurrentFloor++;
            }
            if (Direction == Direction.Down)
            {
                CurrentFloor--;
            }
        }


    }

    public enum Direction
    {
        Up,
        Down
    }
}
