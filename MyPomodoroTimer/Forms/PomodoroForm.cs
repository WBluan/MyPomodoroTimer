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
        private int _minutesWork;
        private int _minutesRest;
        private Timer _timer; 
        private float _labelOriginalSize;
        private float _labelExpandSize = 24f;
        private int _animationDuration = 1000;
        private bool _isAnimating = false;
        private DateTime _animationStartTime;

        WMPLib.WindowsMediaPlayer wplayer;
        string caminhoDoProjeto = AppDomain.CurrentDomain.BaseDirectory;
        private PomodoroTimer _pomodoroTimer;
        public PomodoroForm()
        {
            InitializeComponent();
             _minutesWork = PomodoroSettings.Instance.MinutesWork;
            _minutesRest = PomodoroSettings.Instance.MinutesRest;

            _pomodoroTimer = new PomodoroTimer(_minutesWork, _minutesRest);

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += AnimationTimer_Tick;
            _labelOriginalSize = lblWorkF2.Font.Size;
            string caminhoDoArquivo = System.IO.Path.Combine(caminhoDoProjeto, "src", "alert.mp3");
            wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = caminhoDoArquivo;

        }

        private void OnLabelColorChanged(Color color)
        {
            lblWorkF2.Invoke((MethodInvoker)(() => {
                lblWorkF2.ForeColor = color;
            }));
        }

        private void OnPauseButtonStateChanged(bool isEnabled)
        {
            btnPauseFrm2.Invoke((MethodInvoker)(() => {
                btnPauseFrm2.Enabled = isEnabled;
            }));
        }

        private void OnTimerUpdated(int currentWork, int currentRest)
        {
            int totalSeconds = _pomodoroTimer.IsWorking ? currentWork : currentRest;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            lblWorkF2?.Invoke((MethodInvoker)(() => {
                lblWorkF2.Text = $"{minutes:00}:{seconds:00}";
            }));
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
            _pomodoroTimer.OnTimeUpdated += OnTimerUpdated;
            _pomodoroTimer.LabelColorChanged += OnLabelColorChanged;
            _pomodoroTimer.PauseButtonStateChanged += OnPauseButtonStateChanged;
        }

        private void btnStartFrm2_Click(object sender, EventArgs e)
        {
            if(!_pomodoroTimer.IsPaused) { return; }

            if (!_pomodoroTimer.IsStoped)
            {
                _pomodoroTimer.ResumeTimer();
            }
            else
            {
                if (_pomodoroTimer.IsWorking)
                {
                    _pomodoroTimer.StartWork();
                }
                else
                {
                    _pomodoroTimer.StartRest();
                }
            }
        }

        public void StartResting()
        {
            _pomodoroTimer.StartRest();
        }

        public void StartWorking()
        {
            _pomodoroTimer.StartWork();
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
            //double progress = 1;
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
