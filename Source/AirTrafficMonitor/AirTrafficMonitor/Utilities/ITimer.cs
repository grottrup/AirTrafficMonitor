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
        #region Public Events

        event ElapsedEventHandler Elapsed;

        #endregion

        #region Public Properties

        double Interval { get; set; }

        #endregion

        #region Public Methods and Operators

        void Dispose();

        void Start();

        void Stop();

        #endregion
    }
}
