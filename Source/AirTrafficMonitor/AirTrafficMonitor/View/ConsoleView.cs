using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.View
{
    public class ConsoleView : IView
    {
        public void Render(AirTrafficRecord record)
        {
            Console.WriteLine(record.RawData);
        }
    }
}
