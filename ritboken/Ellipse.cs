﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal class Ellipse : PostDrawBase
    {
        public Ellipse(Color color, int width) : base(color, width)
        {
        }

        public override void Draw(MouseEventArgs e, Point prevLocation, Graphics g)
        {

            int x = Math.Min(prevLocation.X, e.Location.X);
            int y = Math.Min(prevLocation.Y, e.Location.Y);
            int width = Math.Abs(e.Location.X - prevLocation.X);
            int height = Math.Abs(e.Location.Y - prevLocation.Y);


            if (base.fillShapes)
            {
                g.FillEllipse(new SolidBrush(_color), x, y, width, height);
            }
            else
            {
                g.DrawEllipse(pen, x, y, width, height);
            }
        }

        public override void DrawPreview(Graphics g)
        {
            int x = Math.Min(mouseDownLoc.X, currMouseLoc.X);
            int y = Math.Min(mouseDownLoc.Y, currMouseLoc.Y);
            int width = Math.Abs(currMouseLoc.X - mouseDownLoc.X);
            int height = Math.Abs(currMouseLoc.Y - mouseDownLoc.Y);

            if (base.fillShapes)
            {
                g.FillEllipse(new SolidBrush(color), x, y, width, height);

            }
            else
            {
                g.DrawEllipse(base.pen, x,y, width,height);
            }
            
        }
    }
}
