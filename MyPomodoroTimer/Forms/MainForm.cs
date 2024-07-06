using MyPomodoroTimer.Components;
using MyPomodoroTimer.Models;
using MyPomodoroTimer.Route;
using System;
using System.Windows.Forms;

namespace MyPomodoroTimer
{
    public partial class MainForm : Form
    {
        private readonly MyPages _pages;
        private int _minutesWork;
        private int _minutesRest;
        private PomodoroSettings _pomodoroSettings;
        public bool ConfigAberta { get; set; } = false;

        public MainForm()
        {
            InitializeComponent();
            _pomodoroSettings = new PomodoroSettings();
            _pages = new MyPages();
            MaximizeBox = false;
            RestartTime(_pomodoroSettings.MinutesWork, _pomodoroSettings.MinutesRest);
            UpdateTimerDisplay();
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
            ShowPomodoroForm(true);
        }
        private void btnRest_Click(object sender, EventArgs e)
        {
            ShowPomodoroForm(false);
        }
        private void ShowPomodoroForm(bool startWorking)
        {
            Hide();
            PomodoroForm pomodoroForm = new PomodoroForm();
            if (startWorking)
            {
                pomodoroForm.StartWorking();
            }
            else
            {
                pomodoroForm.StartResting();
            }
            pomodoroForm.Show();
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
        private void btnLinkedinFrm1_Click(object sender, EventArgs e)
        {
            _pages.GoToLinkedin();
        }

        private void btnGithubFrm1_Click(object sender, EventArgs e)
        {
            _pages.GoToGithub();
        }
    }
}

