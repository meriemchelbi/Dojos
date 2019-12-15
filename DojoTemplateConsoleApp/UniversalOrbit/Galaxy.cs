using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DojoTemplateConsoleApp.UniveralOrbit
{
    public class Galaxy
    {
        public Galaxy()
        {
            Root = new SpaceBody("COM");
            _spaceBodyFactory = new SpaceBodyFactory();
            SpaceBodies = new List<SpaceBody>() { Root };
        }

        public List<SpaceBody> SpaceBodies { get; set; }
        public List<string> Input { get; set; }
        public readonly SpaceBody Root;
        private readonly SpaceBodyFactory _spaceBodyFactory;

        public void LoadInput()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"UniversalOrbit\UniversalOrbit.txt");
            Input = System.IO.File.ReadAllLines(path).ToList();
        }

        public void LoadSpaceBodies()
        {
            foreach (var orbit in Input)
            {
                var orbitName = orbit.Substring(0, 3);
                var satelliteName = orbit.Substring(4, 3);
                var spaceBody = FindBody(orbitName);
                var satellite = FindBody(satelliteName);

                if (spaceBody == null && satellite == null)
                {
                    spaceBody = _spaceBodyFactory.CreateSpaceBodyWithSatellite(orbit);
                    satellite = spaceBody.Satellites[0];
                    SpaceBodies.Add(spaceBody);
                    SpaceBodies.Add(satellite);
                }
                else if (spaceBody == null && satellite != null)
                {
                    spaceBody = _spaceBodyFactory.CreateSpaceBodyWithoutSatellite(orbitName);
                    spaceBody.Satellites.Add(satellite);
                    SpaceBodies.Add(spaceBody);
                }
                else if (spaceBody != null
                    && !spaceBody.Satellites.Any(s => s.Name.Equals(satelliteName)))
                {
                    if (satellite is null)
                    {
                        var newSatellite = _spaceBodyFactory.CreateSatellite(spaceBody, orbit);
                        SpaceBodies.Add(newSatellite);
                    }
                    else
                    {
                        spaceBody.Satellites.Add(satellite);
                    }
                }
            }
        }
        
        public SpaceBody FindBody(string name)
        {
            return SpaceBodies.Find(s => s.Name.Equals(name));
        }

        public int CalculateTotalOrbits(SpaceBody spaceBody, int depth = 0)
        {
            var totalOrbit = spaceBody.Satellites.Count + depth;
            depth += 1;

            foreach (var satellite in spaceBody.Satellites)
            {

                totalOrbit += CalculateTotalOrbits(satellite, depth) - 1;
            }

            // totalOrbit;

            return totalOrbit;
        }
    }
}
