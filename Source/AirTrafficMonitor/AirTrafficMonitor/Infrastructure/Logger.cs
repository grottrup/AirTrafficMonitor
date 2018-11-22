using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using System;
using System.IO;
using System.Reflection;
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
        
        public void DataLog(Tuple<IFlightTrack, IFlightTrack> flightsInCollision)
        {
            string flight1Tag = flightsInCollision.Item1.Tag;
            DateTime flight1Time = flightsInCollision.Item1.LatestTime;
            double flight1Nav = flightsInCollision.Item1.NavigationCourse;
            int flight1Lat = flightsInCollision.Item1.Position.Latitude;
            int flight1Lon = flightsInCollision.Item1.Position.Longitude;
            int flight1Alt = flightsInCollision.Item1.Position.Altitude;
            
            string flight2Tag = flightsInCollision.Item2.Tag;
            DateTime flight2Time = flightsInCollision.Item1.LatestTime;
            double flight2Nav = flightsInCollision.Item2.NavigationCourse;
            int flight2Lat = flightsInCollision.Item2.Position.Latitude;
            int flight2Lon = flightsInCollision.Item2.Position.Longitude;
            int flight2Alt = flightsInCollision.Item2.Position.Altitude;
            
            //string flight2 = flightsInCollision.ToString();
            //string flight2 = flightsInCollision.ToString();

            if (!File.Exists(Path))
            {
                var DL = File.CreateText(Path);
                DL.Close();
            }

            using (var DL = File.AppendText(Path))
            {
                //DL.WriteLine($"Warning, two planes are currently on collision course! \n Plane Tag: {flight1} and plane Tag: {flight2}\n");;
                DL.WriteLine($"Warning, two planes are currently on collision course! \n Plane nr. 1 Tag: {flight1Tag}, Time: {flight1Time}, NavigationCourse: {flight1Nav}, Latitude: {flight1Lat}, Longitude: {flight1Lon}, Altitude: {flight1Alt}]" +
                             $", and Plane nr. 2 Tag: {flight2Tag}, Time: {flight2Time}, NavigationCourse: {flight2Nav}, Latitude: {flight2Lat}, Longitude: {flight2Lon}, Altitude: {flight2Alt}");
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
