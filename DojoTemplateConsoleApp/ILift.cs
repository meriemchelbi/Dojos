using DojoTemplateConsoleApp.Model;
using System.Collections.Generic;

namespace DojoTemplateConsoleApp
{
    public interface ILift
    {
        int CurrentFloor { get; set; }
        int NextStop { get; set; }
        Direction Direction { get; }
        List<Passenger> Passengers { get; set; }

        void Call(Passenger passenger);
        public void Move();
    }
}
