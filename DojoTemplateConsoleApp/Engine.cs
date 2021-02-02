using System.Collections.Generic;
using System.Linq;
using DojoTemplateConsoleApp.Extensions;

namespace DojoTemplateConsoleApp
{
    public class Engine
    {
        private readonly IEnumerable<ILift> _lifts;
        private readonly ControlPanel _controlPanel;

        public Queue<Passenger> JobQueue { get; set; }

        public Engine(params ILift[] lifts)
        {
            _lifts = lifts;
            _controlPanel = new ControlPanel();
            JobQueue = new Queue<Passenger>();
        }

        public void MoveLift(Passenger caller = null)
        {
            var lift = _lifts.FirstOrDefault();
            bool callerOnLiftPath = lift.CallerOnWay(caller);
            bool callerGoingLiftDirection = lift.GoingSameDirection(caller);

            if (JobQueue.Any())
            {
                lift.Call(JobQueue.Dequeue());
                if (caller != null)
                {
                    JobQueue.Enqueue(caller);
                }
            }
            
            else if (caller is null & !JobQueue.Any())
                lift.Move();

            
            else if (!lift.Passengers.Any())
            {
                lift.Call(caller);
            }

            else if (!callerOnLiftPath || !callerGoingLiftDirection)
            {
                JobQueue.Enqueue(caller);
                lift.Move();
            }

            else
            {
                lift.Call(caller);
            }
        }
    }
}
