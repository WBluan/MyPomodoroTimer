using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPomodoroTimer
{
    public partial class Form2 : Form
    {
        public int minutesWork;
        public int minutesRest;
        private int trabalhoAtual;
        private int repousoAtual;
        private bool isWorking;
        private bool isPaused;
        public Form2()
        {
            InitializeComponent();
            isWorking = true; isPaused = false;

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
            if(minutesRest == 0 && minutesWork == 0)
            {
                minutesWork = 25*60;
                minutesRest = 5*60;
            }
            trabalhoAtual = minutesWork;
            repousoAtual = minutesRest;
            UpdateTimerDisplay(lblWorkF2);

        }

        private void btnStartFrm2_Click(object sender, EventArgs e)
        {
            if (isWorking)
            {
                if (isPaused)
                {
                    isPaused = false;
                    btnPauseFrm2.Enabled = true;
                    //btnStartFrm2.Enabled = false;
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
                if (isPaused)
                {
                    isPaused = false;
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
            isPaused = false;
            isWorking = false;
            btnPauseFrm2.Enabled = true;
            timerForm2.Start();
        }

        public void StartWorking()
        {
            UpdateTimerDisplay(lblWorkF2);
            lblWorkF2.ForeColor = Color.Black;
            RestartTime();
            isPaused = false;
            btnPauseFrm2.Enabled = true;
            isWorking = true;
            timerForm2.Start();
        }

        private void UpdateTimerDisplay(Label lblUpdate)
        {
            int totalSeconds = isWorking ? trabalhoAtual : repousoAtual;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            if (isWorking == true)
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
            trabalhoAtual = minutesWork;
            repousoAtual = minutesRest;
        }

        private void timerForm2_Tick(object sender, EventArgs e)
        {
            if(isWorking)
            {
                if(trabalhoAtual > 0)
                {
                   trabalhoAtual--;
                   UpdateTimerDisplay(lblWorkF2);
                } 
                else if (trabalhoAtual == 0)
                {
                    isWorking = false;
                    timerForm2.Stop();
                }
            }
            else
            {
                if(repousoAtual > 0)
                {
                    repousoAtual--;
                    
                    UpdateTimerDisplay(lblWorkF2);
                }
                else if(repousoAtual == 0)
                {
                    isWorking = true;
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
           isPaused = true;
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
