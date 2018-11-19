using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Utilities;


namespace AirTrafficMonitor
{
    public class AirspaceEventHandler
    {
        private ITimer atimer = new EventTimer();
        private List<FlightRecord> records = new List<FlightRecord>();
        private Airspace _monitoredAirspace = new Airspace();

        private async Task PutTaskDelay() //bruges ikke lige nu 
        {
            await Task.Delay(5000);
        }
        public async void AirspaceEvent(object sender, FlightRecordEventArgs e)
        {
            var flightUpdate = e.FlightRecord;
            records.Add(flightUpdate);
            if (records.Count <= 1 && flightUpdate.Position.IsWithin(_monitoredAirspace))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Flight {0} entered airspace at {1}", flightUpdate.Tag, flightUpdate.Timestamp);

                atimer.WaitTimer();
                //await PutTaskDelay();
              
                Console.ResetColor();


            }

            for (int i = 0; i < records.Count - 1; i++)
            {
                if (flightUpdate.Tag == records[i].Tag && !flightUpdate.Position.IsWithin(_monitoredAirspace))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Flight {0} left airspace at {1}", flightUpdate.Tag, flightUpdate.Timestamp);
                    records.RemoveAt(i);
                    records.Remove(flightUpdate);

                    atimer.WaitTimer();
                   // await PutTaskDelay();
                   
                    Console.ResetColor();
                }
                else if (flightUpdate.Tag != records[i].Tag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Flight {0} entered airspace at {1}", flightUpdate.Tag,
                        flightUpdate.Timestamp);

                    atimer.WaitTimer();
                    //await PutTaskDelay();

                    Console.ResetColor();
                }

            }
        }
    }
}