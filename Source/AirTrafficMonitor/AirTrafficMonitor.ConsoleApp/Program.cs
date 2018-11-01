using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Observer;
using AirTrafficMonitor.View;
using Container = DependencyInjection.Container;

namespace AirTrafficMonitor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var container = new Container();
            //container.Configure();
            //var observer = container.Resolve<IFlightObserver<FlightRecord>>();

            IFlightRecordReceiver recordReceiver = new FlightRecordReceiver();
            IView view = new ConsoleView();
            ISeperationHandler handler = new SeparationHandler();
            IFlightObserver observer = new FlightObserver(recordReceiver, view, handler);

            Console.ReadKey();

        }
    }
}
