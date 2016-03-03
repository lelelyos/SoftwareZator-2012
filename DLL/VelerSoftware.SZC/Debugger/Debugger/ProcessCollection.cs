// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using VelerSoftware.SZC.Debugger.Debugger.Interop.CorDebug;

namespace VelerSoftware.SZC.Debugger.Debugger
{
    public class ProcessCollection : CollectionWithEvents<Process>
    {
        public ProcessCollection(NDebugger debugger) : base(debugger) { }

        internal Process this[ICorDebugProcess corProcess]
        {
            get
            {
                foreach (Process process in this)
                {
                    if (process.CorProcess == corProcess)
                    {
                        return process;
                    }
                }
                return null;
            }
        }

        protected override void OnRemoved(Process item)
        {
            base.OnRemoved(item);

            if (this.Count == 0)
            {
                // Exit callback and then terminate the debugger
                this.Debugger.MTA2STA.AsyncCall(delegate { this.Debugger.TerminateDebugger(); });
            }
        }
    }
}