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
        private int _currentWork;
        private int _currentRest;
        private int _minutesWork;
        private int _minutesRest;
        private Timer _timer;
        public bool IsWorking { get; set; } = true;
        public bool IsPaused { get; set; } = false;
        public bool IsStoped { get; set; }

        public event Action<Color> LabelColorChanged;
        public event Action <bool> PauseButtonStateChanged;
        public event Action<int, int> OnTimeUpdated;

        public PomodoroTimer(int minutesWork, int minutesRest)
        {
            _minutesWork = minutesWork;
            _minutesRest = minutesRest;
            RestartTimes();
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
            StartWork();
            OnTimeUpdated?.Invoke(_currentWork, _currentRest);
        }

        
        public void StartWork()
        {
            IsPaused = false;
            IsWorking = true;
            IsStoped = false;
            RestartTimes ();
            _timer.Start();
            PauseButtonStateChanged?.Invoke(true);
        }

        public void StartRest()
        {
            IsPaused = false;
            IsWorking = false;
            IsStoped = false;
            RestartTimes();
            _timer.Start();
            PauseButtonStateChanged?.Invoke(true);
        }
        public void Stop()
        {
            Pause();
            IsStoped = true;
        }
        public void Pause()
        {
            IsPaused = true;
            _timer.Stop();
            PauseButtonStateChanged?.Invoke(false);
        }

        private void RestartTimes()
        {
            _currentWork = _minutesWork * 60;
            _currentRest = _minutesRest * 60;
        }

        public void ResumeTimer()
        {
            IsPaused = false;
            _timer.Start();
            PauseButtonStateChanged?.Invoke(true);

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (IsWorking)
            {
                if (_currentWork > 0)
                {
                    LabelColorChanged?.Invoke(Color.Black);
                    _currentWork--;
                    OnTimeUpdated?.Invoke(_currentWork, _currentRest);

                }
                else
                {
                    Stop();
                    IsWorking = false;
                }
            }
            else
            {
                if(_currentRest > 0)
                {
                    LabelColorChanged?.Invoke(Color.Green);
                    _currentRest--;
                    OnTimeUpdated?.Invoke(_currentWork, _currentRest);
                }
                else
                {
                    Stop();
                    IsWorking = true;
                }
            }
        }

        public void ToggleWorkRest()
        {
            IsWorking = !IsWorking;
            RestartTimes ();
            ResumeTimer();
        }
    }
}
