using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPomodoroTimer.Models
{
    public class PomodoroTimer
    {
        private Timer _timer;
        private int _currentWork;
        private int _currentRest;

        private readonly WMPLib.WindowsMediaPlayer _wplayer;

        public int MinutesWork { get; set; }
        public int MinutesRest { get; set; }
        public bool IsWorking { get; set; } = true;
        public bool IsPaused { get; set; } = false;
        public bool IsStoped { get; set; }
        public int AnimationDuration { get; } = 1000;

        public event Action<bool> LabelColorChanged;
        public event Action<bool> PauseButtonStateChanged;
        public event Action<bool> StartButtonStateChanged;
        public event Action<int, int> OnTimeUpdated;

        public PomodoroTimer(int minutesWork, int minutesRest)
        {
            MinutesWork = minutesWork;
            MinutesRest = minutesRest;
            RestartTimes();

            _timer = new Timer { Interval = 1000 };
            _timer.Tick += Timer_Tick;


            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string alertFilePath = System.IO.Path.Combine(projectPath, "src", "alert.mp3");
            _wplayer = new WMPLib.WindowsMediaPlayer { URL = alertFilePath };
        }
        public (int, int) RestartTimes()
        {
            _currentWork = MinutesWork * 60;
            _currentRest = MinutesRest * 60;
            OnTimeUpdated?.Invoke(_currentWork, _currentRest);
            return (_currentWork, _currentRest);
        }


        public void StartWork()
        {
            IsPaused = false;
            IsWorking = true;
            IsStoped = false;
            RestartTimes();
            _timer.Start();
            ChangeButtonState(true, false);
        }

        public void StartRest()
        {
            LabelColorChanged?.Invoke(false);
            IsPaused = false;
            IsWorking = false;
            IsStoped = false;
            RestartTimes();
            _timer.Start();
            ChangeButtonState(true, false);
        }

        public void Stop()
        {
            _timer.Stop();
            IsStoped = true;
        }
        public void Pause()
        {
            IsPaused = true;
            _timer.Stop();
            ChangeButtonState(false, true);
        }
        public void ResumeTimer()
        {
            IsPaused = false;
            _timer.Start();
            ChangeButtonState(true, false);
        }
        public void PlayAlert()
        {
            try
            {
                _wplayer.controls.play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao tocar o alerta: {ex.Message}");
            }
        }

        public void ChangeButtonState(bool pause, bool start)
        {
            PauseButtonStateChanged?.Invoke(pause);
            StartButtonStateChanged?.Invoke(start);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (IsWorking)
            {
                if (_currentWork > 0)
                {
                    _currentWork--;
                    OnTimeUpdated?.Invoke(_currentWork, _currentRest);
                    return;
                }
                Stop();
                IsWorking = false;
                PlayAlert();
                return;
            }

            if (_currentRest > 0)
            {
                _currentRest--;
                OnTimeUpdated?.Invoke(_currentWork, _currentRest);
                return;
            }
            Stop();
            IsWorking = true;
            PlayAlert();
            return;
        }
    }
}
