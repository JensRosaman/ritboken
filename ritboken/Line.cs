using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal class Line : BaseDraw
    {
        public Line(Color color, int width) : base(color, width)
        {

        }

        public void draw(MouseEventArgs e, Point prevLocation, Graphics g)
        {
            g.DrawLine(new Pen(color,width),new Point(100,100), e.Location);
        }
    }
}
