﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Utilities
{
    public interface ITimer
    {
        event EventHandler<ElapsedEventArgsWithString> Elapsed;
    }
}
