using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal class DrawBase
    {
        public Color color = Color.Red;
        private int _width;
        protected Pen pen; // så arv klasseer också kan nå den
        public Point[] points = new Point[100];
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

        public DrawBase(Color color, int width)
        {
            this.color = color;
            this.width = width;
            pen = new Pen(color);
            pen.EndCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
        }
        public int Width { get { return width; } }


        public virtual void Draw(MouseEventArgs e, Point prevLocation, Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Rita en linje från föregående musposition till nuvarande pos
           // g.DrawLine(pen, prevLocation, e.Location);
            
            //this.DrawSmoothCurve(e, prevLocation, g);
           

        }


        public virtual void DrawSmoothCurve(MouseEventArgs e, Point prevLocation, Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // Generate additional points along the curve
            Point[] points = GenerateSmoothCurvePoints(prevLocation, e.Location);
            // Draw the curve
            g.DrawCurve(pen, points);
        }

        private Point[] GenerateSmoothCurvePoints(Point start, Point end)
        {
            // Number of additional points to generate along the curve
            int numPoints = 8;
            // List to store the generated points
            List<Point> points = new List<Point>();

            // Catmull-Rom spline interpolation
            for (int i = 0; i <= numPoints; i++)
            {
                float t = (float)i / numPoints;
                // Calculate the interpolated point using Catmull-Rom formula
                Point interpolatedPoint = CalculateCatmullRomPoint(start, end, t);
                // Add the interpolated point to the list
                points.Add(interpolatedPoint);
            }

            // Convert the list of points to an array
            return points.ToArray();
        }

        private Point CalculateCatmullRomPoint(Point p0, Point p1, float t)
        {
            // Catmull-Rom spline interpolation formula
            float t2 = t * t;
            float t3 = t2 * t;
            float q1 = -t3 + 2 * t2 - t;
            float q2 = 3 * t3 - 5 * t2 + 2;
            float q3 = -3 * t3 + 4 * t2 + t;
            float q4 = t3 - t2;
            // Calculate the interpolated point
            int x = (int)(0.5f * (p0.X * q1 + p1.X * q2 + p0.X * q3 + p1.X * q4));
            int y = (int)(0.5f * (p0.Y * q1 + p1.Y * q2 + p0.Y * q3 + p1.Y * q4));
            return new Point(x, y);
        }


    }
}
