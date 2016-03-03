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
    public class ModuleCollection : CollectionWithEvents<Module>
    {
        public ModuleCollection(NDebugger debugger) : base(debugger) { }

        int lastAssignedModuleOrderOfLoading = 0;

        public Module this[string filename]
        {
            get
            {
                foreach (Module module in this)
                {
                    if (module.Name == filename)
                    {
                        return module;
                    }
                }
                throw new DebuggerException("Module \"" + filename + "\" is not in collection");
            }
        }

        internal Module this[ICorDebugModule corModule]
        {
            get
            {
                foreach (Module module in this)
                {
                    if (module.CorModule == corModule)
                    {
                        return module;
                    }
                }
                throw new DebuggerException("Module is not in collection");
            }
        }

        protected override void OnAdded(Module module)
        {
            module.OrderOfLoading = lastAssignedModuleOrderOfLoading;
            lastAssignedModuleOrderOfLoading++;
            base.OnAdded(module);
        }

        protected override void OnRemoved(Module module)
        {
            base.OnRemoved(module);
            module.Dispose();
        }
    }
}