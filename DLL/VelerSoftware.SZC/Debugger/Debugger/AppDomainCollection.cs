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
    public class AppDomainCollection : CollectionWithEvents<AppDomain>
    {
        public AppDomainCollection(NDebugger dbgr) : base(dbgr) { }

        public AppDomain this[ICorDebugAppDomain corAppDomain]
        {
            get
            {
                foreach (AppDomain a in this)
                {
                    if (a.CorAppDomain.Equals(corAppDomain))
                    {
                        return a;
                    }
                }
                throw new DebuggerException("AppDomain not found");
            }
        }
    }
}