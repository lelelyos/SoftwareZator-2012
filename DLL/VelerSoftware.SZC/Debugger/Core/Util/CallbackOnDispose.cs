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
using System.Threading;

namespace VelerSoftware.SZC.Debugger.Core
{
    /// <summary>
    /// Invokes a callback when this class is disposed.
    /// </summary>
    public sealed class CallbackOnDispose : IDisposable
    {
        Action callback;

        public CallbackOnDispose(Action callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");
            this.callback = callback;
        }

        public void Dispose()
        {
            Action action = Interlocked.Exchange(ref callback, null);
            if (action != null)
            {
                action();
#if DEBUG
                GC.SuppressFinalize(this);
#endif
            }
        }

#if DEBUG

        ~CallbackOnDispose()
        {
            //Debug.Fail("CallbackOnDispose was finalized without being disposed.");
        }

#endif
    }
}