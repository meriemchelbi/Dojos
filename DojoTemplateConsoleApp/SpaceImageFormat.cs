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
            Layers = new List<Layer>();
        }
        public List<Layer> Layers { get; set; }

        public void IsolateLayers(string imagePixels, int layerWidth, int layerHeight)
        {
            var noOfLayers = imagePixels.Length / (layerHeight * layerWidth);

            for (int i = 1; i <= noOfLayers; i++)
            {
                var layer = new Layer(i, layerHeight, layerWidth);

                for (int lineNo = 0; lineNo < layerHeight; lineNo++)
                {
                    var stringBuilder = new StringBuilder();

                    for (int pixel = 0; pixel < layerWidth; pixel++) 
                    {
                        var selectedPixel = imagePixels[pixel];
                        stringBuilder.Append(selectedPixel);
                    }

                    var line = stringBuilder.ToString();
                    layer.Lines.Add(line);
                    imagePixels = imagePixels.Remove(0, 3);
                }

                Layers.Add(layer);
            }
        }

        public object CountInstancesOfDigit(Layer layer, int digit)
        {
            var stringDigit = digit.ToString();
            var digitCount = 0;

            foreach (var line in layer.Lines)
            {
                digitCount += line.Count(c => digit.Equals(c));
            }

            return digitCount;
        }

    }

    public class Layer
    {
        public Layer(int id, int height = 0, int width = 0)
        {
            LayerID = id;
            Height = height;
            Width = width;
            Lines = new List<string>();
        }

        public int LayerID { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public List<string> Lines { get; set; }
    }
}
