// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System.Collections.Generic;
using VelerSoftware.SZC.Debugger.Debugger.Interop.CorDebug;
using VelerSoftware.SZC.Debugger.Debugger.MetaData;

namespace VelerSoftware.SZC.Debugger.Debugger
{
    public class AppDomain : DebuggerObject
    {
        Process process;

        ICorDebugAppDomain corAppDomain;

        internal Dictionary<ICorDebugType, DebugType> DebugTypeCache = new Dictionary<ICorDebugType, DebugType>();

        public Process Process
        {
            get { return process; }
        }

        public uint ID
        {
            get
            {
                return corAppDomain.GetID();
            }
        }

        Module mscorlib;

        public Module Mscorlib
        {
            get
            {
                if (mscorlib != null) return mscorlib;
                foreach (Module m in Process.Modules)
                {
                    if (m.Name == "mscorlib.dll" &&
                        m.AppDomain == this)
                    {
                        mscorlib = m;
                        return mscorlib;
                    }
                }
                throw new DebuggerException("Mscorlib not loaded");
            }
        }

        internal DebugType ObjectType
        {
            get { return DebugType.CreateFromType(this.Mscorlib, typeof(object)); }
        }

        internal ICorDebugAppDomain CorAppDomain
        {
            get { return corAppDomain; }
        }

        internal ICorDebugAppDomain2 CorAppDomain2
        {
            get { return (ICorDebugAppDomain2)corAppDomain; }
        }

        public AppDomain(Process process, ICorDebugAppDomain corAppDomain)
        {
            this.process = process;
            this.corAppDomain = corAppDomain;
        }
    }
}