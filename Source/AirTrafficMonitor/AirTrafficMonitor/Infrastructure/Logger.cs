using AirTrafficMonitor.Domain;
using System;
using System.IO;

namespace AirTrafficMonitor.Infrastructure
{
    public class Logger : ILogger
    {
        public void DataLog(object test, FlightInCollision eventArgs)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "DataLog.txt",
                "Warning, two planes are currently on collision course! " +
                "\n Plane Tag: " + eventArgs.Tag1 + " and plane Tag: " + eventArgs.Tag2 + "\n Current time: " +
                eventArgs.TimeStamp);
        }
    }
}
