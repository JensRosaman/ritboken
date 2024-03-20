using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ritboken
{
    public partial class Form1 : Form
    {
        private bool isDrawing = false;     // En flagga som indikerar om användaren är i färd med att rita eller inte.
        private Point previousPoint;        // Håller koll på den tidigare muspositionen för att rita linjer.

        // Deklarera en bitmap för att lagra ritområdet
        private Bitmap drawingSurface = new Bitmap(800, 600);
        public Form1()
        {
            InitializeComponent();

            // Kör metoden för att skapa ett ritområdet genom att rensa det till vit färg
            InitializeDrawingSurface();
        }

        // Metod för att skapa ett ritområde genom att rensa det till vit färg.
        private void InitializeDrawingSurface()
        {
            using (Graphics g = Graphics.FromImage(drawingSurface))
            {
                g.Clear(Color.White);
            }
        }

        // Händelsehanterare som aktiveras när användaren klickar ned musknappen för att börja rita.
        private void pxbPapper_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;                   // Användaren har börjat rita                
            previousPoint = e.Location;         // Sparar positionen där muspekaren befann sig när ritningen påbörjades i previousPoint 
        }

        // Händelsehanterare som aktiveras när användaren rör musen och ritningen pågår.
        private void pxbPapper_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    new BaseDraw(Color.Black, 4).draw(e, previousPoint, g);

                }

                previousPoint = e.Location;

                // Uppdatera PictureBox för att visa de ändringar som gjorts på ritområdet
                pxbPapper.Invalidate();
            }
        }

        // Händelsehanterare som aktiveras när användaren släpper musknappen.
        private void pxbPapper_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;          // Användaren har slutat rita och släppt musknappen
        }

        private void pxbPapper_Paint(object sender, PaintEventArgs e)
        {
            // Rita ritområdet på PictureBox
            e.Graphics.DrawImage(drawingSurface, Point.Empty);
        }
    }
}


