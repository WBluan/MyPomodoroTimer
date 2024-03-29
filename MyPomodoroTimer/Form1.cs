﻿using MyPomodoroTimer.Components;
using MyPomodoroTimer.Route;
using System;
using System.Windows.Forms;

namespace MyPomodoroTimer
{
    public partial class Form1 : Form
    {
        MyPages pages = new MyPages();
        Form2 form2 = new Form2(); 
        public int _minutesWork;
        public int _minutesRest;
        public bool configAberta = false;

        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }



        public void UpdateTimerDisplay()
        {
            int minutesWork = _minutesWork / 60;
            int secondsWork = _minutesWork % 60;
            int minutesRest= _minutesRest / 60;
            int secondsRest = _minutesRest % 60;
            
            label2.Text = string.Format("Concentração: {0:00}:{1:00}", minutesWork, secondsWork);
            label1.Text = string.Format("Repouso: {0:00}:{1:00}", minutesRest, secondsRest);
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.minutesWork = _minutesWork;
            form2.minutesRest = _minutesRest;
            form2.StartWorking();
            form2.Show();
        }
        private void btnConfig_Click(object sender, EventArgs e)
        {
            
            if(!configAberta)
            {
                FromConfig formConfig = new FromConfig();
                formConfig.form1 = this;
                formConfig.Show();
                configAberta = true;

            }
        }

        public void RestartTime(int workValue, int restValue)
        {
            _minutesWork = workValue * 60;
            _minutesRest = restValue * 60;
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.minutesWork = _minutesWork;
            form2.minutesRest = _minutesRest;
            form2.StartResting();
            form2.Show();
        }
        private void btnLinkedinFrm1_Click(object sender, EventArgs e)
        {
            pages.GoToPage(pages.Linkedin);
        }

        private void btnGithubFrm1_Click(object sender, EventArgs e)
        {
            pages.GoToPage(pages.Github);
        }
    }
}

