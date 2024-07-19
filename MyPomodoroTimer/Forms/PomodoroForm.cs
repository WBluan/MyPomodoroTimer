using MyPomodoroTimer.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPomodoroTimer
{
    public partial class PomodoroForm : Form
    {
        private int _trabalhoAtual;
        private int _repousoAtual;
        private int _minutesWork;
        private int _minutesRest;
        private bool _isWorking;
        private bool _isPaused;
        public PomodoroForm()
        {
            InitializeComponent();
            _minutesWork = PomodoroSettings.Instance.MinutesWork;
            _minutesRest = PomodoroSettings.Instance.MinutesRest;
            RestartTimes();
            _isWorking = true;
            _isPaused = false;
        }

        private void InitializePosition()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int formX = bounds.Width - this.Width;
            int formY = 0;
            this.Location = new Point(formX, formY);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InitializePosition();
            UpdateTimerDisplay();
        }

        private void btnStartFrm2_Click(object sender, EventArgs e)
        {
            if(!_isPaused && timerForm2.Enabled) { return; }

            if (_isPaused)
            {
                ResumeTimer();
            }
            else
            {
                if (_isWorking)
                {
                    StartWorking();
                }
                else
                {
                    StartResting();
                }
            }
        }

        public void StartResting()
        {
            _isPaused = false;
            _isWorking = false;
            RestartTimes();
            UpdateTimerDisplay();
            lblWorkF2.ForeColor = Color.Green;
            btnPauseFrm2.Enabled = true;
            timerForm2.Start();
        }

        public void StartWorking()
        {
            _isPaused = false;
            _isWorking = true;
            RestartTimes();
            UpdateTimerDisplay();
            lblWorkF2.ForeColor = Color.Black;
            btnPauseFrm2.Enabled = true;
            timerForm2.Start();
        }
        private void ResumeTimer()
        {
            _isPaused = false;
            btnPauseFrm2.Enabled = true;
            timerForm2.Start();
        }

        private void UpdateTimerDisplay()
        {
            int totalSeconds = _isWorking ? _trabalhoAtual : _repousoAtual;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            lblWorkF2.Text = $"{minutes:00}:{seconds:00}";
        }
        private void ResetWorkTime()
        {
            _trabalhoAtual = _minutesWork * 60;
        }
        private void ResetRestTime()
        {
            _repousoAtual = _minutesRest * 60;
        }
        private void RestartTimes()
        {
            ResetWorkTime();
            ResetRestTime();
        }


        private void timerForm2_Tick(object sender, EventArgs e)
        {
            if(_isWorking)
            {
                if(_trabalhoAtual > 0)
                {
                   _trabalhoAtual--;
                   UpdateTimerDisplay();
                } 
                else
                {
                    timerForm2.Stop();
                    StartResting();
                }
            }
            else
            {
                if(_repousoAtual > 0)
                {
                    _repousoAtual--;
                    UpdateTimerDisplay();
                }
                else 
                {
                    timerForm2.Stop();
                    StartWorking();
                }
            }
        }

        private void btnPauseFrm2_Click(object sender, EventArgs e)
        {
            PauseTimer();
        }

        private void PauseTimer()
        {
           _isPaused = true;
           timerForm2.Stop();
           btnPauseFrm2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            MainForm form1 = new MainForm();
            form1.Show();
            StopPomodoro();
        }

        private void StopPomodoro()
        {
            this.Close();
        }
    }
}
