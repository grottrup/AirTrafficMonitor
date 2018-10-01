using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Observer;
using AirTrafficMonitor.Observer.AntiCorruptionLayer;
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

            container.Register<IObservable<AirTraffic>,AirTrafficSubject>();
            container.Register<IObserver<AirTraffic>, AirTrafficObserver>();

            container.Register<IRawDataController, RawDataController>();

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
