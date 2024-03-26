using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal class BaseDraw
    {
        public Color color;
        public int width;
        Pen pen;

        public BaseDraw(Color color, int width)
        {
            this.color = color;
            this.width = width;
            pen = new Pen(color);   

        }
        public int Width { get { return width; } }

       
        public void draw(MouseEventArgs e, Point prevLocation, Graphics g) {
            
                // Skapa en penna med svart färg och tjocklek 4
                Pen pen = new Pen(color, width);

                // Rita en linje från föregående musposition till nuvarande pos
                g.DrawLine(pen, prevLocation, e.Location);
                
            
        }
    }
}
