using System;
using System.Collections.Generic;
using System.Text;

namespace DojoTemplateConsoleApp.SpaceImage
{
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
