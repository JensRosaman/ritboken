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
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.IO;

namespace ritboken
{
    public partial class Form : System.Windows.Forms.Form
    {
        private bool isDrawing = false;     // En flagga som indikerar om användaren är i färd med att rita eller inte.
        private Point previousPoint;        // Håller koll på den tidigare muspositionen för att rita linjer.

        // Deklarera en bitmap för att lagra ritområdet
        private Bitmap drawingSurface = new Bitmap(800, 600);

        // ange defualt inställningar till ritmetoderna och dess färg
        Color color = Color.Black;
        private int penWidth;
        private DrawBase selectedDraw;
        public Graphics drawingGraphics;
        private Dictionary<string, DrawBase> drawingModes = new Dictionary<string, DrawBase> { }; // genom att spara alla objekt så sparas även deras inställningar ex bredd osv
        public Form()
        {
            this.Text = "Coolt ritprogram";
            this.DoubleBuffered = true;

            InitializeComponent();
            drawingSurface = new Bitmap(pxbPapper.Width, pxbPapper.Height);
            drawingModes["pen"] = new DrawBase(color, penWidth);
            drawingModes["ellipse"] = new Ellipse(color, penWidth);


            selectedDraw = drawingModes["pen"]; // börja rita med penna
            drawingGraphics = Graphics.FromImage(drawingSurface);
            drawingGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


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
            this.Cursor = Cursors.Hand;
            isDrawing = true;                  // Användaren har börjat rita                
            previousPoint = e.Location;       // Sparar positionen där muspekaren befann sig när ritningen påbörjades i previousPoint 

            if( selectedDraw is PostDrawBase)
            {

                PostDrawBase pdb = (PostDrawBase) selectedDraw;
                pdb.mouseDownLoc = previousPoint;
            }
        }


        // Händelsehanterare som aktiveras när användaren rör musen och ritningen pågår.
        private void pxbPapper_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && !(this.selectedDraw is PostDrawBase))
            {
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    selectedDraw.Draw(e, previousPoint, drawingGraphics);

                }
                previousPoint = e.Location;
                // Uppdatera PictureBox för att visa de ändringar som gjorts på ritområdet
                
            }
            else if (isDrawing && selectedDraw is PostDrawBase)
            {
                // gör preview
                
                PostDrawBase pbd = (PostDrawBase)selectedDraw;
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    pbd.DrawPreview(g);                }
                
            }
            pxbPapper.Invalidate();
        }

        // Händelsehanterare som aktiveras när användaren släpper musknappen.
        private void pxbPapper_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor= Cursors.Default;
            if (isDrawing && (this.selectedDraw is Line | this.selectedDraw is Ellipse))
            {
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    selectedDraw.Draw(e, previousPoint, g);
                    pxbPapper.Invalidate();
                }
            }
            else if (isDrawing && selectedDraw is PostDrawBase)
            {
                PostDrawBase pbx = (PostDrawBase)selectedDraw; // gillar det inte men den klagar annars
                pbx.currMouseLoc = pbx.mouseDownLoc = new Point(0,0);
            }
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
            InitializeDrawingSurface();
            using (Graphics g = Graphics.FromImage(drawingSurface))
            {
                g.Clear(Color.White);
            }
            pxbPapper.Invalidate();
        }

        private void colorSelector_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = color;
            if (dialog.ShowDialog() == DialogResult.OK)
                color = dialog.Color;
            selectedDraw.color = color;

        }

        private void LineBtn_Click(object sender, EventArgs e)
        {
            selectedDraw = new Line(selectedDraw.color, selectedDraw.width);
        }

        private void penBtn_Click(object sender, EventArgs e)
        {
            selectedDraw = drawingModes["pen"];
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string filename = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyPictures),
                DateTime.Now.ToString("HH:mm:ss") + ".png"
                );
            drawingSurface.Save("bild.png", ImageFormat.Png);
        }

        private void squareBtn_Click(object sender, EventArgs e)
        {
        }

        private void ellipseBtn_Click(object sender, EventArgs e)
        {
            selectedDraw = drawingModes["ellipse"];
        }
    }
}


