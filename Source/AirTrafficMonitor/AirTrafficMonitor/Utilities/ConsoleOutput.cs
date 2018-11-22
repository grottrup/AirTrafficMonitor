using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Utilities // Should be moved to unit test project wtf
{
    //Source: https://www.codeproject.com/Articles/501610/Getting-Console-Output-Within-A-Unit-Test
    public class ConsoleOutput : IDisposable
    {
        private static StringWriter stringWriter;
        private TextWriter originalOutput;

        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public static string GetOutput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}
