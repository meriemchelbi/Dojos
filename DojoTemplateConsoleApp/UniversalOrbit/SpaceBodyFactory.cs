using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.UniveralOrbit
{
    public class SpaceBodyFactory
    {
        public SpaceBodyFactory() { }

        public SpaceBody CreateSpaceBodyWithSatellite(string input)
        {
            var token = input.Substring(0, 3);
            return new SpaceBody(token)
            {
                Satellites = { new SpaceBody(input.Substring(4, 3)) }
            };
        }

        public SpaceBody CreateSpaceBodyWithoutSatellite(string name)
        {
            return new SpaceBody(name);
        }

        public SpaceBody CreateSatellite(SpaceBody parent, string input)
        {
            var satellite = new SpaceBody(input.Substring(4, 3));
            parent.Satellites.Add(satellite);

            return satellite;
        }
    }
}
