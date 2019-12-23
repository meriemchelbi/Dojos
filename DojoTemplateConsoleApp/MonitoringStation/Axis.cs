using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.MonitoringStation
{
    public class Axis
    {
        public Func<(int, int), (int, int)> NavigateUp { get; set; }
        public Func<(int, int), (int, int)> NavigateDown { get; set; }
    }
}
