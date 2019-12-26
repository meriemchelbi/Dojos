using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.CrossedWires
{
    public class Segment
    {
        public Segment(string direction, string incline, (int, int) start, (int, int) end)
        {
            Direction = direction;
            Incline = incline;
            StartPoint = start;
            EndPoint = end;
        }

        public string Direction { get; set; }
        public string Incline { get; set; }
        public (int, int) StartPoint { get; set; }
        public (int, int) EndPoint { get; set; }
    }
}
