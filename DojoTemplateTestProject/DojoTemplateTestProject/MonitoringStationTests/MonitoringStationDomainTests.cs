using DojoTemplateConsoleApp.MonitoringStation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace DojoTemplateTestProject.MonitoringStationTests
{
    public class MonitoringStationDomainTests
    {
        [Fact]
        public void LoadInputLoadsInputToMap()
        {
            var asteroidFinder = new AsteroidFinder();
            asteroidFinder.Input = new string[]
            {
                ".#..#",
                "...#.",
                "#####",
                ".....",
                "....#",
                "...##"
            };
            var sut = new MonitoringStationInputParser(asteroidFinder);
            var expected = new char[][]
                    {
                        new char[] {'.', '#', '.', '.', '#' },
                        new char[] {'.', '.', '.', '#', '.' },
                        new char[] {'#', '#', '#', '#', '#' },
                        new char[] {'.', '.', '.', '.', '.' },
                        new char[] {'.', '.', '.', '.', '#' },
                        new char[] {'.', '.', '.', '#', '#' }
                    };

            sut.LoadInputToMap();
           
            asteroidFinder.Map.Should().BeEquivalentTo(expected);
        }
    }
}
