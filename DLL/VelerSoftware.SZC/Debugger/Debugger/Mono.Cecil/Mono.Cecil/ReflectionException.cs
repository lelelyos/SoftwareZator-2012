// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

namespace VelerSoftware.SZC.Debugger.Debugger.Mono.Cecil
{
    using System;

    using VelerSoftware.SZC.Debugger.Debugger.Mono.Cecil.Metadata;

    public sealed class ReflectionException : MetadataFormatException
    {
        internal ReflectionException()
            : base()
        {
        }

        internal ReflectionException(string message)
            : base(message)
        {
        }

        internal ReflectionException(string message, params string[] parameters) :
            base(string.Format(message, parameters))
        {
        }

        internal ReflectionException(string message, Exception inner) :
            base(message, inner)
        {
        }
    }
}