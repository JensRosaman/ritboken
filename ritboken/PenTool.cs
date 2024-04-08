using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal class PenTool : DrawBase
    {
        public PenTool(Color color, int width) : base(color, width)
        {

        }

        public override void Draw(MouseEventArgs e, Point prevLocation, Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawLine(pen, prevLocation, e.Location);
        }
    }
}
