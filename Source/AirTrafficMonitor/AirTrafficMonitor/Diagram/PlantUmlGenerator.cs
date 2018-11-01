using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Util;
using AirTrafficMonitor.View;
using NPlant;

namespace AirTrafficMonitor.Diagram
{
    public class PlantUmlGenerator : ClassDiagram
    {
        public PlantUmlGenerator()
        {
            //container.Register<ILogger, Logger>();
            //container.Register<IFlightRecordReceiver, FlightRecordReceiver>();
            //container.Register<Observer.IFlightObserver, FlightObserver>();
            //container.Register<IView, ConsoleView>();
            //container.Register<ISeperationHandler, SeparationHandler>();
            //container.Register<FlightInCollision, FlightInCollision>();
            this.GenerationOptions.ShowMethods();

            base.AddClass<Position>();
            base.AddClass<Airspace>();
            base.AddClass<FlightTrack>();
            base.AddClass<FlightRecord>();

            base.AddClass<FlightRecordFactory>();

            //Anti
            base.AddClass<FlightRecordEventArgs>();
            base.AddClass<FlightRecordFactory>();

            //Infra
            base.AddClass<FlightObserver>();
            base.AddClass<FlightInCollision>();
            base.AddClass<SeparationHandler>();
            base.AddClass<Logger>();

            //View
            base.AddClass<ConsoleView>();

        }

    }
}
