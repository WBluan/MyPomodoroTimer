using MyPomodoroTimer.Models;
using MyPomodoroTimer.Properties;
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
        private PomodoroSettings _pomodoroSettings;
        private readonly MainForm _mainForm;
        public FormConfig(MainForm mainForm)
        {
            InitializeComponent();
            _pomodoroSettings = new PomodoroSettings();
            _mainForm = mainForm;
            numericUpDown1.Value = _pomodoroSettings.MinutesWork;
            numericUpDown2.Value = _pomodoroSettings.MinutesRest;
        }
        private void DefinirTempo()
        {
            _pomodoroSettings.MinutesWork = (int)numericUpDown1.Value;
            _pomodoroSettings.MinutesRest = (int)numericUpDown2.Value;
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DefinirTempo();
            _mainForm.RestartTime(_pomodoroSettings.MinutesWork, _pomodoroSettings.MinutesRest);
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
