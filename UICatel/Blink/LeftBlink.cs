using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UICatel.Blink
{
    public class LeftBlink :RightBlink
    {
        public LeftBlink(Window wnd) : base(wnd)
        {
            Dx = 1;
            MaxPos = 0;
            ((Blink) this).Wnd.Left = -((Blink) this).Wnd.Width;
        }        
    }
}
