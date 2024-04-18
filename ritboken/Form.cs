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
using System.Net.Sockets;
using System.Diagnostics.Eventing.Reader;

namespace ritboken
{
    public partial class Form : System.Windows.Forms.Form
    {
        private bool isDrawing = false;     // En flagga som indikerar om anv�ndaren �r i f�rd med att rita eller inte.
        private Point previousPoint;        // H�ller koll p� den tidigare muspositionen f�r att rita linjer.
        private Bitmap drawingSurface;// Deklarera en bitmap f�r att lagra ritomr�det
        private Bitmap oldDrawingsurface; // sparar de gamla tillst�ndet av bitmapen
        private Dictionary<DrawBase, System.Windows.Forms.Button> drawButtons = new Dictionary<DrawBase, System.Windows.Forms.Button>(); // g�r s� att ritverktygen kan kopplas samman med dess knappar
        private Dictionary<string, DrawBase> drawingModes = new Dictionary<string, DrawBase> { }; // genom att spara alla objekt s� sparas �ven deras inst�llningar ex bredd osv
        private bool syncSettings = true; // synca som standard
        private int penWidth; // heter penWidth i den h�r klassen d� det finns flera andra saker som bredd kan tyda p� i den h�r kontexten
        private DrawBase _selectedDraw;

        private DrawBase selectedDraw
        {
            get { return _selectedDraw; }
            set
            {
                // uppdatera f�rg p� knapp
                if (_selectedDraw != null)
                {
                    if (drawButtons.ContainsKey(_selectedDraw))
                        drawButtons[_selectedDraw].BackColor = Color.GreenYellow;

                    else
                    {
                        eraserBtn.BackColor = Color.GreenYellow;

                    }
                }

                if (drawButtons.ContainsKey(value))
                    drawButtons[value].BackColor = Color.RebeccaPurple;


                _selectedDraw = value;
                if (syncSettings)
                {
                    _selectedDraw.color = color;
                    _selectedDraw.width = penWidth;


                }
            }
        }
        private Color _color = Color.Black;
        private Color color
        {
            set
            {
                _color = value;
                if (syncSettings)
                {
                    foreach (DrawBase db in drawingModes.Values)
                    {
                        if (!(db is BackgroundTool)) db.color = _color; // hinken b�r stanna som samma f�rg d� man annars kan r�ka �ndra bakgrundsf�rgen av mistag
                    }
                }
                else
                {
                    selectedDraw.color = value;
                }

            }
            get { return _color; }
        }

        public Form()
        {
            this.Text = "Coolt ritprogram";
            this.DoubleBuffered = true;
            this.BackColor = Color.AliceBlue;
            InitializeComponent();

            drawingSurface = new Bitmap(pxbPapper.Width, pxbPapper.Height);
            oldDrawingsurface = (Bitmap)drawingSurface.Clone();
            // intializera verktygen
            drawingModes["pen"] = new PenTool(color, penWidth);
            drawingModes["ellipse"] = new Ellipse(color, penWidth);
            drawingModes["rectangle"] = new RectangleTool(color, penWidth);
            drawingModes["line"] = new Line(color, penWidth);
            drawingModes["bucket"] = new BucketTool(color, penWidth);
            drawingModes["backColor"] = new BackgroundTool(Color.White, penWidth);
            drawingModes["eraser"] = new Eraser(Color.White, penWidth);

            // para ihop ritverktygen till knapparna, det g�r det l�ttare att sedan l�gga till fler verktyg med denna metod
            drawButtons[drawingModes["pen"]] = penBtn;
            drawButtons[drawingModes["ellipse"]] = ellipseBtn;
            drawButtons[drawingModes["rectangle"]] = rectangleBtn;
            drawButtons[drawingModes["line"]] = LineBtn;
            drawButtons[drawingModes["bucket"]] = bucketBtn;
            drawButtons[drawingModes["backColor"]] = backColorBtn;
            drawButtons[drawingModes["eraser"]] = eraserBtn;

            foreach (System.Windows.Forms.Button btn in drawButtons.Values)
            {
                btn.BackColor = Color.GreenYellow;
            }

            // anger f�rg till f�rg knapprna
            colorbtn1.BackColor = Color.Black;
            colorbtn2.BackColor = Color.Blue;
            colorbtn3.BackColor = Color.Red;
            colorbtn4.BackColor = Color.Green;
            colorBtn5.BackColor = Color.Yellow;

            selectedDraw = drawingModes["pen"]; // b�rja rita med penna

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
            oldDrawingsurface = (Bitmap)drawingSurface.Clone(); // Spara hur det s�g ut innan anv b�rjade rita

            if (selectedDraw is PostDrawBase)
            {
                PostDrawBase pdb = (PostDrawBase)selectedDraw;
                pdb.mouseDownLoc = previousPoint;
            }
            else if (!(selectedDraw is BucketTool))
            {
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    selectedDraw.Draw(e, new Point(e.Location.X + 1, e.Location.Y + 1), g); //Pennor ritar s� fort man r�r pappret -> rita prick
                }

            }
            else
            {
                ((BucketTool)selectedDraw).Draw(e, ref drawingSurface);

            }
        }


        // H�ndelsehanterare som aktiveras n�r anv�ndaren r�r musen och ritningen p�g�r.
        private void pxbPapper_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && !(this.selectedDraw is PostDrawBase) && !(selectedDraw is BucketTool)) // pen liknade verktyg ingen preview beh�vs
            {
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    selectedDraw.Draw(e, previousPoint, g);
                }
                previousPoint = e.Location;

            }

            else if (isDrawing && selectedDraw is PostDrawBase)
            {
                // g�r preview
                drawingSurface = (Bitmap)oldDrawingsurface.Clone(); // g� tillbaka till de gamla utseendet innan en preview ritades
                PostDrawBase pbd = (PostDrawBase)selectedDraw; // type casta till r�tt klass s� r�tt funktionalitet blir tillg�nglig
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    pbd.currMouseLoc = pbd.mouseDownLoc;
                    pxbPapper.Invalidate();
                    pbd.currMouseLoc = e.Location;
                    pbd.DrawPreview(g);
                }
            }


            pxbPapper.Invalidate(); // Uppdatera PictureBox f�r att visa de �ndringar som gjorts p� ritomr�det
        }

        private void pxbPapper_MouseUp(object sender, MouseEventArgs e) // H�ndelsehanterare som aktiveras n�r anv�ndaren sl�pper musknappen.

        {
            this.Cursor = Cursors.Default;

            if (isDrawing && selectedDraw is PostDrawBase)
            {
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    selectedDraw.Draw(e, previousPoint, g);
                }
                pxbPapper.Invalidate();
            }
            else if (isDrawing && selectedDraw is PostDrawBase)
            {
                PostDrawBase pbx = (PostDrawBase)selectedDraw; // gillar det inte men den klagar annars
                pbx.currMouseLoc = pbx.mouseDownLoc = new Point(0, 0);
            }
            isDrawing = false; // Anv�ndaren har slutat rita och sl�ppt musknappen
        }

        private void pxbPapper_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(drawingSurface, Point.Empty); // Rita ritomr�det p� PictureBox
        }

        private void sizeTxtBox_TextChanged(object sender, EventArgs e)
        {
            penWidth = (int)sizeInp.Value;
            selectedDraw.width = penWidth;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            InitializeDrawingSurface();
            using (Graphics g = Graphics.FromImage(drawingSurface))
            {
                g.Clear(drawingModes["backColor"].color);
            }
            pxbPapper.Invalidate();
        }

        private void colorSelector_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = color;
            if (dialog.ShowDialog() == DialogResult.OK)
                color = dialog.Color;

        }

        private void LineBtn_Click(object sender, EventArgs e)
        {
            selectedDraw = drawingModes["line"];
            change_eraserBackColor();

        }

        private void penBtn_Click(object sender, EventArgs e)
        {
            selectedDraw = drawingModes["pen"];
            change_eraserBackColor();

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                drawingSurface.Save(saveFileDialog.FileName + ".png", ImageFormat.Png);

                DialogResult result = MessageBox.Show("Fil sparad! \n Vill du �ppna fils�kv�gen?", "Fils�kv�g",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(saveFileDialog.FileName));
                }
            }
        }

        private void change_eraserBackColor()
        {
            return;
            if (eraserBtn.BackColor == Color.GreenYellow)
                eraserBtn.BackColor = Color.RebeccaPurple;
            else
                eraserBtn.BackColor = Color.GreenYellow;
        }

        private void squareBtn_Click(object sender, EventArgs e)
        {
            selectedDraw = drawingModes["rectangle"];
            change_eraserBackColor();
        }

        private void ellipseBtn_Click(object sender, EventArgs e)
        {
            selectedDraw = drawingModes["ellipse"];
            change_eraserBackColor();

        }

        private void fillShapeChckbx_Click(object sender, EventArgs e)
        {
            foreach (DrawBase drawOption in drawingModes.Values)
            {
                if (drawOption is PostDrawBase)
                {
                    PostDrawBase pbx = (PostDrawBase)drawOption;
                    pbx.fillShapes = !pbx.fillShapes;
                }
            }
        }

        private void colorbtn1_Click(object sender, EventArgs e)
        {
            color = colorbtn1.BackColor;
        }

        private void colorbtn2_Click(object sender, EventArgs e)
        {
            color = colorbtn2.BackColor;

        }

        private void colorbtn3_Click(object sender, EventArgs e)
        {
            color = colorbtn3.BackColor;

        }

        private void colorbtn4_Click(object sender, EventArgs e)
        {
            color = colorbtn4.BackColor;

        }

        private void roundEdgesChckbx_Click(object sender, EventArgs e)
        {
            RectangleTool pbx = (RectangleTool)drawingModes["rectangle"];
            pbx.smoothEdges = !pbx.smoothEdges;
        }

        private void syncChckbx_CheckedChanged(object sender, EventArgs e)
        {
            syncSettings = !syncSettings;
        }

        private void colorBtn5_Click(object sender, EventArgs e)
        {
            color = colorBtn5.BackColor;
        }

        private void eraserBtn_Click(object sender, EventArgs e)
        {

            selectedDraw = drawingModes["eraser"]; // skapa ny penna sy den inte synkas med de andra inst�llningarna oavsett vad
            selectedDraw.color = drawingModes["backColor"].color;
            selectedDraw.width = 9;

        }

        private void backColorBtn_Click(object sender, EventArgs e)
        {
            selectedDraw = drawingModes["backColor"];
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                drawingSurface = new Bitmap(fileDialog.FileName);
            }
        }

        private void undoBtnClick(object sender, EventArgs e)
        {
            if (drawingSurface != null)
            {
                drawingSurface = (Bitmap)oldDrawingsurface.Clone();
            }


        }

        private void bucketBtn_Click(object sender, EventArgs e)
        {
            selectedDraw = drawingModes["bucket"];
            eraserBtn.BackColor = Color.GreenYellow;

        }
    }
}


