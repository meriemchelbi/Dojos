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
        public List<SpaceTile> Asteroids { get; set; }

        public AsteroidFinder()
        {
            Asteroids = new List<SpaceTile>();
        }

        public void LoadAsteroids()
        {
            for (int i = 0; i < Map.Length; i++)
            {
                for (int j = 0; j < Map.Length; j++)
                {
                    if (Equals(Map[i][j], '#'))
                    {
                        Asteroids.Add(new SpaceTile(i, j)
                        {
                            IsAsteroid = true
                        });
                    }
                }
            }
        }

        public IEnumerable<SpaceTile> CastRay(SpaceTile origin, SpaceTile destination)
        {
            var deltaX = destination.X - origin.X;
            var deltaY = Math.Abs(destination.Y - origin.Y);
            var steep = deltaY > Math.Abs(deltaX);
            int temp;

            if (steep)
            {
                temp = origin.X; // swap origin.X and origin.Y
                origin.X = origin.Y;
                origin.Y = temp;
                temp = destination.X; // swap destination.X and destination.Y
                destination.X = destination.Y;
                destination.Y = temp;
            }
            if (origin.X > destination.X)
            {
                temp = origin.X; // swap origin.X and destination.X
                origin.X = destination.X;
                destination.X = temp;
                temp = origin.Y; // swap origin.Y and destination.Y
                origin.Y = destination.Y;
                destination.Y = temp;
            }
            
            var error = deltaX / 2;
            var yStep = (origin.Y < destination.Y) ? 1 : -1;
            var y = origin.Y;
            for (var x = origin.X; x <= destination.X; x++)
            {
                yield return new SpaceTile((steep ? y : x), (steep ? x : y));
                error -= deltaY;
                if (error < 0)
                {
                    y += yStep;
                    error += deltaX;
                }
            }
            
            yield break;
        }

        public (int, int) FindMonitoringStationPosition(string[][] map)
        {
            return (x: 9, y: 9);
        }

        
    }
}
