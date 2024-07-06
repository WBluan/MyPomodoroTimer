using System;
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
    public partial class FormConfig : Form
    {
        private bool _isOpen = false;
        private int _tempoTrabalhoEscolhido;
        private int _tempoRepousoEscolhido;
        private readonly Form1 _mainForm;
        public FormConfig(Form1 mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
            _isOpen = true;
    }
        private void DefinirTempo()
        {
            _tempoTrabalhoEscolhido = (int)numericUpDown1.Value;
            _tempoRepousoEscolhido = (int)numericUpDown2.Value;
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DefinirTempo();
            _mainForm.RestartTime(_tempoTrabalhoEscolhido, _tempoRepousoEscolhido);
            _mainForm.UpdateTimerDisplay();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void FromConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.ConfigAberta = false;
        }

        private void CloseForm()
        {
            this.Close();
            _mainForm.Show();
        }
    }
}
