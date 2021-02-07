using System.Collections.Generic;
using System.Linq;
using DojoTemplateConsoleApp.Extensions;
using DojoTemplateConsoleApp.Model;

namespace DojoTemplateConsoleApp
{
    public class Engine
    {
        private readonly IEnumerable<ILift> _lifts;
        private readonly Queue<Passenger> _waitingPassengers;


        public Engine(WaitingPassengers jobQueue, params ILift[] lifts)
        {
            _lifts = lifts;
            _waitingPassengers = jobQueue.JobQueue;
        }

        public void MoveLift(Passenger caller = null)
        {
            var lift = _lifts.FirstOrDefault();
            bool callerOnLiftPath = lift.CallerOnWay(caller);
            bool callerGoingLiftDirection = lift.GoingSameDirection(caller);

            if (_waitingPassengers.Any())
            {
                lift.Call(_waitingPassengers.Dequeue());
                if (caller != null)
                {
                    _waitingPassengers.Enqueue(caller);
                }
            }
            
            else if (caller is null & !_waitingPassengers.Any())
                lift.Move();

            
            else if (!lift.Passengers.Any())
            {
                lift.Call(caller);
            }

            else if (!callerOnLiftPath || !callerGoingLiftDirection)
            {
                _waitingPassengers.Enqueue(caller);
                lift.Move();
            }

            else
            {
                lift.Call(caller);
            }
        }
    }
}
