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

namespace VelerSoftware.SZC.Debugger.Interfaces
{
    [Serializable]
    [Flags]
    public enum ParameterModifiers : byte
    {
        // Values must be the same as in NRefactory's ParamModifiers
        None = 0,
        In = 1,
        Out = 2,
        Ref = 4,
        Params = 8,
        Optional = 16
    }
}