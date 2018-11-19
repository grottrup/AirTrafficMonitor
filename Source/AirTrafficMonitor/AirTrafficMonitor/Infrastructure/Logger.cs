using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using System;
using System.IO;
using System.Text;

namespace AirTrafficMonitor.Infrastructure
{
    public class Logger : ILogger
    {
        private string Path;

        public Logger(string path = @"DataLog.txt")
        {
            Path = path;
        }
        
        public void DataLog(FlightInCollision eventArgs)
        {
            string tag1 = eventArgs.Tag1;
            string tag2 = eventArgs.Tag2;
            DateTime time = eventArgs.TimeStamp;

            if (!File.Exists(Path))
            {
                var DL = File.CreateText(Path);
                DL.Close();
            }

            using (var DL = File.AppendText(Path))
            {
                DL.WriteLine("Warning, two planes are currently on collision course! " +
                             "\n Plane Tag: {0} and plane Tag: {1}\n Current time: {2}",tag1,tag2,time);
            }      
        }
        //Til test purpose:
        public void DataLog(string test)
        {
            if (!File.Exists(Path))
            {
                var DL = File.CreateText(Path);
                DL.Close();
            }

            using (var DL = File.AppendText(Path))
            {
                DL.WriteLine(test);
            }      
        }
    }  
}
