// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using System.Threading;

namespace VelerSoftware.SZC.TreeViewAdv.Threading
{
    public sealed class WorkItem
    {
        private WaitCallback _callback;
        private object _state;
        private ExecutionContext _ctx;

        internal WorkItem(WaitCallback wc, object state, ExecutionContext ctx)
        {
            _callback = wc;
            _state = state;
            _ctx = ctx;
        }

        internal WaitCallback Callback
        {
            get
            {
                return _callback;
            }
        }

        internal object State
        {
            get
            {
                return _state;
            }
        }

        internal ExecutionContext Context
        {
            get
            {
                return _ctx;
            }
        }
    }
}