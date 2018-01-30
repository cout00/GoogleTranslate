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
        public RightBlink(Window Wnd) : base(Wnd)
        {
            Dx = -1;
            MaxPos = (int)SystemParameters.PrimaryScreenWidth - (int)Wnd.Width;
            base.Wnd.Left = (int)SystemParameters.PrimaryScreenWidth;
            //timer.Start();
        }

        protected override void GetNextPos(int NextPos)
        {
            Wnd.Dispatcher.Invoke((Action)(() =>
            {
                Wnd.Left += NextPos;
                if (Dx == -1)
                {
                    if (Wnd.Left < MaxPos)
                    {
                        PositionFinded = true;
                    }
                }
                else
                {
                    if (Wnd.Left > MaxPos)
                    {
                        PositionFinded = true;
                    }

                }


            }));

        }
    }
}
