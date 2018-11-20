using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AirTrafficMonitor.Utilities
{
    public class EventTimer: ITimer
    {
        private Timer _timer;

        public EventTimer(int milliSeconds)
        {
            _timer = new Timer(milliSeconds);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = false; // use as stop watch when false. do not repeat times event
            _timer.Enabled = true; // when time have went activate event. elapsed is only raised once

        }


        protected virtual void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Time event raised at: {0}\n",e.SignalTime);
        }

        void SetTimer()
        {
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = false; // use as stop watch when false. do not repeat times event
            _timer.Enabled = true; // when time have went activate event. elapsed is only raised once
            //_timer.Interval = milliSeconds;
        }
       
    }
}
