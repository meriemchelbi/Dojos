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
            _root = new SpaceBody("COM");
            _spaceBodyFactory = new SpaceBodyFactory();
            SpaceBodies = new List<SpaceBody>();
        }

        public List<SpaceBody> SpaceBodies { get; set; }
        public List<string> Input { get; set; }
        private readonly SpaceBody _root;
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
                var spaceBody = _spaceBodyFactory.CreateSpaceBodyWithSatellite(orbit);
                SpaceBodies.Add(spaceBody);
            }
        }
        
        public void FindBody(string name)
        {

        }



    }
}
