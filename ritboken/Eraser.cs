using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal class Eraser : DrawBase
    {
        public Eraser(Color color, int width) : base(color, width)
        { 
        }

        public override void Draw(MouseEventArgs e, Point prevLocation, Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawLine(pen, prevLocation, e.Location);
        }
    }
}
