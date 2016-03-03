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
    /// Represents span of time in which the debugger state is assumed to
    /// be unchanged.
    /// </summary>
    /// <remarks>
    /// For example, although property evaluation can in theory change
    /// any memory, it is assumed that they behave 'correctly' and thus
    /// property evaluation does not change debugger state.
    /// </remarks>
    public class DebuggeeState : DebuggerObject
    {
        Process process;

        public Process Process
        {
            get { return process; }
        }

        public DebuggeeState(Process process)
        {
            this.process = process;
        }
    }
}