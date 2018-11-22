using AirTrafficMonitor.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;
using AirTrafficMonitor.Utilities;

namespace AirTrafficMonitor.Infrastructure
{
    public class ConsoleView : IView
    {
        public ICollection<Tuple<string, ConsoleColor>> ThingsToRender { get; }
        private IConsole _console;

        public ConsoleView(IConsole console)
        {
            _console = console;
            ThingsToRender = new List<Tuple<string, ConsoleColor>>();
        }

        public void AddToRenderWithColor(string toRender, ConsoleColor color)
        {
            lock (ThingsToRender)
            {
                ThingsToRender.Add(new Tuple<string, ConsoleColor>(toRender, color));
            }
            RenderWithColor(color);
        }

        private void RenderWithColor(ConsoleColor color)
        {
            _console.Clear();
            lock (ThingsToRender)
            {
                foreach (var renderThis in ThingsToRender)
                {
                    Console.WriteLine(renderThis.Item1, Console.ForegroundColor = renderThis.Item2);
                }
            }
        }

        public void RemoveFromRender(string preciseStringToRemove)
        {
            lock (ThingsToRender)
            {
                foreach (var renderThis in ThingsToRender)
                {
                    if (renderThis.Item1.Equals(preciseStringToRemove))
                    {
                        ThingsToRender.Remove(renderThis);
                        break;
                    }
                }
            }
            RenderWithColor(ConsoleColor.Gray);
        }
    }
}
