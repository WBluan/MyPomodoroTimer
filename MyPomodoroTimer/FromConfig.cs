﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPomodoroTimer
{
    public partial class FromConfig : Form
    {

        public int tempoTrabalhoEscolhido;
        public int tempoRepousoEscolhido;
        public Form1 form1 = new Form1();
        public FromConfig()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            tempoTrabalhoEscolhido = (int)numericUpDown1.Value;
            tempoRepousoEscolhido = (int)numericUpDown2.Value;
            form1.RestartTime(tempoTrabalhoEscolhido, tempoRepousoEscolhido);
            form1.UpdateTimerDisplay();
            this.Close();
        }
    }
}
