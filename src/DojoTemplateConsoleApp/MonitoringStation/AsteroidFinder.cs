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

        public void CountVisibleAsteroids(SpaceTile referenceAsteroid)
        {
            var visible = new List<SpaceTile>();
            var quadrants = FindQuadrants(referenceAsteroid);

            foreach (var quadrant in quadrants)
            {
                var visibleInQuadrant = new List<SpaceTile>();
                var intersect = visible.Intersect(quadrant).ToList();
                intersect.ForEach(asteroid => visibleInQuadrant.Add(asteroid));

                foreach (var inner in quadrant.Except(new SpaceTile[] { referenceAsteroid }))
                {
                    foreach (var outer in quadrant.Except(new SpaceTile[] { referenceAsteroid }))
                    {
                        var collinear = AreCollinear(referenceAsteroid, outer, inner);
                        var innerCollinearWithCounted = visibleInQuadrant.Any(a => AreCollinear(a, referenceAsteroid, inner));
                        var outerCollinearWithCounted = visibleInQuadrant.Any(a => AreCollinear(a, referenceAsteroid, outer));
                        
                        if (!visible.Contains(inner) && collinear && !innerCollinearWithCounted)
                        {
                            visible.Add(inner);
                            visibleInQuadrant.Add(inner);
                        }
                        if (!visible.Contains(outer) && collinear && !outerCollinearWithCounted)
                        {
                            visible.Add(outer);
                            visibleInQuadrant.Add(outer);
                        }
                    }
                }
            }

            referenceAsteroid.VisibleAsteroids = visible.Count();
        }

        private bool AreCollinear(SpaceTile outer, SpaceTile referenceAsteroid, SpaceTile inner)
        {
            var a = outer.X * (referenceAsteroid.Y - inner.Y) +
                referenceAsteroid.X * (inner.Y - outer.Y) +
                inner.X * (outer.Y - referenceAsteroid.Y);

            return a == 0;
        }

        private List<List<SpaceTile>> FindQuadrants(SpaceTile referencePoint)
        {
            var lowerRight = Asteroids.Where(a => referencePoint.X <= a.X && referencePoint.Y <= a.Y).ToList();
            var lowerLeft = Asteroids.Where(a => referencePoint.X >= a.X && referencePoint.Y <= a.Y).ToList();
            var upperLeft = Asteroids.Where(a => referencePoint.X >= a.X && referencePoint.Y >= a.Y).ToList();
            var upperRight = Asteroids.Where(a => referencePoint.X <= a.X && referencePoint.Y >= a.Y).ToList();

            return new List<List<SpaceTile>> { lowerLeft, lowerRight, upperLeft, upperRight };
        }

        public int FindMonitoringStationPosition()
        {
            var highest = int.MinValue;

            foreach (var asteroid in Asteroids)
            {
                highest = Math.Max(highest, asteroid.VisibleAsteroids);
            }

            return highest;
        }
    }
}
