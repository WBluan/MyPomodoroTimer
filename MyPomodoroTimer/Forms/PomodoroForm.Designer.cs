﻿namespace MyPomodoroTimer
{
    partial class PomodoroForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PomodoroForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblWorkF2 = new System.Windows.Forms.Label();
            this.btnStartFrm2 = new System.Windows.Forms.Button();
            this.btnPauseFrm2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.timerForm2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 65);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblWorkF2
            // 
            this.lblWorkF2.AutoSize = true;
            this.lblWorkF2.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkF2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkF2.ForeColor = System.Drawing.Color.Black;
            this.lblWorkF2.Location = new System.Drawing.Point(93, 12);
            this.lblWorkF2.Name = "lblWorkF2";
            this.lblWorkF2.Size = new System.Drawing.Size(73, 35);
            this.lblWorkF2.TabIndex = 2;
            this.lblWorkF2.Text = "00:00";
            // 
            // btnStartFrm2
            // 
            this.btnStartFrm2.BackColor = System.Drawing.Color.Transparent;
            this.btnStartFrm2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStartFrm2.BackgroundImage")));
            this.btnStartFrm2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartFrm2.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnStartFrm2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStartFrm2.FlatAppearance.BorderSize = 0;
            this.btnStartFrm2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStartFrm2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStartFrm2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartFrm2.Location = new System.Drawing.Point(185, 14);
            this.btnStartFrm2.Name = "btnStartFrm2";
            this.btnStartFrm2.Size = new System.Drawing.Size(30, 35);
            this.btnStartFrm2.TabIndex = 3;
            this.btnStartFrm2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartFrm2.UseVisualStyleBackColor = false;
            this.btnStartFrm2.Click += new System.EventHandler(this.btnStartFrm2_Click);
            // 
            // btnPauseFrm2
            // 
            this.btnPauseFrm2.BackColor = System.Drawing.Color.Transparent;
            this.btnPauseFrm2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPauseFrm2.BackgroundImage")));
            this.btnPauseFrm2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPauseFrm2.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPauseFrm2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPauseFrm2.FlatAppearance.BorderSize = 0;
            this.btnPauseFrm2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPauseFrm2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPauseFrm2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPauseFrm2.Location = new System.Drawing.Point(221, 6);
            this.btnPauseFrm2.Name = "btnPauseFrm2";
            this.btnPauseFrm2.Size = new System.Drawing.Size(42, 51);
            this.btnPauseFrm2.TabIndex = 6;
            this.btnPauseFrm2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPauseFrm2.UseVisualStyleBackColor = false;
            this.btnPauseFrm2.Click += new System.EventHandler(this.btnPauseFrm2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Default;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(271, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 30);
            this.button3.TabIndex = 7;
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timerForm2
            // 
            this.timerForm2.Interval = 1500;
            // 
            // PomodoroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(323, 62);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnPauseFrm2);
            this.Controls.Add(this.btnStartFrm2);
            this.Controls.Add(this.lblWorkF2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PomodoroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "My Pomodoro Timer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWorkF2;
        private System.Windows.Forms.Button btnStartFrm2;
        private System.Windows.Forms.Button btnPauseFrm2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timerForm2;
    }
}