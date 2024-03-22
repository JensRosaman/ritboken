using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal class Ellipse : BaseDraw
    {
        public Ellipse(Color color, int width) : base(color, width)
        {
        }

        public void draw(MouseEventArgs e, Point prevLocation, Graphics g)
        {
            RectangleF rectangle = new RectangleF(prevLocation, new SizeF(width,5));
            
        }
    }
}
