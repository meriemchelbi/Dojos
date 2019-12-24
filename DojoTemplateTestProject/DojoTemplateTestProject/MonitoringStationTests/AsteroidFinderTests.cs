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

        [Fact]
        public void CastRayShouldIntersectExpectedTiles()
        {
            // Bresenham algo returns expected intersection points in the map
            var asteroidFinder = new AsteroidFinder();
            asteroidFinder.Asteroids = new List<SpaceTile>
            {
                new SpaceTile(0, 0),
                new SpaceTile(1, 2),
                new SpaceTile(2, 1),
                new SpaceTile(2, 2)
            };
            var expectedResult = new List<SpaceTile>
            {
                new SpaceTile(0, 0),
                new SpaceTile(1, 1),
                new SpaceTile(2, 2)
            };

            var tile1 = asteroidFinder.Asteroids[0];
            var tile9 = asteroidFinder.Asteroids[3];

            var result = asteroidFinder.CastRay(tile1, tile9).ToList();

            result.Should().BeEquivalentTo(expectedResult);

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

