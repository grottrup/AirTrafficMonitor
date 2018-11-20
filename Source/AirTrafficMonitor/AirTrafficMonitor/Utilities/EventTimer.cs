using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AirTrafficMonitor.Utilities
{
    public class EventTimer: Stopwatch, ITimer
    {
        //public bool Flag { get; set; }
        //public void WaitTimer()
        //{
        //    Flag = false;
        //    var timer = new System.Timers.Timer(5000);
        //    timer.Elapsed += (src, args) => { Flag = true; };
        //    timer.AutoReset = false;
        //    timer.Start();
        //}

        public event ElapsedEventHandler Elapsed;
        public double Interval { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
