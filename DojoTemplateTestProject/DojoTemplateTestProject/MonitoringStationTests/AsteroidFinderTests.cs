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
            var asteroidFinder = new AsteroidFinder();
            asteroidFinder.Map = new char[][]
            {
                new char[]{ '#', '.', '.', '#' },
                new char[]{ '.', '.', '.', '#' },
                new char[]{ '.', '.', '#', '.' },
                new char[]{ '.', '#', '.', '.' }
            };
            var expectedAsteroids = new List<Asteroid>
            {
                new Asteroid(0, 3),
                new Asteroid(1, 3),
                new Asteroid(2, 2),
                new Asteroid(0, 0),
                new Asteroid(3, 1)
            };

            asteroidFinder.LoadAsteroids();

            asteroidFinder.Asteroids.Should().BeEquivalentTo(expectedAsteroids);
        }

        [Theory]
        [ClassData(typeof(MonitoringStationTestData))]
        public void FindMonitoringStationPositionIdentifiesCorrectAsteroid(string[][] map, (int, int) expectedResult)
        {
            var asteroidFinder = new AsteroidFinder();
            var result = asteroidFinder.FindMonitoringStationPosition(map);

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}

