using MyPomodoroTimer.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPomodoroTimer.Models
{
    public class PomodoroSettings
    {
        private static PomodoroSettings _instance;
        public static PomodoroSettings Instance => _instance ?? (_instance = new PomodoroSettings());
        private int _workTime;
        private int _restTime;
        public int MinutesWork 
        {
            get => _workTime;
            set
            {
                if (value <=0) { throw new ArgumentException("Valor inválido"); }
                _workTime = value;
                OnWorkTimeChanged?.Invoke(this, EventArgs.Empty);
            } 
        }
        public int MinutesRest
        {
            get => _restTime;
            set
            {
                if(value <=0) { throw new ArgumentException("Valor inválido"); }
                _restTime = value;
                OnRestTimeChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public PomodoroSettings()
        {
            _workTime = Settings.Default.MinutesWork;
            _restTime = Settings.Default.MinutesRest;
        }

        public event EventHandler OnWorkTimeChanged;
        public event EventHandler OnRestTimeChanged;

        public void SaveSettings()
        {
            Settings.Default.MinutesWork = _workTime;
            Settings.Default.MinutesRest = _restTime;
            Settings.Default.Save();
        }
    }
}
