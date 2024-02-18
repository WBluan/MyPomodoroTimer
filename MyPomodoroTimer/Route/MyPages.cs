using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPomodoroTimer.Route
{
    public class MyPages
    {
        public string Linkedin = "https://www.linkedin.com/in/luanwb/";
        public string Github = "https://github.com/WBluan";
        public void GoToPage(string LinkPage) 
        { 
            Process.Start(LinkPage);
        }
    }
}
