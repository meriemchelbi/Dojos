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


        // using Bresenham's line drawing algorithm https://www.codeproject.com/Articles/15604/Ray-casting-in-a-2D-tile-based-environment
        public IEnumerable<SpaceTile> CastRay(SpaceTile origin, SpaceTile destination)
        {
            var copyOrigin = new SpaceTile(origin.X, origin.Y);
            var copyDestination = new SpaceTile(destination.X, destination.Y);

            var deltaX = copyDestination.X - copyOrigin.X;
            var deltaY = Math.Abs(copyDestination.Y - copyOrigin.Y);
            var steep = deltaY > Math.Abs(deltaX);
            int temp;

            if (steep)
            {
                temp = copyOrigin.X; // swap copyOrigin.X and copyOrigin.Y
                copyOrigin.X = copyOrigin.Y;
                copyOrigin.Y = temp;
                temp = copyDestination.X; // swap copyDestination.X and copyDestination.Y
                copyDestination.X = copyDestination.Y;
                copyDestination.Y = temp;
            }
            if (copyOrigin.X > copyDestination.X)
            {
                temp = copyOrigin.X; // swap copyOrigin.X and copyDestination.X
                copyOrigin.X = copyDestination.X;
                copyDestination.X = temp;
                temp = copyOrigin.Y; // swap copyOrigin.Y and copyDestination.Y
                copyOrigin.Y = copyDestination.Y;
                copyDestination.Y = temp;
            }
            
            var error = deltaX / 2;
            var yStep = (copyOrigin.Y < copyDestination.Y) ? 1 : -1;
            var y = copyOrigin.Y;
            for (var x = copyOrigin.X; x <= copyDestination.X; x++)
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
        public void CountVisibleAsteroids(SpaceTile originAsteroid)
        {
            Asteroids = Asteroids.Select(a => { a.Counted = false; return a; }).ToList();
            // for each asteroid in my list
            foreach (var asteroid in Asteroids)
            {
                // if the asteroid hasn't already been counted
                if (asteroid.Counted == false)
                {
                    var ray = CastRay(originAsteroid, asteroid).ToList();
                    originAsteroid.VisibleAsteroids += 1;

                    foreach (var spaceTile in ray)
                    {
                        foreach (var a in Asteroids)
                        {
                            var match = spaceTile.X == a.X && spaceTile.Y == a.Y;
                            if (match)
                            {
                                a.Counted = true;
                            }
                        }
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
