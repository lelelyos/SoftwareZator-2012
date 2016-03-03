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
    public interface IMethodOrProperty : IMember
    {
        IList<IParameter> Parameters
        {
            get;
        }

        bool IsExtensionMethod
        {
            get;
        }
    }

    public interface IMethod : IMethodOrProperty
    {
        IList<ITypeParameter> TypeParameters
        {
            get;
        }

        bool IsConstructor
        {
            get;
        }

        IList<string> HandlesClauses
        {
            get;
        }

        bool IsOperator
        {
            get;
        }
    }
}