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
using VelerSoftware.SZC.Debugger.Debugger.Interop.CorDebug;

namespace VelerSoftware.SZC.Debugger.Debugger
{
    public class BreakpointCollection : CollectionWithEvents<Breakpoint>
    {
        public event EventHandler<CollectionItemEventArgs<Breakpoint>> Hit;

        protected internal void OnHit(Breakpoint item)
        {
            if (Hit != null)
            {
                Hit(this, new CollectionItemEventArgs<Breakpoint>(item));
            }
        }

        public BreakpointCollection(NDebugger debugger) : base(debugger) { }

        internal Breakpoint this[ICorDebugBreakpoint corBreakpoint]
        {
            get
            {
                foreach (Breakpoint breakpoint in this)
                {
                    if (breakpoint.IsOwnerOf(corBreakpoint))
                    {
                        return breakpoint;
                    }
                }
                return null;
            }
        }

        public new void Add(Breakpoint breakpoint)
        {
            base.Add(breakpoint);
        }

        public new void Clear()
        {
            base.Clear();
        }

        public Breakpoint Add(string filename, int line)
        {
            Breakpoint breakpoint = new Breakpoint("", filename, "", "", "", line, true, "", null, this.Debugger);
            Add(breakpoint);
            return breakpoint;
        }

        public Breakpoint Add(string fileName, byte[] checkSum, int line, int column, bool enabled)
        {
            Breakpoint breakpoint = new Breakpoint("", fileName, "", "", "", line, enabled, "", null, this.Debugger);
            Add(breakpoint);
            return breakpoint;
        }

        protected override void OnAdded(Breakpoint breakpoint)
        {
            foreach (Process process in this.Debugger.Processes)
            {
                foreach (Module module in process.Modules)
                {
                    breakpoint.SetBreakpoint(module);
                }
            }

            base.OnAdded(breakpoint);
        }

        public new void Remove(Breakpoint breakpoint)
        {
            base.Remove(breakpoint);
        }

        protected override void OnRemoved(Breakpoint breakpoint)
        {
            breakpoint.Deactivate();

            base.OnRemoved(breakpoint);
        }

        internal void SetInModule(Module module)
        {
            // This is in case that the client modifies the collection as a response to set breakpoint
            // NB: If client adds new breakpoint, it will be set directly as a result of his call, not here (because module is already loaded)
            List<Breakpoint> collection = new List<Breakpoint>();
            collection.AddRange(this);

            foreach (Breakpoint b in collection)
            {
                b.SetBreakpoint(module);
            }
        }
    }
}