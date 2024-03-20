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
        private bool isDrawing = false;     // En flagga som indikerar om anv�ndaren �r i f�rd med att rita eller inte.
        private Point previousPoint;        // H�ller koll p� den tidigare muspositionen f�r att rita linjer.

        // Deklarera en bitmap f�r att lagra ritomr�det
        private Bitmap drawingSurface = new Bitmap(800, 600);
        public Form1()
        {
            InitializeComponent();

            // K�r metoden f�r att skapa ett ritomr�det genom att rensa det till vit f�rg
            InitializeDrawingSurface();
        }

        // Metod f�r att skapa ett ritomr�de genom att rensa det till vit f�rg.
        private void InitializeDrawingSurface()
        {
            using (Graphics g = Graphics.FromImage(drawingSurface))
            {
                g.Clear(Color.White);
            }
        }

        // H�ndelsehanterare som aktiveras n�r anv�ndaren klickar ned musknappen f�r att b�rja rita.
        private void pxbPapper_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;                   // Anv�ndaren har b�rjat rita                
            previousPoint = e.Location;         // Sparar positionen d�r muspekaren befann sig n�r ritningen p�b�rjades i previousPoint 
        }

        // H�ndelsehanterare som aktiveras n�r anv�ndaren r�r musen och ritningen p�g�r.
        private void pxbPapper_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    new BaseDraw(Color.Black, 4).draw(e, previousPoint, g);

                }

                previousPoint = e.Location;

                // Uppdatera PictureBox f�r att visa de �ndringar som gjorts p� ritomr�det
                pxbPapper.Invalidate();
            }
        }

        // H�ndelsehanterare som aktiveras n�r anv�ndaren sl�pper musknappen.
        private void pxbPapper_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;          // Anv�ndaren har slutat rita och sl�ppt musknappen
        }

        private void pxbPapper_Paint(object sender, PaintEventArgs e)
        {
            // Rita ritomr�det p� PictureBox
            e.Graphics.DrawImage(drawingSurface, Point.Empty);
        }
    }
}


