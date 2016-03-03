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

namespace VelerSoftware.SZC.Debugger.Core
{
    /// <summary>
    /// Base class for exceptions thrown by the SharpDevelop core.
    /// </summary>
    [Serializable()]
    public class CoreException : Exception
    {
        public CoreException()
            : base()
        {
        }

        public CoreException(string message)
            : base(message)
        {
        }

        public CoreException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CoreException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}