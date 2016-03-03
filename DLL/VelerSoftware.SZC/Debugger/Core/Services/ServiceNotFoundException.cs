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
    /// Is thrown when the ServiceManager cannot find a required service.
    /// </summary>
    [Serializable()]
    public class ServiceNotFoundException : CoreException
    {
        public ServiceNotFoundException()
            : base()
        {
        }

        public ServiceNotFoundException(Type serviceType)
            : base("Required service not found: " + serviceType.FullName)
        {
        }

        public ServiceNotFoundException(string message)
            : base(message)
        {
        }

        public ServiceNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ServiceNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}