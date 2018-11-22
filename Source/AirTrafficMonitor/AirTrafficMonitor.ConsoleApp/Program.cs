using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Utilities;
using TransponderReceiver;

namespace AirTrafficMonitor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IFlightRecordFactory factory = new FlightRecordFactory();
            IFlightRecordReceiver recordReceiver = new FlightRecordReceiver(TransponderReceiverFactory.CreateTransponderDataReceiver(), factory);
            IView view = new ConsoleView(new CustomConsole());
            ILogger logger = new Logger();
            ISeperationHandler handler = new SeparationHandler(logger);
            IAirspace monitoredAirspace = new Airspace(90000, 10000, 20000, 500);
            FlightObserver flightObserver = new FlightObserver(monitoredAirspace, recordReceiver, view, handler, logger);
            AirspaceEventHandler airspaceEventHandler = new AirspaceEventHandler(flightObserver, view);
            Console.ReadKey();
        }
    }
}
