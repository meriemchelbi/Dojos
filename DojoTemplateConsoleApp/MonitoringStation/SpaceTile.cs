using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.MonitoringStation
{
    public class SpaceTile
    {
        public SpaceTile(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int VisibleAsteroids { get; set; }
        public bool IsAsteroid { get; set; }
    }
}
