using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    using System;

    namespace AirTrafficMonitor
    {
        public class TransponderReceiverData : IObservable<string>
        {
            public IDisposable Subscribe(IObserver<string> observer)
            {
                throw new NotImplementedException();
            }
        }
    }
}
