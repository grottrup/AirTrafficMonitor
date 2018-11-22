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
    public class StringEventTimer: Timer, ITimer
    {
        private Timer _timer;
        private string _strToHandle;
        public event EventHandler<ElapsedEventArgsWithString> Elapsed;

        public StringEventTimer(int milliSeconds, string strToHandle)
        {
            _strToHandle = strToHandle;
            _timer = new Timer(milliSeconds);
            _timer.AutoReset = false; // use as stop watch when false. do not repeat times event
            _timer.Enabled = true; // when time have went activate event. elapsed is only raised once
            _timer.Elapsed += HasElapsed;
        }

        private void HasElapsed(object sender, ElapsedEventArgs e)
        {
            ElapsedEventArgsWithString args = new ElapsedEventArgsWithString(_strToHandle);
            Elapsed?.Invoke(this, args);
        }
    }
}
