using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ritboken
{
    public partial class Form1 : Form
    {
        private bool isDrawing = false;     // En flagga som indikerar om användaren är i färd med att rita eller inte.
        private Point previousPoint;        // Håller koll på den tidigare muspositionen för att rita linjer.

        // Deklarera en bitmap för att lagra ritområdet
        private Bitmap drawingSurface = new Bitmap(800, 600);

        // ange defualt inställningar till ritmetoderna och dess färg
        Color color = Color.Black;
        private int penWidth;
        private BaseDraw selectedDraw;
        public Form1()
        {
            InitializeComponent();
            selectedDraw = new BaseDraw(color, penWidth);

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
                    selectedDraw.draw(e, previousPoint, g);

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

        private void sizeTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(sizeTxtBox.Text, out var size))
            {
                penWidth = size;
                selectedDraw.width = size;
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            pxbPapper.Image = null;
            drawingSurface = new Bitmap(800, 600);
            InitializeDrawingSurface();

        }

        private void colorSelector_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = color;
            if (dialog.ShowDialog() == DialogResult.OK)
                color = dialog.Color;
            selectedDraw.color = color;

        }
    }
}


