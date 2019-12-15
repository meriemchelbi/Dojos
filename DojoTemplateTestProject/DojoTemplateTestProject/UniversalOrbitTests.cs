using DojoTemplateConsoleApp.UniveralOrbit;
using FluentAssertions;
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
        public void CreateSpaceBodyCreatesSpaceBodyWithSatellite()
        {
            var input = "BAA)CBB";
            var nodeFactory = new SpaceBodyFactory();
            var node = nodeFactory.CreateSpaceBodyWithSatellite(input);

            Assert.Equal("BAA", node.Name);
            Assert.Equal("CBB", node.Satellites.Single().Name);
        }

        [Theory]
        [InlineData("BAA)CBB", "BAA", "CBB")]
        public void CreateSatelliteCreatesSatelliteWithParent(string input, string parentName, string satelliteName)
        {
            var nodeFactory = new SpaceBodyFactory();
            var parent = new SpaceBody(parentName);
            nodeFactory.CreateSatellite(parent, input);

            Assert.Equal(satelliteName, parent.Satellites.Single().Name);
        }

        [Fact]
        public void LoadSpaceBodiesLoadsSpaceBodiesToGalaxy()
        {
            var sut = new Galaxy();
            sut.Input = new List<string> { "HDK)71F", "COM)RC1", "PBL)CH6", "Z4V)SDL", "V8J)2XG"};
            var expectedSpaceBodies = new List<SpaceBody>
            {
                new SpaceBody("HDK"){Satellites = new List<SpaceBody>{new SpaceBody("71F")} },
                new SpaceBody("COM"){Satellites = new List<SpaceBody>{new SpaceBody("RC1")} },
                new SpaceBody("PBL"){Satellites = new List<SpaceBody>{new SpaceBody("CH6")} },
                new SpaceBody("Z4V"){Satellites = new List<SpaceBody>{new SpaceBody("SDL")} },
                new SpaceBody("V8J"){Satellites = new List<SpaceBody>{new SpaceBody("2XG")} }
            };

            sut.LoadSpaceBodies();

            sut.SpaceBodies.Should().BeEquivalentTo(expectedSpaceBodies);

        }


    }
}
