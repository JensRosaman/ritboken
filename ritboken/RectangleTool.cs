using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal class RectangleTool : PostDrawBase
    {
        public bool smoothEdges = true; // kanterna blir runda pga pen inställningarna så ger användaren alternativ att stänga av det
        public RectangleTool(Color color, int width) : base(color, width)
        {
            
        }

        public override void Draw(MouseEventArgs e, Point prevLocation, Graphics g)
        {
            // hitta vänstra hörnet
            int x = Math.Min(prevLocation.X, e.Location.X);
            int y = Math.Min(prevLocation.Y, e.Location.Y);
            int width = Math.Abs(e.Location.X - prevLocation.X);
            int height = Math.Abs(e.Location.Y - prevLocation.Y);
            if(base.fillShapes)
            {
                g.FillRectangle(new SolidBrush(color),x, y, width, height);
            }
            else if (!smoothEdges)
            {
                g.DrawRectangle(pen, x, y, width, height);
            }
            else
            {
                g.DrawRectangle(new Pen(color,base.width), x, y, width, height);

            }
          
            
        }

        public override void DrawPreview(Graphics g)
        {

            int x = Math.Min(mouseDownLoc.X, currMouseLoc.X);
            int y = Math.Min(mouseDownLoc.Y, currMouseLoc.Y);
            int width = Math.Abs(currMouseLoc.X - mouseDownLoc.X);
            int height = Math.Abs(currMouseLoc.Y - mouseDownLoc.Y);

            if(base.fillShapes)
            {
                g.FillRectangle(new SolidBrush(color), x, y, width, height);
            }
            else if(!smoothEdges)
            {
                g.DrawRectangle(pen, x, y, width, height);

            }
            else
            {
                g.DrawRectangle(new Pen(color, base.width), x, y, width, height);
            }
        }
    }
}
