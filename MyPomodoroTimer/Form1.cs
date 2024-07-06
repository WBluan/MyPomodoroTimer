using MyPomodoroTimer.Components;
using MyPomodoroTimer.Route;
using System;
using System.Windows.Forms;

namespace MyPomodoroTimer
{
    public partial class Form1 : Form
    {
        private readonly MyPages _pages = new MyPages();
        private int _minutesWork;
        private int _minutesRest;
        public bool ConfigAberta { get; set; } = false;

        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
        }



        public void UpdateTimerDisplay()
        {
            int minutesWork = _minutesWork / 60;
            int secondsWork = _minutesWork % 60;
            int minutesRest= _minutesRest / 60;
            int secondsRest = _minutesRest % 60;
            
            label2.Text = $"Concentração: {minutesWork:00}:{secondsWork:00}";
            label1.Text = $"Repouso: {minutesRest:00}:{secondsRest:00}";
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2
            {
                MinutesRest= _minutesRest,
                MinutesWork = _minutesWork
            };
            form2.StartWorking();
            form2.Show();
        }
        private void btnConfig_Click(object sender, EventArgs e)
        {
            
            if(!ConfigAberta)
            {
                FormConfig formConfig = new FormConfig(this);
                formConfig.Show();
                ConfigAberta = true;
            }
        }

        public void RestartTime(int workValue, int restValue)
        {
            _minutesWork = workValue * 60;
            _minutesRest = restValue * 60;
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2
            {
                MinutesRest = _minutesRest,
                MinutesWork = _minutesWork
            };
            form2.StartResting();
            form2.Show();
        }
        private void btnLinkedinFrm1_Click(object sender, EventArgs e)
        {
            _pages.GoToPage(_pages.Linkedin);
        }

        private void btnGithubFrm1_Click(object sender, EventArgs e)
        {
            _pages.GoToPage(_pages.Github);
        }
    }
}

