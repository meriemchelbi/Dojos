using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.CrossedWires
{
    public class Segment
    {
        public Segment(string direction, string incline, (int, int) start, (int, int) end, int wire)
        {
            Direction = direction;
            Incline = incline;
            StartPoint = start;
            EndPoint = end;
            Wire = wire;
        }
        public string Direction { get; }
        public string Incline { get; }
        public int NumOfSteps { get; set; }
        public (int, int) StartPoint { get; }
        public (int, int) EndPoint { get; }
        public int Wire { get; }

        public bool Equals(Segment segment)
        {
            var result =
                this.Direction.Equals(segment.Direction)
                && this.Incline.Equals(segment.Incline)
                && this.NumOfSteps == segment.NumOfSteps
                && this.StartPoint == segment.StartPoint
                && this.EndPoint == segment.EndPoint
                && this.Wire == segment.Wire;

            return result;
        }
    }
}
