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
        private readonly string _path;

        public Logger(string fileName = "DataLog.txt")
        {
            _path = Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), fileName);
        }
 
        public void DataLog(string loggingStr)
        {
            if (!File.Exists(_path))
            {
                var DL = File.CreateText(_path);
                DL.Close();
            }

            using (var DL = File.AppendText(_path))
            {
                DL.WriteLine(loggingStr);
            }      
        }
    }  
}
