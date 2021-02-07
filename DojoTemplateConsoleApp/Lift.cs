using DojoTemplateConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class Lift : ILift
    {
        public int CurrentFloor { get; set; }
        public int NextStop { get; set; }
        public Direction Direction
        {
            get { return GetDirection(); }
        }
        public List<Passenger> Passengers { get; set; }

        public Lift()
        {
            CurrentFloor = 0;
            NextStop = 0;
            Passengers = new List<Passenger>();
        }

        public void Call(Passenger passenger)
        {
            Console.WriteLine("Calling lift...");
            CurrentFloor = passenger.Origin;
            Passengers.Add(passenger);
            SetNextStop();
        }

        public void Move()
        {
            Console.WriteLine("Moving lift...");
            if (!Passengers.Any())
            {
                // might want to log?
                return;
            }

            Passenger passengerToMove = GetNextPassenger();

            if (passengerToMove.Origin != passengerToMove.Destination)
            {
                CurrentFloor = passengerToMove.Destination;
            }

            Passengers.Remove(passengerToMove);
            SetNextStop();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("Passengers in lift:\n");
            foreach (var passenger in Passengers)
            {
                sb.Append($"{passenger}\n");
            }

            sb.Append($"Lift going {Direction}.\n");
            sb.Append($"Current floor: {CurrentFloor}.\n");
            sb.Append($"Next stop: {NextStop}.");

            return sb.ToString();
        }

        private Direction GetDirection()
        {
            if (CurrentFloor > NextStop)
            {
                return Direction.Down;
            }

            else
            {
                return Direction.Up;
            }
        }

        private Passenger GetNextPassenger()
        {
            var passengerDestinationPairs = Passengers.ToDictionary(p => p, p => Math.Abs(p.Destination - CurrentFloor));
            var lowestDistance = passengerDestinationPairs.Min(p => p.Value);
            
            return passengerDestinationPairs.FirstOrDefault(p => p.Value == lowestDistance).Key;
        }

        private void SetNextStop()
        {
            if (!Passengers.Any())
            {
                NextStop = 0;
                return;
            }

            if (Passengers.Count() == 1)
            {
                NextStop = Passengers.FirstOrDefault().Destination;
                return;
            }

            var nextPassenger = GetNextPassenger();
            NextStop = nextPassenger.Destination;
        }
    }
}
