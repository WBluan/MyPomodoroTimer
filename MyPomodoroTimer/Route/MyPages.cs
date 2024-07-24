using System;
using System.Diagnostics;

namespace MyPomodoroTimer.Route
{
    public class MyPages
    {
        private string _linkedin = "https://www.linkedin.com/in/luanwb/";
        private string _github = "https://github.com/WBluan";
        public void GoToLinkedin() 
        { 
            Process.Start(_linkedin);
        }
        public void GoToGithub()
        {
            Process.Start(_github);
        }
    }
}
