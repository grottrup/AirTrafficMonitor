using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Util;
using NPlant;

namespace AirTrafficMonitor.Diagram
{
    public class PlantUmlGenerator : ClassDiagram
    {
        public PlantUmlGenerator()
        {
            this.GenerationOptions.ShowMethods();
            this.GenerationOptions.ShowMembers();
            base.Named("class AirTrafficMonitor");

            // Domain
            base.AddClass<Position>();
            base.AddClass<Airspace>();
            base.AddClass<FlightTrack>();
            base.AddClass<FlightRecord>();
            base.AddClass<FlightInCollision>();
            base.AddClass<FlightRecordFactory>();

            // ACL
            base.AddClass<FlightRecordEventArgs>();
            base.AddClass<FlightRecordFactory>();

            // Infrastructure
            base.AddClass<FlightObserver>();
            base.AddClass<SeparationHandler>();
            base.AddClass<Logger>();
            base.AddClass<ConsoleView>();
        }
    }
}
