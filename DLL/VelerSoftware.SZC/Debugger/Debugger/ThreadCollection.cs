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
    public class ThreadCollection : CollectionWithEvents<Thread>
    {
        public ThreadCollection(NDebugger debugger) : base(debugger) { }

        Thread selected;

        public Thread Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        internal bool Contains(ICorDebugThread corThread)
        {
            foreach (Thread thread in this)
            {
                if (thread.CorThread == corThread) return true;
            }
            return false;
        }

        internal Thread this[ICorDebugThread corThread]
        {
            get
            {
                foreach (Thread thread in this)
                {
                    if (thread.CorThread == corThread)
                    {
                        return thread;
                    }
                }
                throw new DebuggerException("Thread is not in collection");
            }
        }
    }
}