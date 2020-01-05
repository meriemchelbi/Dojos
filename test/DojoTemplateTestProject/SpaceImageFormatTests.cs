using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using NSubstitute;
using DojoTemplateConsoleApp;
using System.Collections;
using System.Linq;
using DojoTemplateConsoleApp.SpaceImage;

namespace DojoTemplateTestProject
{
    public class SpaceImageFormatTests
    {
        [Theory]
        [InlineData('2', 0)]
        [InlineData('1', 11)]
        [InlineData('0', 15)]
        public void SpaceImageParserParsesToArray(char pixel, int expectedElementIndex)
        {
            var spaceImageFormat = new SpaceImageFormat();
            var inputParser = new InputParser();
            inputParser.ParseSpaceImageArray(spaceImageFormat);

            Assert.Equal(pixel, spaceImageFormat.InputArray[expectedElementIndex]);
        }

        [Fact]
        public void IsolateLayersCreatesLayers()
        {
            var layerWidth = 3;
            var layerHeight = 2;
            var substitute = Substitute.For<SpaceImageFormat>();
            substitute.InputArray = "123456789012".ToArray();
            var expectedLayers = new List<Layer>()
            {
                new Layer(1, layerHeight, layerWidth)
                {
                    Lines = new List<string>() { "123", "456" } ,
                },
                new Layer(2, layerHeight, layerWidth)
                {
                    Lines = new List<string>() { "789", "012" },
                }
            };

            substitute.IsolateLayersList(layerWidth, layerHeight);

            substitute.Layers.Should().BeEquivalentTo(expectedLayers);
        }

        [Theory]
        [InlineData("1224", "5241", "9444", '4', 5)]
        [InlineData("15554", "52415", "59444", '5', 6)]
        public void CountInstancesOfDigitInLayerReturnsCorrectCount(string line1, string line2, string line3, char digit, int count)
        {
            var layer = new Layer(1)
            {
                Lines = new List<string> { line1, line2, line3 }
            };
            var sut = new SpaceImageFormat();

            var actualCount = sut.CountInstancesOfDigit(layer, digit);

            actualCount.Should().Be(count);
        }


        [Theory]
        [ClassData(typeof(LayerComparisonData))]
        public void FindLayerWithFewestDigitInstancesReturnsCorrectLayer(Layer layer1, Layer layer2, Layer layer3, char digit, int expectedResult)
        {
            var substitute = Substitute.For<SpaceImageFormat>();
            substitute.Layers = new List<Layer>()
            {
                layer1,
                layer2,
                layer3
            };

            var result = substitute.FindLayerWithFewestInstancesOfDigit(digit).LayerID;

            result.Should().Be(expectedResult);
        }

        internal class LayerComparisonData: IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] 
                { 
                    new Layer(1, 2, 3)
                    {
                        Lines = new List<string>(){"111", "222"}
                    },
                    new Layer(2, 2, 3)
                    {
                        Lines = new List<string>(){"010", "333"}
                    },
                    new Layer(3, 2, 3)
                    {
                        Lines = new List<string>(){"010", "111"}
                    },
                    '1',
                    2
                };
                yield return new object[] 
                { 
                    new Layer(1, 2, 3)
                    {
                        Lines = new List<string>(){"014", "444"}
                    },
                    new Layer(2, 2, 3)
                    {
                        Lines = new List<string>(){"414", "444"}
                    },
                    new Layer(3, 2, 3)
                    {
                        Lines = new List<string>(){"421", "000"}
                    },
                    '4',
                    3
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
