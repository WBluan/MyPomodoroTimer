using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPomodoroTimer.Components
{
    public class CustomLabel : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                         Color.Red, 5, ButtonBorderStyle.Solid,
                                         Color.Red, 5, ButtonBorderStyle.Solid,
                                         Color.Red, 5, ButtonBorderStyle.Solid,
                                         Color.Red, 5, ButtonBorderStyle.Solid);
        }
    }
}
