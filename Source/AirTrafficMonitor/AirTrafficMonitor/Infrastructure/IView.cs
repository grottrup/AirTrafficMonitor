
using System;
using System.Timers;
using AirTrafficMonitor.Domain;
 using System.Collections.Generic;


namespace AirTrafficMonitor.Infrastructure
{
    public interface IView
    {
        void AddToRenderWithColor(string toRender, ConsoleColor color);

        void RemoveFromRender(string preciseStringToRemove);
    }
}