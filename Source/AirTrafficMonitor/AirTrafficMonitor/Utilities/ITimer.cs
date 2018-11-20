using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace AirTrafficMonitor.Utilities
{
   public interface ITimer
    {
        //bool Flag { get; set; }
        //void WaitTimer();
        event ElapsedEventHandler Elapsed;

        double Interval { get; set; }

        void Dispose();

        void Start();

        void Stop();

    }
}
