using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.MonitoringStation
{
    public class AsteroidFinder
    {
        public string[] Input { get; set; }
        public char[][] Map { get; set; }
        public List<Asteroid> Asteroids { get; set; }
        public List<Axis> Axes { get; set; }

        public AsteroidFinder()
        {
            Asteroids = new List<Asteroid>();
            Axes = new List<Axis>();
        }

        public void LoadAsteroids()
        {
            for (int i = 0; i < Map.Length; i++)
            {
                for (int j = 0; j < Map.Length; j++)
                {
                    if (Equals(Map[i][j], '#'))
                    {
                        Asteroids.Add(new Asteroid(i, j));
                    } 
                }
            }
        }

        public (int, int) FindMonitoringStationPosition(string[][] map)
        {
            return (x: 9, y: 9);
        }

        
    }
}
