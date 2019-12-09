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
        public string Input { get; internal set; }

        public void IsolateLayers(int layerWidth, int layerHeight)
        {
            var imagePixels = Input;

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

        public int CountInstancesOfDigit(Layer layer, char digit)
        {
            var stringDigit = digit.ToString();
            var digitCount = 0;

            foreach (var line in layer.Lines)
            {
                digitCount += line.Count(c => digit.Equals(c));
            }

            return digitCount;
        }

        public Layer FindLayerWithFewestInstancesOfDigit(char digit)
        {
            Layer lowest = null;

            for (int i = 0; i < Layers.Count-1; i++)
            {
                var layerCurrentCount = CountInstancesOfDigit(Layers[i], digit);
                var layerNextCount = CountInstancesOfDigit(Layers[i+1], digit);

                if (layerCurrentCount > layerNextCount)
                {
                    lowest = Layers[i + 1];
                }
                else
                {
                    lowest = Layers[i];
                }
            }

            return lowest;
        }

        public Layer GetLayerByID(int layerID)
        {
            var layerQuery = Layers.Where(l => l.LayerID == layerID).ToArray();
            var layer = layerQuery[0];
            return layer;
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
