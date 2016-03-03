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

namespace VelerSoftware.SZC.Debugger.Debugger
{
    [Serializable]
    public class ProcessEventArgs : DebuggerEventArgs
    {
        Process process;

        public Process Process
        {
            get { return process; }
        }

        public ProcessEventArgs(Process process)
            : base(process == null ? null : process.Debugger)
        {
            this.process = process;
        }
    }
}