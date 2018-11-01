using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;

namespace AirTrafficMonitor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IFlightRecordReceiver recordReceiver = new FlightRecordReceiver();
            IView view = new ConsoleView();
            ISeperationHandler handler = new SeparationHandler();
            Airspace monitoredAirspace = new Airspace();
            FlightObserver flightObserver = new FlightObserver(monitoredAirspace, recordReceiver, view, handler);

            Console.ReadKey();
        }
    }
}
