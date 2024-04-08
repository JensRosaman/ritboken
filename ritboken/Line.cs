using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal class Line : PostDrawBase
    {
        public Line(Color color, int width) : base(color, width)
        {

        }

        public override void Draw(MouseEventArgs e, Point prevLocation, Graphics g)
        {
            g.DrawLine(pen,prevLocation, e.Location);
        }

        public override void DrawPreview(Graphics g)
        {
            g.DrawLine(base.pen,mouseDownLoc,currMouseLoc);
        }
    }
}
