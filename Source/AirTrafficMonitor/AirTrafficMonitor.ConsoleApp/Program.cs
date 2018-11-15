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
            IFlightRecordFactory factory = new FlightRecordFactory();
            IFlightRecordReceiver recordReceiver = new FlightRecordReceiver(factory);
            IView view = new ConsoleView();
            ILogger logger = new Logger();
            ISeperationHandler handler = new SeparationHandler(logger);
            Airspace monitoredAirspace = new Airspace();
            FlightObserver flightObserver = new FlightObserver(monitoredAirspace, recordReceiver, view, handler, logger);

            Console.ReadKey();
        }
    }
}
