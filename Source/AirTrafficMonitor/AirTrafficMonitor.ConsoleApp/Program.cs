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
            var observer = new AirTrafficObserver(new ConsoleView());
            subject.Subscribe(observer);
            Console.ReadKey();
        }
    }
}
