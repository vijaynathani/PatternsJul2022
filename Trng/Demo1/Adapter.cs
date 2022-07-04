using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trng.Demo1
{
    class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

    }
    internal class Adapter
    {
        private readonly Rectangle r;
        public Adapter(Rectangle r1) => r = r1;
        public void setHeightAndWidth(int width, int height)
        {
            r.Height = height;
            r.Width = width;
        }
    }
    class AdapterMain
    {
        public void Main1()
        {
            Rectangle r = new Rectangle();
            var a = new Adapter(r);
            a.setHeightAndWidth(20, 50);
        }
    }
}
