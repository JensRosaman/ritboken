﻿namespace ritboken
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pxbPapper = new PictureBox();
            groupBox1 = new GroupBox();
            colorSelector = new Button();
            sizeTxtBox = new TextBox();
            clearBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pxbPapper).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pxbPapper
            // 
            pxbPapper.Location = new Point(396, 92);
            pxbPapper.Name = "pxbPapper";
            pxbPapper.Size = new Size(392, 346);
            pxbPapper.TabIndex = 0;
            pxbPapper.TabStop = false;
            pxbPapper.Paint += pxbPapper_Paint;
            pxbPapper.MouseDown += pxbPapper_MouseDown;
            pxbPapper.MouseMove += pxbPapper_MouseMove;
            pxbPapper.MouseUp += pxbPapper_MouseUp;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(colorSelector);
            groupBox1.Controls.Add(sizeTxtBox);
            groupBox1.Location = new Point(12, 92);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 180);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Inställningar";
            // 
            // colorSelector
            // 
            colorSelector.BackgroundImage = (Image)resources.GetObject("colorSelector.BackgroundImage");
            colorSelector.Location = new Point(6, 107);
            colorSelector.Name = "colorSelector";
            colorSelector.Size = new Size(93, 36);
            colorSelector.TabIndex = 1;
            colorSelector.Text = "Välj färg";
            colorSelector.UseVisualStyleBackColor = true;
            colorSelector.Click += colorSelector_Click;
            // 
            // sizeTxtBox
            // 
            sizeTxtBox.Location = new Point(144, 30);
            sizeTxtBox.Name = "sizeTxtBox";
            sizeTxtBox.Size = new Size(150, 31);
            sizeTxtBox.TabIndex = 0;
            sizeTxtBox.TextChanged += sizeTxtBox_TextChanged;
            // 
            // clearBtn
            // 
            clearBtn.Location = new Point(22, 13);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(112, 34);
            clearBtn.TabIndex = 2;
            clearBtn.Text = "Rensa";
            clearBtn.UseVisualStyleBackColor = true;
            clearBtn.Click += clearBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(clearBtn);
            Controls.Add(groupBox1);
            Controls.Add(pxbPapper);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pxbPapper).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pxbPapper;
        private GroupBox groupBox1;
        private TextBox sizeTxtBox;
        private Button clearBtn;
        private Button colorSelector;
    }
}