using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal class BucketTool : DrawBase
    {
        public BucketTool(Color color, int width) : base(color, width) { }

        public override void Draw(MouseEventArgs e, Point prevLocation, Graphics g)
        {
            
        }
        public new void Draw(MouseEventArgs e, ref Bitmap bmp)
        {
            
            FloodFill(e.X, e.Y, bmp, bmp.GetPixel(e.X,e.Y));
            
        }
        private void FloodFill(int x, int y, Bitmap bmp, Color color2Change)
        {
            int width = bmp.Width;
            int height = bmp.Height;

            // Använd stack istälellet för att rekrusivt kalla på methoden för att undevika stack overflow och undevika röra cpu tråden
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x, y));

            while (stack.Count > 0)
            {
                Point point = stack.Pop(); // ta den första punkten i stacken och ta kordinaterna av den för att ändra färgen av den pixeln
                x = point.X;
                y = point.Y;

                if (x < 0 || x >= width || y < 0 || y >= height)
                    continue;

                if (bmp.GetPixel(x, y) == color || bmp.GetPixel(x, y) != color2Change)
                    continue;

                if (color == color2Change)
                    continue;

                bmp.SetPixel(x, y, color);

                // Lägg till de närliggande pixlarna i stacken som sedan bearbetas i senare itarationer
                stack.Push(new Point(x + 1, y));
                stack.Push(new Point(x - 1, y));
                stack.Push(new Point(x, y + 1));
                stack.Push(new Point(x, y - 1));
            }
        }
    }
}