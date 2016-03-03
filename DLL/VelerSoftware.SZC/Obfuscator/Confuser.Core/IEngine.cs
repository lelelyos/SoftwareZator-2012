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
using System.Linq;
using System.Text;
using Mono.Cecil;

namespace VelerSoftware.SZC.Obfuscator.Confuser.Core
{
    public interface IEngine
    {
        void Analysis(Logger logger, IEnumerable<AssemblyDefinition> asms);
    }
}
