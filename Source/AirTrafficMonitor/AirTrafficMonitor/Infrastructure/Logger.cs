using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using System;
using System.IO;
using System.Text;

namespace AirTrafficMonitor.Infrastructure
{
    public class Logger : ILogger
    {
        public void DataLog(FlightInCollision eventArgs)
        {
            string tag1 = eventArgs.Tag1;
            string tag2 = eventArgs.Tag2;
            DateTime time = eventArgs.TimeStamp;


            string path = @"DataLog.txt";

            if (!File.Exists(path))
            {
                var DL = File.CreateText(path);
                DL.Close();
            }

            using (var DL = File.AppendText(path))
            {
                DL.WriteLine("Warning, two planes are currently on collision course! " +
                             "\n Plane Tag: {0} and plane Tag: {1}\n Current time: {2}",tag1,tag2,time);
            }      
        }
    }  
}
