using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using NSubstitute;
using DojoTemplateConsoleApp;

namespace DojoTemplateTestProject
{
    public class SpaceImageFormatTests
    {
        [Fact]
        public void IsolateLayersCreatesLayers()
        {
            var imagePixels = "123456789012";
            var layerWidth = 3;
            var layerHeight = 2;
            var substitute = Substitute.For<SpaceImageFormat>();
            var expectedLayers = new Dictionary<int, List<string>>()
            {
                { 1, new List<string>(){ "123", "456" } },
                { 2 ,new List<string>(){ "789", "012" } }
            };

            substitute.IsolateLayers(imagePixels, layerWidth, layerHeight);

            substitute.Layers.Should().BeEquivalentTo(expectedLayers);
        }

        [Theory]
        [InlineData("1224", "5241", "9444", 4, 5)]
        [InlineData("15554", "52415", "59444", 5, 6)]
        public void CountInstancesOfDigitInLayerReturnsCorrectCount(string line1, string line2, string line3, int digit, int count)
        {
            var layer = new List<string>() { line1, line2, line3 };
            var sut = new SpaceImageFormat();

            var actualCount = sut.CountInstancesOfDigit(layer, digit);

            actualCount.Should().Equals(count);
        }


        [Fact]
        public void FindLayerWithFewestDigitInstancesReturnsCorrectLayer()
        {

        }
    }
}
