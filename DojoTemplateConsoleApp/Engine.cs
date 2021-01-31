using System.Collections.Generic;
using System.Linq;

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

            // if lift has passenger and caller not on way, add caller to job queue and move lift
            if (!callerOnLiftPath)
            {
                JobQueue.Enqueue(caller);
                lift.Move();
            }

            // if lift has passenger and caller on way and going opposite direction, add caller to job queue and move lift
            
            // if lift has passenger and caller on the way and going to or beyond passenger destination, call lift
        }
    }
}
