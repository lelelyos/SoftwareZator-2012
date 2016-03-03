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
    /// Exception used when loading an AddIn fails.
    /// </summary>
    [Serializable]
    public class AddInLoadException : CoreException
    {
        public AddInLoadException()
            : base()
        {
        }

        public AddInLoadException(string message)
            : base(message)
        {
        }

        public AddInLoadException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected AddInLoadException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}