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
            var BodyB = new SpaceBody("BAA");
            var BodyC = new SpaceBody("CBB");
            var BodyD = new SpaceBody("DCC");
            var BodyE = new SpaceBody("EDD");
            var BodyF = new SpaceBody("FEE");
            var BodyG = new SpaceBody("GFF");
            var BodyH = new SpaceBody("HGG");
            var BodyI = new SpaceBody("IHH");
            var BodyJ = new SpaceBody("JII");
            var BodyK = new SpaceBody("KJJ");
            var BodyL = new SpaceBody("LKK");
            var COM = new SpaceBody("COM");

            BodyB.Satellites.Add(BodyC);
            BodyB.Satellites.Add(BodyG);
            BodyC.Satellites.Add(BodyD);
            BodyD.Satellites.Add(BodyE);
            BodyD.Satellites.Add(BodyI);
            BodyE.Satellites.Add(BodyF);
            BodyE.Satellites.Add(BodyJ);
            BodyG.Satellites.Add(BodyH);
            BodyJ.Satellites.Add(BodyK);
            BodyK.Satellites.Add(BodyL);
            COM.Satellites.Add(BodyB);

            var sut = new Galaxy
            {
                Input = new List<string> { "BAA)CBB", "COM)BAA", "CBB)DCC", "DCC)EDD", "EDD)FEE",
                    "BAA)GFF", "GFF)HGG", "DCC)IHH", "EDD)JII", "JII)KJJ", "KJJ)LKK" },
            };
            var expectedSpaceBodies = new List<SpaceBody> { COM, BodyB, BodyC, BodyD, BodyE, BodyF, BodyG, BodyH, BodyI, BodyJ, BodyK, BodyL };
            var expectedRoot = new SpaceBody("COM") { Satellites = new List<SpaceBody> { BodyB } };
             
            sut.LoadSpaceBodies();

            sut.Root.Should().BeEquivalentTo(expectedRoot);
            sut.SpaceBodies.Should().BeEquivalentTo(expectedSpaceBodies);
        }

        [Fact]
        public void CalculateTotalOrbitsCalculatesExpectedNumberOfOrbits()
        {
            var BodyB = new SpaceBody("BAA");
            var BodyC = new SpaceBody("CBB");
            var BodyD = new SpaceBody("DCC");
            var BodyE = new SpaceBody("EDD");
            var BodyF = new SpaceBody("FEE");
            var BodyG = new SpaceBody("GFF");
            var BodyH = new SpaceBody("HGG");
            var BodyI = new SpaceBody("IHH");
            var BodyJ = new SpaceBody("JII");
            var BodyK = new SpaceBody("KJJ");
            var BodyL = new SpaceBody("LKK");
            var COM = new SpaceBody("COM");

            BodyB.Satellites.Add(BodyC);
            BodyB.Satellites.Add(BodyG);
            BodyC.Satellites.Add(BodyD);
            BodyD.Satellites.Add(BodyE);
            BodyD.Satellites.Add(BodyI);
            BodyE.Satellites.Add(BodyF);
            BodyE.Satellites.Add(BodyJ);
            BodyG.Satellites.Add(BodyH);
            BodyJ.Satellites.Add(BodyK);
            BodyK.Satellites.Add(BodyL);
            COM.Satellites.Add(BodyB);

            var sut = new Galaxy { SpaceBodies = new List<SpaceBody> { COM, BodyB, BodyC, BodyD, BodyE, BodyG, BodyJ, BodyK} };

            var result = sut.CalculateTotalOrbits(COM);

            result.Should().Be(42);

        }

        [Fact]
        public void CalculateOrbitalTransfersReturnsCorrectTotal()
        {
            var BodyB = new SpaceBody("BAA");
            var BodyC = new SpaceBody("CBB");
            var BodyD = new SpaceBody("DCC");
            var BodyE = new SpaceBody("EDD");
            var BodyF = new SpaceBody("FEE");
            var BodyG = new SpaceBody("GFF");
            var BodyH = new SpaceBody("HGG");
            var BodyI = new SpaceBody("IHH");
            var BodyJ = new SpaceBody("JII");
            var BodyK = new SpaceBody("KJJ");
            var BodyL = new SpaceBody("LKK");
            var COM = new SpaceBody("COM");
            var YOU = new SpaceBody("YOU");
            var SAN = new SpaceBody("SAN");

            BodyB.Satellites.Add(BodyC);
            BodyB.Satellites.Add(BodyG);
            BodyC.Satellites.Add(BodyD);
            BodyD.Satellites.Add(BodyE);
            BodyD.Satellites.Add(BodyI);
            BodyE.Satellites.Add(BodyF);
            BodyE.Satellites.Add(BodyJ);
            BodyG.Satellites.Add(BodyH);
            BodyJ.Satellites.Add(BodyK);
            BodyK.Satellites.Add(BodyL);
            COM.Satellites.Add(BodyB);
            BodyI.Satellites.Add(SAN);
            BodyK.Satellites.Add(YOU);

            var sut = new Galaxy { SpaceBodies = new List<SpaceBody> { COM, BodyB, BodyC, BodyD, BodyE, BodyG, BodyJ, BodyK } };

            var result = sut.CalculateOrbitalTransfer(YOU, SAN);

            result.Should().Be(4);
        }
    }
}
