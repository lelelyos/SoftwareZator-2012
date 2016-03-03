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
using System.Runtime.Serialization;

namespace VelerSoftware.SZC.Debugger.Base.Util
{
    /// <summary>
    /// An exception thrown by a <see cref="ProcessRunner"/>
    /// instance.
    /// </summary>
    [Serializable()]
    public class ProcessRunnerException : ApplicationException
    {
        public ProcessRunnerException()
            : base()
        {
        }

        public ProcessRunnerException(string message)
            : base(message)
        {
        }

        public ProcessRunnerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ProcessRunnerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}