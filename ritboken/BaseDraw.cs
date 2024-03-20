﻿using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal class BaseDraw
    {
        Color color;
        int width;
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
                Pen pen = new Pen(Color.Black, 4);

                // Rita en linje från föregående musposition till nuvarande musposition med den svarta pennan
                g.DrawLine(pen, prevLocation, e.Location);
            
        }
    }

}
