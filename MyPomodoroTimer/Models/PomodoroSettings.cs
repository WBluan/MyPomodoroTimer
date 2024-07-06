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
        private Settings _settings;
        public int MinutesWork 
        {
            get => _settings.MinutesWork;
            set
            {
                if (value <=0) { throw new ArgumentException("Valor inválido"); }
                _settings.MinutesWork = value;
                _settings.Save();
            } 
        }
        public int MinutesRest
        {
            get => _settings.MinutesRest;
            set
            {
                if(value <=0) { throw new ArgumentException("Valor inválido"); }
                _settings.MinutesRest = value;
                _settings.Save();
            }
        }

        public PomodoroSettings()
        {
            _settings = new Settings();
        }
    }
}
