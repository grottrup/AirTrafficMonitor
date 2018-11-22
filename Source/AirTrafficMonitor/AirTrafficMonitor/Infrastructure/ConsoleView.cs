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
        private ICollection<Tuple<string, ConsoleColor>> _thingsToRender;
        private IConsole _console;

        public ConsoleView(IConsole console)
        {
            _console = console;
            _thingsToRender = new List<Tuple<string, ConsoleColor>>();
        }

        public void AddToRenderWithColor(string toRender, ConsoleColor color)
        {
            lock (_thingsToRender)
            {
                _thingsToRender.Add(new Tuple<string, ConsoleColor>(toRender, color));
            }
            RenderWithColor(color);
        }

        private void RenderWithColor(ConsoleColor color)
        {
            _console.Clear();
            lock (_thingsToRender)
            {
                foreach (var renderThis in _thingsToRender)
                {
                    Console.WriteLine(renderThis.Item1, Console.ForegroundColor = renderThis.Item2);
                }
            }
        }

        public void RemoveFromRender(string preciseStringToRemove)
        {
            lock (_thingsToRender)
            {
                foreach (var renderThis in _thingsToRender)
                {
                    if (renderThis.Item1.Equals(preciseStringToRemove))
                    {
                        _thingsToRender.Remove(renderThis);
                        break;
                    }
                }
            }
            RenderWithColor(ConsoleColor.Gray);
        }
    }
}
