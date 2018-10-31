using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Observer;
using AirTrafficMonitor.View;
using DependencyInjection;
using Serilog;

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

            container.Register<IFlightRecordReceiver, FlightRecordReceiver>();
            container.Register<Observer.IFlightObserver, FlightObserver>();
            container.Register<IView, ConsoleView>();
            container.Register<ISeperationHandler, SeparationHandler>();
            container.Register<FlightInCollision, FlightInCollision>();

            return container;
        }

    }
}
