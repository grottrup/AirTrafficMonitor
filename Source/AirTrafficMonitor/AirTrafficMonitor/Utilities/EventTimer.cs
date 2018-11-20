using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace AirTrafficMonitor.Utilities
{
    //public class TimerState
    //{
    //    public Timer timer;
    //}

    public class EventTimer: Timer, ITimer
    {

        //TimerState state = new TimerState();

        //    lock (state)
        //{
        //    state.Timer = new Timer((callbackState) => {
        //        action();
        //        lock (callbackState) { callbackState.Timer.Dispose(); }
        //    }, state, millisecond, -1);
        //}
    //public bool Flag { get; set; }
    //public void WaitTimer()
    //{
    //    Flag = false;
    //    var timer = new System.Timers.Timer(5000);
    //    timer.Elapsed += (src, args) => { Flag = true; };
    //    timer.AutoReset = false;
    //    timer.Start();
    //}

    //public event ElapsedEventHandler Elapsed;
    //public double Interval { get; set; }
    //public void Dispose()
    //{
    //    throw new NotImplementedException();
    //}
    //class OneTimer
    //{
    // Created by Roy Feintuch 2009
    // Basically we wrap a timer object in order to send itself as a context in order to dispose it after the cb invocation finished. This solves the problem of timer being GCed because going out of context
    //    public static void DoOneTime(ThreadStart cb, TimeSpan dueTime)
    //    {
    //        var td = new TimerDisposer();
    //        var timer = new Timer(myTdToKill =>
    //            {
    //                try
    //                {
    //                    cb();
    //                }
    //                catch (Exception ex)
    //                {
    //                    Trace.WriteLine(string.Format("[DoOneTime] Error occured while invoking delegate. {0}", ex), "[OneTimer]");
    //                }
    //                finally
    //                {
    //                    ((TimerDisposer)myTdToKill).InternalTimer.Dispose();
    //                }
    //            },
    //            td, dueTime, TimeSpan.FromMilliseconds(-1));

    //        td.InternalTimer = timer;
    //    }
    //}

    //class TimerDisposer
    //{
    //    public Timer InternalTimer { get; set; }
    //}
}
}
