using System.Collections.Generic;

namespace DojoTemplateConsoleApp
{
    public class Lift : ILift
    {
        public int CurrentFloor { get; set; }
        public Direction Direction { get; set; }
        public List<Passenger> Passengers { get; set; }

        public Lift()
        {
            CurrentFloor = 0;
            Passengers = new List<Passenger>();
        }

        public void Call(Passenger passenger)
        {
            CurrentFloor = passenger.Origin;
            Passengers.Add(passenger);
        }

        public void Move(int destination)
        {
            // building is 6 stories high and has a basement
            if (destination > 6 || destination < -1)
            {
                return;
            }

            else
            {
                CurrentFloor = destination;
            }
        }
    }
}
