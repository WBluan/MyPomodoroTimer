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
        private readonly MainForm _mainForm;
        public FormConfig(MainForm mainForm)
        {
            InitializeComponent();
            MaximizeBox = false;
            _mainForm = mainForm;
            numericUpDown1.Value = PomodoroSettings.Instance.MinutesWork;
            numericUpDown2.Value = PomodoroSettings.Instance.MinutesRest;
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int minutesWork = (int)numericUpDown1.Value;
            int minutesRest = (int)numericUpDown2.Value;

            PomodoroSettings.Instance.MinutesWork = minutesWork;
            PomodoroSettings.Instance.MinutesRest = minutesRest;
            PomodoroSettings.Instance.SaveSettings();
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
