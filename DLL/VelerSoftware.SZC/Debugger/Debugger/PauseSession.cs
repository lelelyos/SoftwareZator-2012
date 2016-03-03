// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




namespace VelerSoftware.SZC.Debugger.Debugger
{
    /// <summary>
    /// Holds information about the state of paused debugger.
    /// Expires when when Continue is called on debugger.
    /// </summary>
    public class PauseSession : DebuggerObject
    {
        Process process;
        PausedReason pausedReason;

        public Process Process
        {
            get { return process; }
        }

        public PausedReason PausedReason
        {
            get { return pausedReason; }
        }

        public PauseSession(Process process, PausedReason pausedReason)
        {
            this.process = process;
            this.pausedReason = pausedReason;
        }
    }
}