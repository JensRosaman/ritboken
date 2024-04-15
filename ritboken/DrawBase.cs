using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal abstract class DrawBase
    {
        public Color _color = Color.Red;
        private int _width;

        private Pen _pen;
        protected Pen pen // så arv klasseer också kan nå den
        {
            get { return _pen; }
            set { _pen = value;
                // gör pennan rund
                _pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                _pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            }
        }
        
       
        public int width
        {
            get { return _width; }
            set
            {
                _width = value;
                // blir kallad innan kontruktören så måste kontrollera att den har körts först
                if (pen != null)
                {
                    pen = new Pen(pen.Color, value);
                }
                
            }
        }

        public Color color
        {
            get { return _color; }
            set
            {
                _color = value;
                // uppdatera pennan med ny färg
                if (pen != null)
                {
                    pen.Color = value;
                }
            }
        }


        public DrawBase(Color color, int width)
        {
            this.color = color;
            this.width = width;
            pen = new Pen(color,width);
        }



        public abstract void Draw(MouseEventArgs e, Point prevLocation, Graphics g);
        

    }
}
