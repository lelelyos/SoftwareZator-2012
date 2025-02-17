﻿// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System;
using System.Reflection;

namespace VelerSoftware.SZC.Debugger.Debugger.MetaData
{
    interface IOverloadable
    {
        ParameterInfo[] GetParameters();

        IntPtr GetSignarture();
    }
}