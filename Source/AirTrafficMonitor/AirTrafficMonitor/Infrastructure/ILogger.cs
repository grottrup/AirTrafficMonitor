using AirTrafficMonitor.Domain;
using System;

namespace AirTrafficMonitor.Infrastructure
{
    public interface ILogger
    {
        void DataLog(string loggingStr);
    }
}