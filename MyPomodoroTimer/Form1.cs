using MyPomodoroTimer.Components;
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
    public partial class Form1 : Form
    {
        private int minutesWork;
        private int minutesRest;
        private int secondsLeft;
        private bool isWorking;

        CustomLabel newLabel = new CustomLabel();
        public Form1()
        {
            InitializeComponent();
            minutesWork = 25 * 60;
            minutesRest = 5 * 60;
        }

        private void ResetTimer()
        {
            secondsLeft = 1500;
            StartWorking();
            UpdateTimerDisplay();
        }
        private void StartWorking()
        {
            secondsLeft = 1500; // 25 minutes
            isWorking = true;
            UpdateTimerDisplay();
            btnIniciar.Enabled = false;
            btnPause.Enabled = true;
            btnRestart.Enabled = true;
            timer1.Start();
        }

        private void StartResting()
        {
            secondsLeft = 300;
            isWorking = false;
            UpdateTimerResting();
            btnIniciar.Enabled = false;
            btnPause.Enabled = true;
            btnRestart.Enabled = true;
            timer1.Start();
        }

        private void UpdateTimerDisplay()
        {
            int totalSeconds = isWorking ? minutesWork : minutesRest;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            label2.Text = string.Format( "Concentração: {0:00}:{1:00}", minutes, seconds);
        }
        private void UpdateTimerResting()
        {
            int minutes = minutesWork / 60;
            int seconds = secondsLeft % 60;
            label2.Text = $"Concentração: {minutesWork:D2}:{minutesWork:D2}";
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            StartWorking();
            timer1.Start();
            UpdateTimerDisplay();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btnIniciar.Enabled = true;
            btnPause.Enabled = true;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
           if(isWorking)
            {
                if(minutesWork > 0)
                {
                    minutesWork--;
                    UpdateTimerDisplay();
                }
                else
                {
                    isWorking = false;
                    minutesRest = 5 * 60;
                    UpdateTimerDisplay();
                }
            }
           else
            {
                if(minutesRest > 0)
                {
                    minutesRest--;
                    UpdateTimerDisplay();
                }
                else
                {
                    isWorking = true;
                    minutesWork = 25 * 60;
                    UpdateTimerDisplay();
                }
            }
        }
    }
}

