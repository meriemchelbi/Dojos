using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.UniveralOrbit
{
    public class Galaxy
    {
        private readonly SpaceBody _root;
        public List<SpaceBody> SpaceBodies { get; set; }
        public List<string> Input { get; set; }

        public Galaxy()
        {
            _root = new SpaceBody("COM");
            SpaceBodies = new List<SpaceBody>();
        }
        public void LoadBodies()
        {

        }
        
        public void FindBody(string name)
        {

        }



    }
}
