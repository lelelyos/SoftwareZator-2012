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
using System.Collections.Generic;

namespace VelerSoftware.SZC.Debugger.Interfaces
{
    public interface IParameter : IFreezable, IComparable
    {
        string Name
        {
            get;
        }

        IReturnType ReturnType
        {
            get;
            set;
        }

        IList<IAttribute> Attributes
        {
            get;
        }

        ParameterModifiers Modifiers
        {
            get;
        }

        DomRegion Region
        {
            get;
        }

        string Documentation
        {
            get;
        }

        bool IsOut
        {
            get;
        }

        bool IsRef
        {
            get;
        }

        bool IsParams
        {
            get;
        }

        bool IsOptional
        {
            get;
        }
    }
}