using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo
{
    public enum TimerMode { BINGO_GAME, START_GAME};
    public class TimerEvent
    {
        private Timer timer = new Timer();
        public TimerMode Mode { get; set; }
        private int seconds, countdown = 5;
        public event EventHandler newNumber;
        public event EventHandler ThresholdReached;

        public int Threshold { get; set; }

        public TimerEvent()
        {
            timer.Interval = 1000;
            timer.Tick += TimerEvent_Tick;
        }

        public void Start()
        {
            timer.Enabled = true;
        }

        public void Stop()
        {
            timer.Enabled = false;
        }

        private void TimerEvent_Tick(object sender, EventArgs e)
        {
            switch(Mode)
            {
                case TimerMode.START_GAME:
                    countdown--;
                    if (countdown == 0)
                    {
                        startGame();
                        seconds = 0;
                    }
                    break;
                case TimerMode.BINGO_GAME:
                    seconds++;
                    countdown = 5;
                    if (Threshold - seconds == 0)
                    {
                        onNewNumber();
                        seconds = 0;
                    }
                    break;
                default:
                    break;
            }
        }

        protected void onNewNumber()
        {
            if(newNumber != null)
            {
                newNumber(this, EventArgs.Empty);
            }
        }

        protected void startGame()
        {
            if(ThresholdReached != null)
            {
                ThresholdReached(this, EventArgs.Empty);
            }
        }

    }
}
