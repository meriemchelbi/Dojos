using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DojoTemplateConsoleApp.MonitoringStation
{
    public class MonitoringStationInputParser
    {
        private readonly AsteroidFinder _asteroidFinder;
        public MonitoringStationInputParser(AsteroidFinder asteroidFinder)
        {
            _asteroidFinder = asteroidFinder;
        }

        public void ParseInput()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"MonitoringStation\MonitoringStationInput.txt");
            _asteroidFinder.Input = System.IO.File.ReadAllLines(path);
        }
        
        public void LoadInputToMap()
        {
            _asteroidFinder.Map = new char[][] { };

            _asteroidFinder.Map = _asteroidFinder.Input.Select(line => line.ToCharArray()).ToArray();
        }

    }
}
