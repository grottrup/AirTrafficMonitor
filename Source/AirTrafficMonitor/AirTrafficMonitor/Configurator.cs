using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Observer;
using AirTrafficMonitor.View;
using DependencyInjection;

namespace AirTrafficMonitor
{
    /// <summary>
    /// This class is is static as its purpose is a specific injection of an IoC for the AirTrafficMonitor
    /// </summary>
    public static class Configurator
    {
        public static Container Configure(this Container container)
        {
            container.Register<ILogger, Logger>();

            container.Register<ISubject<AirTrafficReport>,AirTrafficSubject>();
            container.Register<IObserver<AirTrafficReport>, AirTrafficObserver>();

            container.Register<IView, ConsoleView>();

            return container;
        }

    }

    public class Logger : ILogger //replace with logging framework
    {
    }

    public interface ILogger //replace with logging framework
    {
    }

}
