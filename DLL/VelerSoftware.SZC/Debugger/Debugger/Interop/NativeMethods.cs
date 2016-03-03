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
using System.Runtime.InteropServices;
using System.Text;

namespace VelerSoftware.SZC.Debugger.Debugger.Interop
{
    public static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("mscoree.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        public static extern Debugger.Interop.CorDebug.ICorDebug CreateDebuggingInterfaceFromVersion(int debuggerVersion, string debuggeeVersion);

        [DllImport("mscoree.dll", CharSet = CharSet.Unicode)]
        public static extern int GetCORVersion([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName, Int32 cchBuffer, out Int32 dwLength);

        [DllImport("mscoree.dll", CharSet = CharSet.Unicode)]
        public static extern int GetRequestedRuntimeVersion(string exeFilename, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pVersion, Int32 cchBuffer, out Int32 dwLength);
    }
}

#pragma warning restore 1591