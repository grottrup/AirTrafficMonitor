using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Utilities
{
    interface ITimerFactory
    {
        ITimer CreateTimer();
    }
}
