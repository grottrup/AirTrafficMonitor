using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Utilities
{
    public class EventTimer: ITimer
    {
        public bool Flag { get; set; }
        public void WaitTimer()
        {
            Flag = false;
            var timer = new System.Timers.Timer(5000);
            timer.Elapsed += (src, args) => { Flag = true; };
            timer.AutoReset = false;
            timer.Start();
        }
    }
}
