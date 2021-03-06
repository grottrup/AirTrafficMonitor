﻿using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Utilities;
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
            
            // Root
            base.AddClass<FlightObserver>();
            
            // Infrastructure
            base.AddClass<SeparationHandler>();
            base.AddClass<Logger>();
            base.AddClass<ConsoleView>();
            base.AddClass<AirspaceEventHandler>();
            
            // Domain
            base.AddClass<Position>();
            base.AddClass<Airspace>();
            base.AddClass<FlightTrack>();
            base.AddClass<FlightRecord>();
            base.AddClass<FlightRecordFactory>();

            // Util
            base.AddClass<StringEventTimer>();

            // ACL
            base.AddClass<FlightRecordEventArgs>();
            base.AddClass<FlightRecordFactory>();
            base.AddClass<FlightRecordReceiver>();
        }
    }
}
