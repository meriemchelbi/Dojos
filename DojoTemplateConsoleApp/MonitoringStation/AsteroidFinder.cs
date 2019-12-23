using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoTemplateConsoleApp.MonitoringStation
{
    public class AsteroidFinder
    {
        public string[] Input { get; set; }
        public char[][] Map { get; set; }
        public List<SpaceTile> SpaceTiles { get; set; }

        public AsteroidFinder()
        {
            SpaceTiles = new List<SpaceTile>();
        }

        public void LoadSpaceTiles()
        {
            for (int i = 0; i < Map.Length; i++)
            {
                for (int j = 0; j < Map.Length; j++)
                {
                    var tile = Equals(Map[i][j], '#')
                        ? new SpaceTile(i, j, true)
                        : new SpaceTile(i, j, false);

                    SpaceTiles.Add(tile);
                }
            }
        }

        public (int, int) FindMonitoringStationPosition(string[][] map)
        {
            return (x: 9, y: 9);
        }

        
    }
}
