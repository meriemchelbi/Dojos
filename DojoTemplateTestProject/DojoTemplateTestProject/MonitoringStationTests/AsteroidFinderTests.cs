using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NSubstitute;
using FluentAssertions;
using DojoTemplateConsoleApp.MonitoringStation;
using System.Collections;

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
                new SpaceTile(0, 0, true),
                new SpaceTile(0, 1, false),
                new SpaceTile(0, 2, false),
                new SpaceTile(1, 0, false),
                new SpaceTile(1, 1, false),
                new SpaceTile(1, 2, true),
                new SpaceTile(2, 0, false),
                new SpaceTile(2, 1, true),
                new SpaceTile(2, 2, true)
            };

            asteroidFinder.LoadSpaceTiles();

            asteroidFinder.SpaceTiles.Should().BeEquivalentTo(expectedAsteroids);
        }

        [Fact]
        public void CastRayShouldIntersectExpectedTiles()
        {
            // Bresenham algo returns expected intersection points in the map
            var asteroidFinder = new AsteroidFinder();
            asteroidFinder.SpaceTiles = new List<SpaceTile>
            {
                new SpaceTile(0, 0, true),
                new SpaceTile(0, 1, false),
                new SpaceTile(0, 2, false),
                new SpaceTile(1, 0, false),
                new SpaceTile(1, 1, false),
                new SpaceTile(1, 2, true),
                new SpaceTile(2, 0, false),
                new SpaceTile(2, 1, true),
                new SpaceTile(2, 2, true)
            };
            var expectedResult = new List<SpaceTile>
            {
                new SpaceTile(1, 1, false),
            };

            var tile1 = asteroidFinder.SpaceTiles[0];
            var tile9 = asteroidFinder.SpaceTiles[8];

            var result = asteroidFinder.CastRay(tile1, tile9);

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

