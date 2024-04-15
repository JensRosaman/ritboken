namespace ritboken
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            pxbPapper = new PictureBox();
            groupBox1 = new GroupBox();
            bucketBtn = new Button();
            label3 = new Label();
            LineBtn = new Button();
            penBtn = new Button();
            undoBtn = new Button();
            label4 = new Label();
            loadImgBtn = new Button();
            fillShapeChckbx = new CheckBox();
            ellipseBtn = new Button();
            backColorBtn = new Button();
            squareBtn = new Button();
            eraserBtn = new Button();
            colorSelector = new Button();
            colorBtn5 = new Button();
            label1 = new Label();
            roundEdgesChckbx = new CheckBox();
            colorbtn4 = new Button();
            label2 = new Label();
            clearBtn = new Button();
            colorbtn1 = new Button();
            syncChckbx = new CheckBox();
            colorbtn2 = new Button();
            SaveBtn = new Button();
            colorbtn3 = new Button();
            sizeInp = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pxbPapper).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sizeInp).BeginInit();
            SuspendLayout();
            // 
            // pxbPapper
            // 
            pxbPapper.Location = new Point(3, 104);
            pxbPapper.Margin = new Padding(2);
            pxbPapper.Name = "pxbPapper";
            pxbPapper.Size = new Size(1045, 515);
            pxbPapper.TabIndex = 0;
            pxbPapper.TabStop = false;
            pxbPapper.Paint += pxbPapper_Paint;
            pxbPapper.MouseDown += pxbPapper_MouseDown;
            pxbPapper.MouseMove += pxbPapper_MouseMove;
            pxbPapper.MouseUp += pxbPapper_MouseUp;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(bucketBtn);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(LineBtn);
            groupBox1.Controls.Add(penBtn);
            groupBox1.Controls.Add(undoBtn);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(loadImgBtn);
            groupBox1.Controls.Add(fillShapeChckbx);
            groupBox1.Controls.Add(ellipseBtn);
            groupBox1.Controls.Add(backColorBtn);
            groupBox1.Controls.Add(squareBtn);
            groupBox1.Controls.Add(eraserBtn);
            groupBox1.Controls.Add(colorSelector);
            groupBox1.Controls.Add(colorBtn5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(roundEdgesChckbx);
            groupBox1.Controls.Add(colorbtn4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(clearBtn);
            groupBox1.Controls.Add(colorbtn1);
            groupBox1.Controls.Add(syncChckbx);
            groupBox1.Controls.Add(colorbtn2);
            groupBox1.Controls.Add(SaveBtn);
            groupBox1.Controls.Add(colorbtn3);
            groupBox1.Controls.Add(sizeInp);
            groupBox1.Location = new Point(8, -2);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(1054, 90);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Inställningar";
            // 
            // bucketBtn
            // 
            bucketBtn.BackgroundImage = (Image)resources.GetObject("bucketBtn.BackgroundImage");
            bucketBtn.BackgroundImageLayout = ImageLayout.Zoom;
            bucketBtn.Location = new Point(163, 12);
            bucketBtn.Name = "bucketBtn";
            bucketBtn.Size = new Size(30, 23);
            bucketBtn.TabIndex = 24;
            bucketBtn.UseVisualStyleBackColor = true;
            bucketBtn.Click += bucketBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(976, 20);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 23;
            label3.Text = "Spara";
            // 
            // LineBtn
            // 
            LineBtn.Location = new Point(6, 50);
            LineBtn.Margin = new Padding(2);
            LineBtn.Name = "LineBtn";
            LineBtn.Size = new Size(73, 20);
            LineBtn.TabIndex = 3;
            LineBtn.Text = "Linje";
            LineBtn.UseVisualStyleBackColor = true;
            LineBtn.Click += LineBtn_Click;
            // 
            // penBtn
            // 
            penBtn.BackColor = Color.Gainsboro;
            penBtn.Location = new Point(5, 13);
            penBtn.Margin = new Padding(2);
            penBtn.Name = "penBtn";
            penBtn.Size = new Size(72, 20);
            penBtn.TabIndex = 4;
            penBtn.Text = "Penna";
            penBtn.UseVisualStyleBackColor = false;
            penBtn.Click += penBtn_Click;
            // 
            // undoBtn
            // 
            undoBtn.Location = new Point(83, 50);
            undoBtn.Margin = new Padding(2);
            undoBtn.Name = "undoBtn";
            undoBtn.Size = new Size(75, 19);
            undoBtn.TabIndex = 22;
            undoBtn.Text = "Återgå";
            undoBtn.UseVisualStyleBackColor = true;
            undoBtn.Click += button1_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(960, 44);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 21;
            label4.Text = "Ladda in";
            // 
            // loadImgBtn
            // 
            loadImgBtn.BackgroundImage = (Image)resources.GetObject("loadImgBtn.BackgroundImage");
            loadImgBtn.BackgroundImageLayout = ImageLayout.Zoom;
            loadImgBtn.Location = new Point(1016, 42);
            loadImgBtn.Margin = new Padding(2);
            loadImgBtn.Name = "loadImgBtn";
            loadImgBtn.Size = new Size(24, 21);
            loadImgBtn.TabIndex = 20;
            loadImgBtn.UseVisualStyleBackColor = true;
            loadImgBtn.Click += button1_Click;
            // 
            // fillShapeChckbx
            // 
            fillShapeChckbx.AutoSize = true;
            fillShapeChckbx.Location = new Point(457, 16);
            fillShapeChckbx.Name = "fillShapeChckbx";
            fillShapeChckbx.Size = new Size(83, 19);
            fillShapeChckbx.TabIndex = 8;
            fillShapeChckbx.Text = "Fyll former";
            fillShapeChckbx.UseVisualStyleBackColor = true;
            fillShapeChckbx.Click += fillShapeChckbx_Click;
            // 
            // ellipseBtn
            // 
            ellipseBtn.Location = new Point(195, 14);
            ellipseBtn.Margin = new Padding(2);
            ellipseBtn.Name = "ellipseBtn";
            ellipseBtn.Size = new Size(68, 20);
            ellipseBtn.TabIndex = 7;
            ellipseBtn.Text = "Ellipse";
            ellipseBtn.UseVisualStyleBackColor = true;
            ellipseBtn.Click += ellipseBtn_Click;
            // 
            // backColorBtn
            // 
            backColorBtn.BackgroundImageLayout = ImageLayout.Zoom;
            backColorBtn.Location = new Point(163, 49);
            backColorBtn.Name = "backColorBtn";
            backColorBtn.Size = new Size(101, 21);
            backColorBtn.TabIndex = 17;
            backColorBtn.Text = "Ändra bakgrund";
            backColorBtn.UseVisualStyleBackColor = true;
            backColorBtn.Click += backColorBtn_Click;
            // 
            // squareBtn
            // 
            squareBtn.Location = new Point(268, 15);
            squareBtn.Margin = new Padding(2);
            squareBtn.Name = "squareBtn";
            squareBtn.Size = new Size(69, 20);
            squareBtn.TabIndex = 6;
            squareBtn.Text = "Kvadrat";
            squareBtn.UseVisualStyleBackColor = true;
            squareBtn.Click += squareBtn_Click;
            // 
            // eraserBtn
            // 
            eraserBtn.Location = new Point(82, 13);
            eraserBtn.Name = "eraserBtn";
            eraserBtn.Size = new Size(75, 20);
            eraserBtn.TabIndex = 16;
            eraserBtn.Text = "Sudd";
            eraserBtn.UseVisualStyleBackColor = true;
            eraserBtn.Click += eraserBtn_Click;
            // 
            // colorSelector
            // 
            colorSelector.BackgroundImage = (Image)resources.GetObject("colorSelector.BackgroundImage");
            colorSelector.BackgroundImageLayout = ImageLayout.None;
            colorSelector.Location = new Point(527, 51);
            colorSelector.Margin = new Padding(2);
            colorSelector.Name = "colorSelector";
            colorSelector.Size = new Size(73, 22);
            colorSelector.TabIndex = 1;
            colorSelector.Text = "Välj färger";
            colorSelector.UseVisualStyleBackColor = true;
            colorSelector.Click += colorSelector_Click;
            // 
            // colorBtn5
            // 
            colorBtn5.Location = new Point(502, 53);
            colorBtn5.Name = "colorBtn5";
            colorBtn5.Size = new Size(20, 19);
            colorBtn5.TabIndex = 15;
            colorBtn5.UseVisualStyleBackColor = true;
            colorBtn5.Click += colorBtn5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(605, 55);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 14;
            label1.Text = "Storlek";
            // 
            // roundEdgesChckbx
            // 
            roundEdgesChckbx.AutoSize = true;
            roundEdgesChckbx.Location = new Point(356, 15);
            roundEdgesChckbx.Name = "roundEdgesChckbx";
            roundEdgesChckbx.Size = new Size(96, 19);
            roundEdgesChckbx.TabIndex = 14;
            roundEdgesChckbx.Text = "Runda kanter";
            roundEdgesChckbx.UseVisualStyleBackColor = true;
            roundEdgesChckbx.Click += roundEdgesChckbx_Click;
            // 
            // colorbtn4
            // 
            colorbtn4.Location = new Point(476, 53);
            colorbtn4.Name = "colorbtn4";
            colorbtn4.Size = new Size(20, 19);
            colorbtn4.TabIndex = 12;
            colorbtn4.UseVisualStyleBackColor = true;
            colorbtn4.Click += colorbtn4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(352, 53);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 13;
            label2.Text = "Färger";
            // 
            // clearBtn
            // 
            clearBtn.Location = new Point(269, 53);
            clearBtn.Margin = new Padding(2);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(69, 20);
            clearBtn.TabIndex = 2;
            clearBtn.Text = "Rensa";
            clearBtn.UseVisualStyleBackColor = true;
            clearBtn.Click += clearBtn_Click;
            // 
            // colorbtn1
            // 
            colorbtn1.Location = new Point(398, 53);
            colorbtn1.Name = "colorbtn1";
            colorbtn1.Size = new Size(20, 20);
            colorbtn1.TabIndex = 9;
            colorbtn1.UseVisualStyleBackColor = true;
            colorbtn1.Click += colorbtn1_Click;
            // 
            // syncChckbx
            // 
            syncChckbx.AutoSize = true;
            syncChckbx.Checked = true;
            syncChckbx.CheckState = CheckState.Checked;
            syncChckbx.Location = new Point(549, 16);
            syncChckbx.Name = "syncChckbx";
            syncChckbx.Size = new Size(125, 19);
            syncChckbx.TabIndex = 15;
            syncChckbx.Text = "Synka inställningar";
            syncChckbx.UseVisualStyleBackColor = true;
            syncChckbx.CheckedChanged += syncChckbx_CheckedChanged;
            // 
            // colorbtn2
            // 
            colorbtn2.Location = new Point(424, 53);
            colorbtn2.Name = "colorbtn2";
            colorbtn2.Size = new Size(20, 19);
            colorbtn2.TabIndex = 10;
            colorbtn2.UseVisualStyleBackColor = true;
            colorbtn2.Click += colorbtn2_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.BackgroundImage = (Image)resources.GetObject("SaveBtn.BackgroundImage");
            SaveBtn.BackgroundImageLayout = ImageLayout.Zoom;
            SaveBtn.Location = new Point(1016, 16);
            SaveBtn.Margin = new Padding(2);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(24, 22);
            SaveBtn.TabIndex = 5;
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // colorbtn3
            // 
            colorbtn3.Location = new Point(450, 53);
            colorbtn3.Name = "colorbtn3";
            colorbtn3.Size = new Size(20, 19);
            colorbtn3.TabIndex = 11;
            colorbtn3.UseVisualStyleBackColor = true;
            colorbtn3.Click += colorbtn3_Click;
            // 
            // sizeInp
            // 
            sizeInp.Location = new Point(657, 53);
            sizeInp.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            sizeInp.Name = "sizeInp";
            sizeInp.Size = new Size(35, 23);
            sizeInp.TabIndex = 13;
            sizeInp.ValueChanged += sizeTxtBox_TextChanged;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1064, 630);
            Controls.Add(pxbPapper);
            Controls.Add(groupBox1);
            Margin = new Padding(2);
            Name = "Form";
            Text = "Coolt ritprogram";
            ((System.ComponentModel.ISupportInitialize)pxbPapper).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sizeInp).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pxbPapper;
        private GroupBox groupBox1;
        private Button clearBtn;
        private Button colorSelector;
        private Button LineBtn;
        private Button penBtn;
        private Button SaveBtn;
        private Button squareBtn;
        private Button ellipseBtn;
        private CheckBox fillShapeChckbx;
        private Button colorbtn1;
        private Button colorbtn2;
        private Button colorbtn3;
        private Button colorbtn4;
        private NumericUpDown sizeInp;
        private Label label1;
        private Label label2;
        private CheckBox roundEdgesChckbx;
        private CheckBox syncChckbx;
        private Button colorBtn5;
        private Button eraserBtn;
        private Button backColorBtn;
        private Button loadImgBtn;
        private Button undoBtn;
        private Label label4;
        private Label label3;
        private Button bucketBtn;
    }
}