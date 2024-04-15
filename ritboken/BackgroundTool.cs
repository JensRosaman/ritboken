﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal class BackgroundTool : DrawBase
    {
        public BackgroundTool(Color color, int width) : base(color,width) { }

        public override void Draw(MouseEventArgs e, Point prevLocation, Graphics g)
        {
            g.Clear(color);
        }
    }
}
