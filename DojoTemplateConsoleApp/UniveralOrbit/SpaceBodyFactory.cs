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

        public void CreateSatellite(SpaceBody parent, string input)
        {
            parent.Satellites.Add(new SpaceBody(input.Substring(4, 3)));
        }
    }
}
