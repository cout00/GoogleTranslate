using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace UICatel.Blink
{
    public abstract class Blink
    {
        readonly Timer _timer = new Timer();
        internal Window Wnd;
        protected int MaxPos;
        protected int Dx;
        protected bool PositionFinded;

        protected Blink(Window wnd)
        {
            this.Wnd = wnd;
            _timer.Elapsed += Timer_Elapsed;
            _timer.Interval = 60;
        }

        protected abstract void GetNextPos(int nextPos);

        public void StartMove()
        {
            _timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int speed = 10;
            while (!PositionFinded)
            {
                GetNextPos(speed * Dx);
                if (speed > 1)
                {
                    speed--;
                }
                else
                {
                    if (_timer.Interval > 1)
                    {
                        _timer.Interval -= 3;
                    }
                    else
                        _timer.Interval = 1;
                }
            }
            _timer.Stop();
        }
    }
}