using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Observer;
using AirTrafficMonitor.View;
using DependencyInjection;
using System.IO;

namespace AirTrafficMonitor
{

    public interface ILogger
    {
       //void DataLog(string Tag1, string Tag2, DateTime Time);
       //void ConsoleLog(string Tag1, string Tag2, DateTime Time);
        void DataLog(object test, FlightInCollision eventArgs);

    }
}