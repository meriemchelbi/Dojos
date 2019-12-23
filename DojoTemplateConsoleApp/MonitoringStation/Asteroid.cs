using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.MonitoringStation
{
    public class Asteroid
    {
        public Asteroid(int x, int y)
        {
            Coordinates = (x: x, y: y);
        }
        public (int, int) Coordinates { get; set; }
        public int VisibleAsteroids { get; set; }
    }
}
