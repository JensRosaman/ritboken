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
            pxbPapper = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pxbPapper).BeginInit();
            SuspendLayout();
            // 
            // pxbPapper
            // 
            pxbPapper.Location = new Point(297, 81);
            pxbPapper.Name = "pxbPapper";
            pxbPapper.Size = new Size(392, 346);
            pxbPapper.TabIndex = 0;
            pxbPapper.TabStop = false;
            pxbPapper.Paint += pxbPapper_Paint;
            pxbPapper.MouseDown += pxbPapper_MouseDown;
            pxbPapper.MouseMove += pxbPapper_MouseMove;
            pxbPapper.MouseUp += pxbPapper_MouseUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pxbPapper);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pxbPapper).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pxbPapper;
    }
}