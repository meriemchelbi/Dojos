using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.MonitoringStation
{
    public class SpaceTile
    {
        public SpaceTile(int x, int y, bool isAsteroid)
        {
            Coordinates = (x: x, y: y);
            IsAsteroid = isAsteroid;
        }
        public (int, int) Coordinates { get; set; }
        public int VisibleAsteroids { get; set; }
        public bool IsAsteroid { get; set; }
    }
}
