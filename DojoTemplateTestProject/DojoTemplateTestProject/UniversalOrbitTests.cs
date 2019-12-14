using DojoTemplateConsoleApp.UniveralOrbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DojoTemplateTestProject
{
    public class UniversalOrbitTests
    {
        [Fact]
        public void CreateSpaceBodyCreatesNodeWithSatellite()
        {
            var input = "B)C";
            var nodeFactory = new SpaceBodyFactory();
            var node = nodeFactory.CreateSpaceBodyWithSatellite(input);

            Assert.Equal("B", node.Name);
            Assert.Equal("C", node.Satellites.Single().Name);
        }

        [Theory]
        [InlineData("B)C", "B", "C")]
        public void CreateSatelliteCreatesSatellite(string input, string parentName, string satelliteName)
        {
            var nodeFactory = new SpaceBodyFactory();
            var parent = new SpaceBody(parentName);
            nodeFactory.CreateSatellite(parent, input);

            Assert.Equal(satelliteName, parent.Satellites.Single().Name);
        }

        [Fact]
        public void LoadBodiesLoadsSpaceBodiesToGalaxy()
        {
            
        }


    }
}
