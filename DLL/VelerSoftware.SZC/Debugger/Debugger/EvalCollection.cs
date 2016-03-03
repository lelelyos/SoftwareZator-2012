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
    public class EvalCollection : CollectionWithEvents<Eval>
    {
        public EvalCollection(NDebugger debugger) : base(debugger) { }

        internal Eval this[ICorDebugEval corEval]
        {
            get
            {
                foreach (Eval eval in this)
                {
                    if (eval.IsCorEval(corEval))
                    {
                        return eval;
                    }
                }
                throw new DebuggerException("Eval not found for given ICorDebugEval");
            }
        }
    }
}