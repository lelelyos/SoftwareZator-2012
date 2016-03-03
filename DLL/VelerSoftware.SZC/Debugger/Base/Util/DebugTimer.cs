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
using System.Collections.Generic;
using System.Diagnostics;

using VelerSoftware.SZC.Debugger.Core;

namespace VelerSoftware.SZC.Debugger.Base
{
    /// <summary>
    /// Provides static helpers methods that measure time from
    /// Start() to Stop() and output the timespan to the logging service.
    /// Calls to DebugTimer are only compiled in debug builds.
    /// [Conditional("DEBUG")]
    /// </summary>
    public static class DebugTimer
    {
        [ThreadStatic]
        static Stack<Stopwatch> stopWatches;

        [Conditional("DEBUG")]
        public static void Start()
        {
            if (stopWatches == null)
            {
                stopWatches = new Stack<Stopwatch>();
            }
            stopWatches.Push(Stopwatch.StartNew());
        }

        [Conditional("DEBUG")]
        public static void Stop(string desc)
        {
            Stopwatch watch = stopWatches.Pop();
            watch.Stop();
            LoggingService.Debug("\"" + desc + "\" took " + (watch.ElapsedMilliseconds) + " ms");
        }

        /// <summary>
        /// Starts a new stopwatch and stops it when the returned object is disposed.
        /// </summary>
        /// <returns>
        /// Returns disposable object that stops the timer (in debug builds); or null (in release builds).
        /// </returns>
        public static IDisposable Time(string text)
        {
#if DEBUG
			Stopwatch watch = Stopwatch.StartNew();
			return new CallbackOnDispose(
				delegate {
					watch.Stop();
					LoggingService.Debug("\"" + text + "\" took " + (watch.ElapsedMilliseconds) + " ms");
				}
			);
#else
            return null;
#endif
        }
    }
}