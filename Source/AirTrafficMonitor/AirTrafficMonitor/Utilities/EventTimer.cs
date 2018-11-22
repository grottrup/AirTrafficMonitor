using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using NPlant.Console;

namespace AirTrafficMonitor.Utilities
{
    public class EventTimer: Timer
    {
        private Timer _timer;

        public EventTimer(int milliSeconds)
        {
            _timer = new Timer(milliSeconds);
            _timer.AutoReset = false; // use as stop watch when false. do not repeat times event
            _timer.Enabled = true; // when time have went activate event. elapsed is only raised once
        }
        
    }
}
