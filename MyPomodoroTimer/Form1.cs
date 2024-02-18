using MyPomodoroTimer.Components;
using MyPomodoroTimer.Route;
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
        MyPages pages = new MyPages();
        Form2 form2 = new Form2(); 
        public int minutesWork;
        public int minutesRest;
        private int secondsLeft;
        private bool isWorking;
        private bool isPaused;

        CustomLabel newLabel = new CustomLabel();
        public Form1()
        {
            InitializeComponent();
            btnRestart.Enabled = false;
            this.MaximizeBox = false;
        }



        public void UpdateTimerDisplay(Label labelUpdate)
        {
            int totalSeconds = isWorking ? minutesWork : minutesRest;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            if(isWorking == true)
            {
                labelUpdate.Text = string.Format("Concentração: {0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                label1.Text = string.Format("Repouso: {0:00}:{1:00}", minutes, seconds);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.StartWorking();
            form2.Show();
        }

        public void RestartTime()
        {
            minutesWork = 25 * 60;
            minutesRest = 5 * 60;
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.StartResting();
            form2.Show();
        }



        private void btnRestart_Click(object sender, EventArgs e)
        {

        }


        public void timer1_Tick_1(object sender, EventArgs e)
        {
           if(isWorking)
            {
                if(minutesWork > 0)
                {
                    minutesWork--;
                    UpdateTimerDisplay(label2);
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
                    UpdateTimerDisplay(label1);
                }
                else if(minutesRest == 0)
                {
                    btnRest.Hide();
                    btnIniciar.Show();
                    btnIniciar.Enabled = true;
                }
            }
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

