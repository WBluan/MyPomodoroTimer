namespace MyPomodoroTimer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnConfig = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnRest = new System.Windows.Forms.Button();
            this.btnLinkedinFrm1 = new System.Windows.Forms.Button();
            this.btnGithubFrm1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 186);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Repouso: 05:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "Concentração: 25:00";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(159, 399);
            this.btnIniciar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(112, 50);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(291, 399);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(112, 50);
            this.btnConfig.TabIndex = 4;
            this.btnConfig.Text = "Configurações";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnRest
            // 
            this.btnRest.Location = new System.Drawing.Point(24, 401);
            this.btnRest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRest.Name = "btnRest";
            this.btnRest.Size = new System.Drawing.Size(112, 50);
            this.btnRest.TabIndex = 5;
            this.btnRest.Text = "Descansar";
            this.btnRest.UseVisualStyleBackColor = true;
            this.btnRest.Click += new System.EventHandler(this.btnRest_Click);
            // 
            // btnLinkedinFrm1
            // 
            this.btnLinkedinFrm1.BackColor = System.Drawing.Color.Transparent;
            this.btnLinkedinFrm1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLinkedinFrm1.BackgroundImage")));
            this.btnLinkedinFrm1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLinkedinFrm1.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLinkedinFrm1.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btnLinkedinFrm1.FlatAppearance.BorderSize = 0;
            this.btnLinkedinFrm1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLinkedinFrm1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLinkedinFrm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLinkedinFrm1.Location = new System.Drawing.Point(324, 15);
            this.btnLinkedinFrm1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLinkedinFrm1.Name = "btnLinkedinFrm1";
            this.btnLinkedinFrm1.Size = new System.Drawing.Size(44, 42);
            this.btnLinkedinFrm1.TabIndex = 6;
            this.btnLinkedinFrm1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLinkedinFrm1.UseVisualStyleBackColor = false;
            this.btnLinkedinFrm1.Click += new System.EventHandler(this.btnLinkedinFrm1_Click);
            // 
            // btnGithubFrm1
            // 
            this.btnGithubFrm1.BackColor = System.Drawing.Color.Transparent;
            this.btnGithubFrm1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGithubFrm1.BackgroundImage")));
            this.btnGithubFrm1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGithubFrm1.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGithubFrm1.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnGithubFrm1.FlatAppearance.BorderSize = 0;
            this.btnGithubFrm1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGithubFrm1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGithubFrm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGithubFrm1.Location = new System.Drawing.Point(373, 9);
            this.btnGithubFrm1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGithubFrm1.Name = "btnGithubFrm1";
            this.btnGithubFrm1.Size = new System.Drawing.Size(49, 54);
            this.btnGithubFrm1.TabIndex = 7;
            this.btnGithubFrm1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGithubFrm1.UseVisualStyleBackColor = false;
            this.btnGithubFrm1.Click += new System.EventHandler(this.btnGithubFrm1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(419, 464);
            this.Controls.Add(this.btnGithubFrm1);
            this.Controls.Add(this.btnLinkedinFrm1);
            this.Controls.Add(this.btnRest);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Pomodoro Timer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnRest;
        private System.Windows.Forms.Button btnLinkedinFrm1;
        private System.Windows.Forms.Button btnGithubFrm1;
    }
}

