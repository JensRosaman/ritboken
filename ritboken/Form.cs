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
        private bool isDrawing = false;     // En flagga som indikerar om anv�ndaren �r i f�rd med att rita eller inte.
        private Point previousPoint;        // H�ller koll p� den tidigare muspositionen f�r att rita linjer.

        // Deklarera en bitmap f�r att lagra ritomr�det
        private Bitmap drawingSurface = new Bitmap(800, 600);

        // ange defualt inst�llningar till ritmetoderna och dess f�rg
        Color color = Color.Black;
        private int penWidth;
        private DrawBase selectedDraw;
        public Graphics drawingGraphics;
        private Dictionary<string, DrawBase> drawingModes = new Dictionary<string, DrawBase> { }; // genom att spara alla objekt s� sparas �ven deras inst�llningar ex bredd osv
        public Form()
        {
            this.Text = "Coolt ritprogram";
            this.DoubleBuffered = true;

            InitializeComponent();
            drawingSurface = new Bitmap(pxbPapper.Width, pxbPapper.Height);
            drawingModes["pen"] = new DrawBase(color, penWidth);
            drawingModes["ellipse"] = new Ellipse(color, penWidth);


            selectedDraw = drawingModes["pen"]; // b�rja rita med penna
            drawingGraphics = Graphics.FromImage(drawingSurface);
            drawingGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


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
            this.Cursor = Cursors.Hand;
            isDrawing = true;                  // Anv�ndaren har b�rjat rita                
            previousPoint = e.Location;       // Sparar positionen d�r muspekaren befann sig n�r ritningen p�b�rjades i previousPoint 

            if( selectedDraw is PostDrawBase)
            {

                PostDrawBase pdb = (PostDrawBase) selectedDraw;
                pdb.mouseDownLoc = previousPoint;
            }
        }


        // H�ndelsehanterare som aktiveras n�r anv�ndaren r�r musen och ritningen p�g�r.
        private void pxbPapper_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && !(this.selectedDraw is PostDrawBase))
            {
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    selectedDraw.Draw(e, previousPoint, drawingGraphics);

                }
                previousPoint = e.Location;
                // Uppdatera PictureBox f�r att visa de �ndringar som gjorts p� ritomr�det
                
            }
            else if (isDrawing && selectedDraw is PostDrawBase)
            {
                // g�r preview
                
                PostDrawBase pbd = (PostDrawBase)selectedDraw;
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    pbd.DrawPreview(g);                }
                
            }
            pxbPapper.Invalidate();
        }

        // H�ndelsehanterare som aktiveras n�r anv�ndaren sl�pper musknappen.
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
            isDrawing = false;          // Anv�ndaren har slutat rita och sl�ppt musknappen
        }

        private void pxbPapper_Paint(object sender, PaintEventArgs e)
        {
            // Rita ritomr�det p� PictureBox
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


