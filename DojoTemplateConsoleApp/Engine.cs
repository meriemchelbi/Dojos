using System.Collections.Generic;
using System.Linq;

namespace DojoTemplateConsoleApp
{
    public class Engine
    {
        private readonly IEnumerable<ILift> _lifts;
        private readonly ControlPanel _controlPanel;

        public Engine(params ILift[] lifts)
        {
            _lifts = lifts;
            _controlPanel = new ControlPanel();
        }
        public Queue<Passenger> JobQueue { get; set; }

        //public void Run()
        //{
        //    // Check for new jobs
        //    // Register new job
        //    // Assign job to lift
        //    // Move lifts by 1
        //}

        public void CallLift(Passenger caller)
        {
            var lift = _lifts.FirstOrDefault();

            lift.Call(caller);
            
            // if lift has no passenger, call lift
            // if lift has passenger and caller on the way and going to or beyond passenger destination, call lift
            // if lift has passenger and caller on way and going opposite direction, add caller to job queue and move lift
        }
    }
}
