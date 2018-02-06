using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UICatel.Blink
{
    public class RightBlink :Blink
    {
        public RightBlink(Window wnd) : base(wnd)
        {
            base.Wnd.Height = (int)SystemParameters.PrimaryScreenHeight;
            base.Wnd.Left = (int)SystemParameters.PrimaryScreenWidth;
        }
        protected override void InitStartParams()
        {
            Dx = -1;                        
            MaxPos = (int)SystemParameters.PrimaryScreenWidth - (int)Wnd.Width;
        }

        protected override void InitEndParams()
        {
            Dx = 1;
            MaxPos = (int)SystemParameters.PrimaryScreenWidth;
        }

        protected override void GetNextPos(int NextPos)
        {
            Wnd.Dispatcher.Invoke((Action)(() =>
            {
                
                if (Dx == -1)
                {
                    if (Wnd.Left < MaxPos)
                    {
                        PositionFinded = true;
                        Wnd.Left = MaxPos;
                        return;
                    }
                }
                else
                {
                    if (Wnd.Left > MaxPos)
                    {
                        PositionFinded = true;
                        Wnd.Left = MaxPos;
                        return;
                    }
                }
                Wnd.Left += NextPos;
            }));

        }

    }
}
