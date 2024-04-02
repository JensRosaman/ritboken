using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal class Pensel : DrawBase
    {
        public Pensel(Color color, int width) : base(color, width)
        {

        }

        public override void Draw(MouseEventArgs e, Point prevLocation, Graphics g)
        {
            g.DrawLine(new Pen(color, width), prevLocation, e.Location);
        }
    }
}
