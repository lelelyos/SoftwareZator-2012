// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System;
using System.Diagnostics;
using System.Windows.Threading;
using VelerSoftware.SZC.Debugger.Core;
using VelerSoftware.SZC.Debugger.Debugger;

namespace VelerSoftware.SZC.Debugger.TreeModel
{
    public static partial class Utils
    {
        /// <param name="process">Process on which to track debuggee state</param>
        public static void DoEvents(VelerSoftware.SZC.Debugger.Debugger.Process process)
        {
            if (process == null) return;
            DebuggeeState oldState = process.DebuggeeState;
            WpfDoEvents();
            DebuggeeState newState = process.DebuggeeState;
            if (oldState != newState)
            {
                LoggingService.Info("Aborted because debuggee resumed");
                throw new AbortedBecauseDebuggeeResumedException();
            }
        }

        public static void WpfDoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => frame.Continue = false));
            Dispatcher.PushFrame(frame);
        }
    }

    public class AbortedBecauseDebuggeeResumedException : System.Exception
    {
        public AbortedBecauseDebuggeeResumedException()
            : base()
        {
        }
    }

    public class PrintTimes : PrintTime
    {
        public PrintTimes(string text)
            : base(text + " - end")
        {
            LoggingService.InfoFormatted("{0} - start", text);
        }
    }

    public class PrintTime : IDisposable
    {
        string text;
        Stopwatch stopwatch = new Stopwatch();

        public PrintTime(string text)
        {
            this.text = text;
            stopwatch.Start();
        }

        public void Dispose()
        {
            stopwatch.Stop();
            LoggingService.InfoFormatted("{0} ({1} ms)", text, stopwatch.ElapsedMilliseconds);
        }
    }
}