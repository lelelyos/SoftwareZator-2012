// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************


namespace VelerSoftware.SZC.Debugger.Debugger.Mono.Cecil.Metadata
{
    using System;

    using VelerSoftware.SZC.Debugger.Debugger.Mono.Cecil.Binary;

    public class MetadataFormatException : ImageFormatException
    {
        internal MetadataFormatException()
            : base()
        {
        }

        internal MetadataFormatException(string message)
            : base(message)
        {
        }

        internal MetadataFormatException(string message, params string[] parameters) :
            base(string.Format(message, parameters))
        {
        }

        internal MetadataFormatException(string message, Exception inner) :
            base(message, inner)
        {
        }
    }
}