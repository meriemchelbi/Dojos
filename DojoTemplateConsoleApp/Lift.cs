using System.Collections.Generic;
using System.Linq;

namespace DojoTemplateConsoleApp
{
    public class Lift : ILift
    {
        public int CurrentFloor { get; set; }
        public int CurrentDestination { get; set; }
        public Direction Direction
        {
            get { return GetDirection(); }
        }
        public List<Passenger> Passengers { get; set; }

        public Lift()
        {
            CurrentFloor = 0;
            CurrentDestination = 0;
            Passengers = new List<Passenger>();
        }

        public void Call(Passenger passenger)
        {
            CurrentFloor = passenger.Origin;
            Passengers.Add(passenger);
            CurrentDestination = passenger.Destination;
        }

        public void Move()
        {
            if (!Passengers.Any())
            {
                // might want to log?
                return;
            }

            var passengerToMove = Passengers.FirstOrDefault();

            // building is 6 stories high and has a basement
            if (passengerToMove.Destination < 6 
                && passengerToMove.Destination > -1)
            {
                CurrentFloor = passengerToMove.Destination;
            }

            Passengers.Remove(passengerToMove);
        }

        private Direction GetDirection()
        {
            if (CurrentFloor > CurrentDestination)
            {
                return Direction.Down;
            }

            else
            {
                return Direction.Up;
            }
        }

    }
}
