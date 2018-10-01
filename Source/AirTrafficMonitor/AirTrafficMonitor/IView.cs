using System;

namespace AirTrafficMonitor
{
    public interface IView
    {
        void Display(AirTrafficReport report);
    }

    public class FakeView : IView
    {
        public void Display(AirTrafficReport report)
        {
            Console.Write(report.RawData);
        }
    }
}