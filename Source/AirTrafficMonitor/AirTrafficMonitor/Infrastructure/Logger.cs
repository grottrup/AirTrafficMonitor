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
        
        public void DataLog(Tuple<FlightTrack, FlightTrack> flightsInCollision)
        {
            string flight1 = flightsInCollision.ToString();
            string flight2 = flightsInCollision.ToString();

            if (!File.Exists(Path))
            {
                var DL = File.CreateText(Path);
                DL.Close();
            }

            using (var DL = File.AppendText(Path))
            {
                DL.WriteLine($"Warning, two planes are currently on collision course! \n Plane Tag: {flight1} and plane Tag: {flight2}\n");;
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
