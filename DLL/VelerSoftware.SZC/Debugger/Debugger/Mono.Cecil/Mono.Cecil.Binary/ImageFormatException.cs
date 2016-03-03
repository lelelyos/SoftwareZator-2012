// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

namespace VelerSoftware.SZC.Debugger.Debugger.Mono.Cecil.Binary
{
    using System;

    public class ImageFormatException : Exception
    {
        internal ImageFormatException()
            : base()
        {
        }

        internal ImageFormatException(string message)
            : base(message)
        {
        }

        internal ImageFormatException(string message, params string[] parameters) :
            base(string.Format(message, parameters))
        {
        }

        internal ImageFormatException(string message, Exception inner) :
            base(message, inner)
        {
        }
    }
}