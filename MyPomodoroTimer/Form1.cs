﻿using MyPomodoroTimer.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        private bool isPaused;

        CustomLabel newLabel = new CustomLabel();
        public Form1()
        {
            InitializeComponent();
            btnRest.Hide();
            RestartTime();
        }

        private void ResetTimer()
        {
            StartWorking();
            UpdateTimerDisplay();
            btnRest.Visible = false;
            btnIniciar.Visible = true;
        }
        private void StartWorking()
        {
            RestartTime();
            isWorking = true;
            UpdateTimerDisplay();
            btnIniciar.Enabled = false;
            btnIniciar.Visible = true;
            btnRest.Visible = false;
            btnPause.Enabled = true;
            btnRestart.Enabled = true;
            timer1.Start();
        }

        private void StartResting()
        {
            RestartTime();
            isPaused = false;
            isWorking = false;
            UpdateTimerDisplay();
            btnIniciar.Hide();
            btnIniciar.Enabled = false;
            btnRest.Visible = true;
            btnRest.Enabled = false;
            btnPause.Enabled = true;
            btnRestart.Enabled = true;
            timer1.Start();
        }

        private void UpdateTimerDisplay()
        {
            int totalSeconds = isWorking ? minutesWork : minutesRest;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            if(isWorking == true)
            {
                label2.Text = string.Format("Concentração: {0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                label1.Text = string.Format("Repouso: {0:00}:{1:00}", minutes, seconds);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if(isPaused == true)
            {
                isWorking=true;
                isPaused = false;
                timer1.Start();
            }
            else
            {
                label1.Text = "Repouso: 05:00";
                StartWorking();
                UpdateTimerDisplay();
            }
        }

        private void RestartTime()
        {
            minutesWork = 25 * 60;
            minutesRest = 5 * 60;
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            if (isPaused == true)
            {
                isWorking = false;
                isPaused = false;
                timer1.Start();
            }
            else
            {
                label2.Text = "Concentração: 25:00";
                StartResting();
                isWorking = false;
                UpdateTimerDisplay();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            isPaused = true;
            timer1.Stop();
            btnIniciar.Enabled = true;
            btnPause.Enabled = true;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetTimer();
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
                else if(minutesWork == 0)
                {
                    btnIniciar.Hide();
                    btnRest.Show();
                    btnRest.Enabled = true;
                }
            }
           else
            {
                if(minutesRest > 0)
                {
                    minutesRest--;
                    UpdateTimerDisplay();
                }
                else if(minutesRest == 0)
                {
                    btnRest.Hide();
                    btnIniciar.Show();
                    btnIniciar.Enabled = true;
                }
            }
        }


    }
}

