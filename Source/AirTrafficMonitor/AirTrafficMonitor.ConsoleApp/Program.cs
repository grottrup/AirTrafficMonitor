using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Observer;
using AirTrafficMonitor.View;
using Container = DependencyInjection.Container;

namespace AirTrafficMonitor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new AirTrafficSubject();
            var observerSep = new SeparationHandler();
            var observerviiew = new FlightObserver(new ConsoleView());
            subject.Subscribe(observerSep);
            subject.Subscribe(observerviiew);
            Console.ReadKey();

        }
    }
}
