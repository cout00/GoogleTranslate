using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace UICatel.Blink
{
    public enum State
    {
        Minimazed,
        Maximazed,
    }


    public abstract class Blink
    {
        readonly Timer _timer = new Timer();
        internal Window Wnd;
        protected int MaxPos;
        protected int Dx;
        protected bool PositionFinded;

        private State _State;

        protected Blink(Window wnd)
        {
            //_State=State.Minimazed;
            this.Wnd = wnd;
            wnd.Top = 0;
            _timer.Elapsed += Timer_Elapsed;
        }

        public State State
        {
            get { return _State; }
            set
            {
                PositionFinded = false;
                _State = value;
                switch (_State)
                {
                    case State.Maximazed:
                    {
                        StartMove();
                        break;
                    }
                    case State.Minimazed:
                    {
                        BackMove();
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected abstract void GetNextPos(int nextPos);

        protected abstract void InitStartParams();

        protected abstract void InitEndParams();

        void StartMove()
        {
            _timer.Interval = 60;
            InitStartParams();
            _timer.Start();
        }

        void BackMove()
        {
            _timer.Interval = 60;
            InitEndParams();
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