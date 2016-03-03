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
    /// Is thrown when the GlobalResource manager can't find a requested
    /// resource.
    /// </summary>
    [Serializable()]
    public class ResourceNotFoundException : CoreException
    {
        public ResourceNotFoundException(string resource)
            : base("Resource not found : " + resource)
        {
        }

        public ResourceNotFoundException()
            : base()
        {
        }

        public ResourceNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ResourceNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}