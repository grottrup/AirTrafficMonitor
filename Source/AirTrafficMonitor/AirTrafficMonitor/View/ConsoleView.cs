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
            Console.WriteLine(record.Tag);
            
        }

        public void ConsoleData(FlightInCollision eventArgs)
        {
            Console.WriteLine("Warning, two planes are currently on collision course! " +
                              "\n Plane Tag: " + eventArgs.Tag1 + " and plane Tag: " + eventArgs.Tag2 + "\n Current time: " +
                              eventArgs.TimeStamp);
        }
        
    }
}
