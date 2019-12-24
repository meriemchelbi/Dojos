using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NSubstitute;
using FluentAssertions;
using DojoTemplateConsoleApp.MonitoringStation;
using System.Collections;
using System.Linq;

namespace DojoTemplateTestProject.MonitoringStationTests
{
    public class AsteroidFinderTests
    {
        [Fact]
        public void LoadAsteroidsLoadsAsteroidsToList()
        {
            var asteroidFinder = new AsteroidFinder
            {
                Map = new char[][]
            {
                new char[]{ '#', '.', '.' },
                new char[]{ '.', '.', '#' },
                new char[]{ '.', '#', '#' }
            }
            };
            var expectedAsteroids = new List<SpaceTile>
            {
                new SpaceTile(0, 0){ IsAsteroid = true },
                new SpaceTile(1, 2){ IsAsteroid = true },
                new SpaceTile(2, 1){ IsAsteroid = true },
                new SpaceTile(2, 2){ IsAsteroid = true }
            };

            asteroidFinder.LoadAsteroids();

            asteroidFinder.Asteroids.Should().BeEquivalentTo(expectedAsteroids);
        }

        [Theory]
        [ClassData(typeof(CastRayTestData))]
        public void CastRayShouldIntersectExpectedTiles(List<SpaceTile> asteroids, List<SpaceTile> expectedRay, int originIndex, int destinationIndex)
        {
            // Bresenham algo returns expected intersection points in the map
            var asteroidFinder = new AsteroidFinder();
            asteroidFinder.Asteroids = asteroids;

            var origin = asteroidFinder.Asteroids[originIndex];
            var destination = asteroidFinder.Asteroids[destinationIndex];

            var result = asteroidFinder.CastRay(origin, destination).ToList();

            result.Should().BeEquivalentTo(expectedRay);

        }


        //[Theory]
        //[ClassData(typeof(MonitoringStationTestData))]
        //public void FindMonitoringStationPositionIdentifiesCorrectAsteroid(string[][] map, (int, int) expectedResult)
        //{
        //    var asteroidFinder = new AsteroidFinder();
        //    var result = asteroidFinder.FindMonitoringStationPosition(map);

        //    result.Should().BeEquivalentTo(expectedResult);
        //}
    }
}

