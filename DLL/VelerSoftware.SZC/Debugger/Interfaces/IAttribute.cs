// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System.Collections.Generic;

namespace VelerSoftware.SZC.Debugger.Interfaces
{
    public interface IAttribute : IFreezable
    {
        /// <summary>
        /// Gets the compilation unit in which this attribute is defined.
        /// </summary>
        ICompilationUnit CompilationUnit
        {
            get;
        }

        /// <summary>
        /// Gets the code region of this attribute.
        /// </summary>
        DomRegion Region
        {
            get;
        }

        AttributeTarget AttributeTarget
        {
            get;
        }

        IReturnType AttributeType
        {
            get;
        }

        IList<object> PositionalArguments
        {
            get;
        }

        IDictionary<string, object> NamedArguments
        {
            get;
        }
    }

    public enum AttributeTarget
    {
        None,
        Assembly,
        Field,
        Event,
        Method,
        Module,
        Param,
        Property,
        Return,
        Type
    }
}