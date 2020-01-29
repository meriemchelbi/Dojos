using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace DojoTemplateConsoleApp
{
    public class LiftOrchestrator
    {
        private List<Lift> _lifts;
        public int TopFloor { get; private set; }
        public LiftOrchestrator()
        {
            TopFloor = 10;
            _lifts = new List<Lift> { new Lift(TopFloor) };
        }
    }
}
