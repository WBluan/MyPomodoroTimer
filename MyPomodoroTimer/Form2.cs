using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPomodoroTimer
{
    public partial class Form2 : Form
    {
        public int MinutesWork { get; set; }
        public int MinutesRest { get; set; }
        private int _trabalhoAtual;
        private int _repousoAtual;
        private bool _isWorking;
        private bool _isPaused;
        public Form2()
        {
            InitializeComponent();
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
            if(MinutesRest == 0 && MinutesWork == 0)
            {
                MinutesWork = 25*60;
                MinutesRest = 5*60;
            }
            _trabalhoAtual = MinutesWork;
            _repousoAtual = MinutesRest;
            UpdateTimerDisplay(lblWorkF2);

        }

        private void btnStartFrm2_Click(object sender, EventArgs e)
        {
            if (_isWorking)
            {
                if (_isPaused)
                {
                    _isPaused = false;
                    btnPauseFrm2.Enabled = true;
                    timerForm2.Start();
                }
                else
                {
                    StartWorking();
                    UpdateTimerDisplay(lblWorkF2);
                }
            }
            else
            {
                if (_isPaused)
                {
                    _isPaused = false;
                    btnPauseFrm2.Enabled = true;
                    timerForm2.Start();
                }
                else
                {
                    StartResting();
                    UpdateTimerDisplay(lblWorkF2);
                }
            }
        }

        public void StartResting()
        {
            UpdateTimerDisplay(lblWorkF2);
            lblWorkF2.ForeColor = Color.Green;
            RestartTime();
            _isPaused = false;
            _isWorking = false;
            btnPauseFrm2.Enabled = true;
            timerForm2.Start();
        }

        public void StartWorking()
        {
            UpdateTimerDisplay(lblWorkF2);
            lblWorkF2.ForeColor = Color.Black;
            RestartTime();
            _isPaused = false;
            btnPauseFrm2.Enabled = true;
            _isWorking = true;
            timerForm2.Start();
        }

        private void UpdateTimerDisplay(Label lblUpdate)
        {
            int totalSeconds = _isWorking ? _trabalhoAtual : _repousoAtual;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            if (_isWorking == true)
            {
                lblUpdate.Text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                lblUpdate.Text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }

        private void RestartTime()
        {
            _trabalhoAtual = MinutesWork;
            _repousoAtual = MinutesRest;
        }

        private void timerForm2_Tick(object sender, EventArgs e)
        {
            if(_isWorking)
            {
                if(_trabalhoAtual > 0)
                {
                   _trabalhoAtual--;
                   UpdateTimerDisplay(lblWorkF2);
                } 
                else if (_trabalhoAtual == 0)
                {
                    _isWorking = false;
                    timerForm2.Stop();
                }
            }
            else
            {
                if(_repousoAtual > 0)
                {
                    _repousoAtual--;
                    
                    UpdateTimerDisplay(lblWorkF2);
                }
                else if(_repousoAtual == 0)
                {
                    _isWorking = true;
                    timerForm2.Stop();
                }
            }
        }

        private void btnPauseFrm2_Click(object sender, EventArgs e)
        {
            PauseWork();
        }

        private void PauseWork()
        {
           _isPaused = true;
           timerForm2.Stop();
           btnStartFrm2.Enabled = true;
           btnPauseFrm2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Show();
            StopPomodoro();
        }

        private void StopPomodoro()
        {
            this.Close();
        }
    }
}
