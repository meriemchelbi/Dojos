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

        //public void Run()
        //{
        //    // Check for new jobs
        //    // Register new job
        //    // Assign job to lift
        //    // Move lifts by 1
        //}

        public void MoveLift(Passenger caller)
        {
            var lift = _lifts.FirstOrDefault();

            if (!lift.Passengers.Any())
            {
                lift.Call(caller);
            }

            bool callerOnLiftPath = lift.CallerOnWay(caller);
            bool callerGoingLiftDirection = lift.GoingSameDirection(caller);

            if (!callerOnLiftPath || !callerGoingLiftDirection)
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
