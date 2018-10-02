using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class SeparationHandler : Observer.IObserver<AirTrafficRecord>
    {
        public event EventHandler SeparationEvent;

        public int VertDist = 300;
        public int HoriDist = 5000;
        
        //public SubscribePls = new AirTrafficMonitor.Observer;
        public void Update(AirTrafficRecord update)
        {
            update.Altitude;
        }
    }
}
