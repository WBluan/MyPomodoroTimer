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
    public partial class Form2 : Form
    {
        private int minutesWork;
        private int minutesRest;
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
        }

        private void btnStartFrm2_Click(object sender, EventArgs e)
        {
            if (isWorking)
            {
                if (isPaused)
                {
                    isPaused = false;
                    btnPauseFrm2.Enabled = true;
                    btnStartFrm2.Enabled = false;
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
            lblWorkF2.Text = "05:00";
            RestartTime();
            isPaused = false;
            isWorking = false;
            btnStartFrm2.Enabled = false;
            btnPauseFrm2.Enabled = true;
            timerForm2.Start();
        }

        public void StartWorking()
        {
            lblWorkF2.Text = "25:00";
            RestartTime();
            isPaused = false;
            btnPauseFrm2.Enabled = true;
            isWorking = true;
            btnStartFrm2.Enabled = false;
            timerForm2.Start();
        }

        private void UpdateTimerDisplay(Label lblUpdate)
        {
            int totalSeconds = isWorking ? minutesWork : minutesRest;
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
            minutesRest = 5 * 60;
            minutesWork = 25 * 60;
        }

        private void timerForm2_Tick(object sender, EventArgs e)
        {
            if(isWorking)
            {
                if(minutesWork > 0)
                {
                   minutesWork--;
                   UpdateTimerDisplay(lblWorkF2);
                } 
                else if (minutesWork == 0)
                {
                    isWorking = false;
                    timerForm2.Stop();
                }
            }
            else
            {
                if(minutesRest > 0)
                {
                    minutesRest--;
                    lblWorkF2.ForeColor = Color.Green;
                    UpdateTimerDisplay(lblWorkF2);
                }
                else if(minutesRest == 0)
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
