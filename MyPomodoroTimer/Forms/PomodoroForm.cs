﻿using MyPomodoroTimer.Models;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace MyPomodoroTimer
{
    public partial class PomodoroForm : Form
    {
        private int _currentWork;
        private int _currentRest;
        private int _minutesWork;
        private int _minutesRest;
        private bool _isWorking;
        private bool _isPaused;
        private Timer _timer; 
        private float _labelOriginalSize;
        private float _labelExpandSize = 24f;
        private int _animationDuration = 1000;
        private bool _isAnimating = false;
        private DateTime _animationStartTime;
        public PomodoroForm()
        {
            InitializeComponent();
            _minutesWork = PomodoroSettings.Instance.MinutesWork;
            _minutesRest = PomodoroSettings.Instance.MinutesRest;
            RestartTimes();
            _isWorking = true;
            _isPaused = false;
            _timer = new Timer();
            _timer.Interval = 10;
            _timer.Tick += AnimationTimer_Tick;
            _labelOriginalSize = lblWorkF2.Font.Size;
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
            StartAnimation();
            _isPaused = false;
            btnPauseFrm2.Enabled = true;
            timerForm2.Start();
        }

        private void UpdateTimerDisplay()
        {
            int totalSeconds = _isWorking ? _currentWork : _currentRest;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            lblWorkF2.Text = $"{minutes:00}:{seconds:00}";
        }
        private void ResetWorkTime()
        {
            _currentWork = _minutesWork * 60;
        }
        private void ResetRestTime()
        {
            _currentRest = _minutesRest * 60;
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
                if(_currentWork > 0)
                {
                   _currentWork--;
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
                if(_currentRest > 0)
                {
                    _currentRest--;
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

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - _animationStartTime;
            double progress = Math.Min(elapsed.TotalMilliseconds / _animationDuration, 1.0);
            float newSize = (float)(_labelOriginalSize + (_labelExpandSize - _labelOriginalSize) * Math.Sin(progress * Math.PI));
            lblWorkF2.Font = new Font(lblWorkF2.Font.FontFamily, newSize, lblWorkF2.Font.Style);
            if (progress >= 1.0)
            {
                _timer.Stop();
                _isAnimating = false;
                // Garantir que a fonte retorne ao tamanho original após a animação
                lblWorkF2.Font = new Font(lblWorkF2.Font.FontFamily, _labelOriginalSize, lblWorkF2.Font.Style);
            }
        }
        private void StartAnimation()
        {
            if (!_isAnimating)
            {
                _isAnimating = true;
                _animationStartTime = DateTime.Now;
                _timer.Start();
            }
        }

    }
}
