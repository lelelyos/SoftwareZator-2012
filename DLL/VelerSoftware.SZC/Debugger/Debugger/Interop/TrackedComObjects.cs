// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace VelerSoftware.SZC.Debugger.Debugger.Interop
{
    public static class TrackedComObjects
    {
        static List<WeakReference> objects = new List<WeakReference>();

        public static void ProcessOutParameter(object parameter)
        {
            if (parameter != null)
            {
                if (Marshal.IsComObject(parameter))
                {
                    Track(parameter);
                }
                else if (parameter is Array)
                {
                    foreach (object elem in (Array)parameter)
                    {
                        ProcessOutParameter(elem);
                    }
                }
            }
        }

        public static void Track(object obj)
        {
            if (Marshal.IsComObject(obj))
            {
                lock (objects)
                {
                    objects.Add(new WeakReference(obj));
                }
            }
        }

        public static int ReleaseAll()
        {
            lock (objects)
            {
                int count = 0;
                foreach (WeakReference weakRef in objects)
                {
                    object obj = weakRef.Target;
                    if (obj != null)
                    {
                        Marshal.FinalReleaseComObject(obj);
                        count++;
                    }
                }
                objects.Clear();
                objects.TrimExcess();
                return count;
            }
        }
    }
}

#pragma warning restore 1591