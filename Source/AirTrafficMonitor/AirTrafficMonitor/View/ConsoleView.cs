using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.View
{
    public class ConsoleView : IView
    {
        //Printer ALLE fly.
        public void Render(FlightRecord record)
        {
            //Console.WriteLine(record.Tag1, record.Tag2, record.TimeStamp);
            Console.WriteLine(FlightRecord.Tag);
            Console.WriteLine("Warning, two planes are currently on collision course! " +
                              "\n Plane Tag: " + record.Tag1 + " and plane Tag: " + record.Tag2 + "\n Current time: " +
                              record.TimeStamp);
        }

        public void ConsoleData(FlightInCollision eventArgs)
        {
            Console.WriteLine("Warning, two planes are currently on collision course! " +
                              "\n Plane Tag: " + record.Tag1 + " and plane Tag: " + record.Tag2 + "\n Current time: " +
                              record.TimeStamp);
        }
        
    }
}
