using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoTemplateConsoleApp
{
    public class SpaceImageFormat
    {
        public SpaceImageFormat()
        {
            Layers = new Dictionary<int, List<string>>();
        }
        public Dictionary<int, List<string>> Layers { get; set; }

        public void IsolateLayers(string imagePixels, int layerWidth, int layerHeight)
        {
            var noOfLayers = imagePixels.Length / (layerHeight * layerWidth);

            for (int i = 1; i <= noOfLayers; i++)
            {
                var layer = new List<string>();

                for (int lineNo = 0; lineNo < layerHeight; lineNo++)
                {
                    var stringBuilder = new StringBuilder();

                    for (int pixel = 0; pixel < layerWidth; pixel++) // create line in layer
                    {
                        var selectedPixel = imagePixels[pixel];
                        stringBuilder.Append(selectedPixel);
                    }

                    var line = stringBuilder.ToString();
                    layer.Add(line);
                    imagePixels = imagePixels.Remove(0, 3);
                }

                Layers.Add(i, layer);
            }
        }

        public object CountInstancesOfDigit(List<string> layer, int digit)
        {
            var stringDigit = digit.ToString();
            var digitCount = 0;

            foreach (var line in layer)
            {
                digitCount += line.Count(c => digit.Equals(c));
            }

            return digitCount;
        }

    }

    public class Layer
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public List<string> Lines { get; set; }
    }
}
