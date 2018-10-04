using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Observer;
using AirTrafficMonitor.View;
using DependencyInjection;
using System.IO;

namespace AirTrafficMonitor
{
   public class Logger : ILogger
    //internal class Logger
    {
        public void DataLog(object test, FlightInCollision eventArgs)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "DataLog.txt",
                "Warning, two planes are currently on collision course! " +
                "\n Plane Tag: " + eventArgs.Tag1 + " and plane Tag: " + eventArgs.Tag2 + "\n Current time: " +
                eventArgs.TimeStamp);
            /*File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "DataLog.txt",
                "Warning, two planes are currently on collision course! " +
                "\n Plane Tag: " + eventArgs.Tag1 + " and plane Tag: " + eventArgs.Tag2 + "\n Current time: " +
                eventArgs.TimeStamp);*/
        }
        
        
        /*public void DataLog(string Tag1, string Tag2, DateTime Time)
        {
            //Måske .AppendAllText i stedet. AppDomain.CurrentDomain.BaseDirectory placerer log filen samme sted som applicationen
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "DataLog.txt",
                "Warning, two planes are currently on collusion course! " +
                "\n Plane Tag: " + Tag1 + "and tag: " + Tag2 + "\n Current time: " +
                Time);
        }

        //public void ConsoleLog(string Tag1, string Tag2, DateTime Time)
        {
            Console.WriteLine("Warning, two planes are currently on collusion course! " +
            "\n Plane Tag: " + Tag1 + "and tag: " + Tag2 + "\n Current time: " +
                Time);
            Console.ReadLine();
        }*/
    }
}


/*private string _data;


public Logger(string data)

{
   _data = //Tag1, Tag2 og TimeOfOccurence her
       
    File.AppendAllText("DataLog.txt", _data);
    
  

    Console.WriteLine(displayMessage);
    Console.ReadLine();
}
}
}

Log to file
Log to Console*/

