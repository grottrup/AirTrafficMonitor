using System;

namespace AirTrafficMonitor.Utilities
{
    public class ElapsedEventArgsWithString : EventArgs

    {
        public string StringToHandle { get; private set; }

        public ElapsedEventArgsWithString(string stringToHandle)
        {
            StringToHandle = stringToHandle;
        }
    }
}