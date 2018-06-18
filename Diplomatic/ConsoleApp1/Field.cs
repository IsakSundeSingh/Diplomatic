using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomatic.Core
{
    public class Field
    {
        public string Name;
        public int xOffset;
        public int yOffset;
        public int Height;
        public int Width;

        public Field(string name, int x, int y, int h, int w)
        {
            Name = name;
            xOffset = x;
            yOffset = y;
            Height = h;
            Width = w;
        }
        public void Deconstruct(out string name, out int x, out int y, out int h, out int w)
        {
            name = Name;
            x = xOffset;
            y = yOffset;
            h = Height;
            w = Width;
        }
    }
}
