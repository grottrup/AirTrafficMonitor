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

            Console.ReadKey();

        }
    }
}
