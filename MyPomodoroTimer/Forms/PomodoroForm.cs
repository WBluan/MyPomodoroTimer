using MyPomodoroTimer.Models;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace MyPomodoroTimer
{
    public partial class PomodoroForm : Form
    {
        private readonly Timer _animationTimer;
        private readonly PomodoroTimer _pomodoroTimer;

        private int _minutesWork;
        private int _minutesRest;
        private Timer _timer;

        private float _labelOriginalSize;
        private float _labelExpandSize = 24f;
        private bool _isAnimating = false;
        private DateTime _animationStartTime;

        public PomodoroForm(PomodoroTimer pomodoroTimer)
        {
            _pomodoroTimer = pomodoroTimer;
            InitializeComponent();
            _minutesWork = PomodoroSettings.Instance.MinutesWork;
            _minutesRest = PomodoroSettings.Instance.MinutesRest;

            _pomodoroTimer.OnTimeUpdated += OnTimerUpdated;
            _pomodoroTimer.LabelColorChanged += OnLabelColorChanged;
            _pomodoroTimer.PauseButtonStateChanged += OnPauseButtonStateChanged;


            _animationTimer = new Timer { Interval = 1000 };
            _animationTimer.Tick += AnimationTimer_Tick;

            _labelOriginalSize = lblWorkF2.Font.Size;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            InitializePosition();
            var (currentWork, currentRest) = _pomodoroTimer.RestartTimes();
            OnTimerUpdated(currentWork, currentRest);
            OnLabelColorChanged(_pomodoroTimer.IsWorking);
        }

        private void InitializePosition()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int formX = bounds.Width - this.Width;
            int formY = 0;
            this.Location = new Point(formX, formY);
        }

        private void OnLabelColorChanged(bool isWorking)
        {
            if (lblWorkF2.IsHandleCreated)
            {
                lblWorkF2.Invoke((MethodInvoker)(() =>
                {
                    lblWorkF2.ForeColor = isWorking ? Color.Black : Color.Green;
                }));
            }
        }

        private void OnPauseButtonStateChanged(bool isEnabled)
        {
            if (btnPauseFrm2.IsHandleCreated)
            {
                btnPauseFrm2.Invoke((MethodInvoker)(() =>
                {
                    btnPauseFrm2.Enabled = isEnabled;
                }));

            }
        }


        private void OnTimerUpdated(int currentWork, int currentRest)
        {
            if (lblWorkF2.InvokeRequired)
            {
                // Verifica se o controle já foi criado
                if (lblWorkF2.IsHandleCreated)
                {
                    lblWorkF2.Invoke((MethodInvoker)(() =>
                    {
                        UpdateLabel(currentWork, currentRest);
                    }));
                }
            }
            else
            {
                UpdateLabel(currentWork, currentRest);
            }
        }


        private void btnStartFrm2_Click(object sender, EventArgs e)
        {
            if (!_pomodoroTimer.IsPaused && !_pomodoroTimer.IsStoped) return;
            StartSession(_pomodoroTimer.IsWorking, _pomodoroTimer.IsPaused);
        }

        private void btnPauseFrm2_Click(object sender, EventArgs e)
        {
            _pomodoroTimer.Pause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _pomodoroTimer.Pause();
            MainForm form1 = new MainForm();
            form1.Show();
            this.Close();
        }

        private void StartSession(bool isWorking, bool isPaused)
        {
            if(isPaused)
            {
                StartAnimation();
                _pomodoroTimer.ResumeTimer();
                return;
            }

            StartAnimation();
            OnTimerUpdated(_pomodoroTimer.MinutesWork, _pomodoroTimer.MinutesRest);
            OnLabelColorChanged(isWorking);

            if (isWorking)
                _pomodoroTimer.StartWork();
            else
                _pomodoroTimer.StartRest();

        }

        public void StartResting()
        {
            OnTimerUpdated(_minutesWork, _minutesRest);
            OnLabelColorChanged(_pomodoroTimer.IsWorking);
            _pomodoroTimer.StartRest();
            //StartAnimation();
        }

        public void StartWorking()
        {
            OnTimerUpdated(_minutesWork, _minutesRest);
            OnLabelColorChanged(_pomodoroTimer.IsWorking);
            _pomodoroTimer.StartWork();
            //StartAnimation();
        }

        private void UpdateLabel(int currentWork, int currentRest)
        {
            int totalSeconds = _pomodoroTimer.IsWorking ? currentWork : currentRest;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            lblWorkF2.Text = $"{minutes:00}:{seconds:00}";
        }


        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - _animationStartTime;
            double progress = Math.Min(elapsed.TotalMilliseconds / _pomodoroTimer.AnimationDuration, 1);
            float newSize = (float)(_labelOriginalSize + (_labelExpandSize - _labelOriginalSize) * Math.Sin(progress * Math.PI));
            lblWorkF2.Font = new Font(lblWorkF2.Font.FontFamily, newSize, lblWorkF2.Font.Style);

            if (progress >= 1.0)
            {
                _animationTimer.Stop();
                _isAnimating = false;
                lblWorkF2.Font = new Font(lblWorkF2.Font.FontFamily, _labelOriginalSize, lblWorkF2.Font.Style);
            }
        }
        private void StartAnimation()
        {
            if (!_isAnimating)
            {
                _isAnimating = true;
                _animationStartTime = DateTime.Now;
                _animationTimer.Start();
            }
        }

    }
}
