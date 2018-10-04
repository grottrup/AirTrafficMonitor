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
            var container = new Container();
            container.Configure();
            var subject = container.Resolve<ISubject<FlightRecord>>();
            var observer = container.Resolve<Observer.IObserver<FlightRecord>>();

            subject.Subscribe(observer);
            //var subject = new FlightSubject();
            //var observerSep = new SeparationHandler();
            //var observerviiew = new FlightObserver(new ConsoleView(), new SeparationHandler());
            //subject.Subscribe(observerviiew);
            Console.ReadKey();

        }
    }
}
