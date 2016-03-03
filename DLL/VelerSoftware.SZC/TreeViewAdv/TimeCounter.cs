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
using System.Runtime.InteropServices;

namespace VelerSoftware.SZC.TreeViewAdv
{
    /// <summary>
    /// High resolution timer, used to test performance
    /// </summary>
    public static class TimeCounter
    {
        private static Int64 _start;

        /// <summary>
        /// Start time counting
        /// </summary>
        public static void Start()
        {
            _start = 0;
            QueryPerformanceCounter(ref _start);
        }

        public static Int64 GetStartValue()
        {
            Int64 t = 0;
            QueryPerformanceCounter(ref t);
            return t;
        }

        /// <summary>
        /// Finish time counting
        /// </summary>
        /// <returns>time in seconds elapsed from Start till Finish	</returns>
        public static double Finish()
        {
            return Finish(_start);
        }

        public static double Finish(Int64 start)
        {
            Int64 finish = 0;
            QueryPerformanceCounter(ref finish);

            Int64 freq = 0;
            QueryPerformanceFrequency(ref freq);
            return (finish - start) / (double)freq;
        }

        [DllImport("Kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool QueryPerformanceCounter(ref Int64 performanceCount);

        [DllImport("Kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool QueryPerformanceFrequency(ref Int64 frequency);
    }
}