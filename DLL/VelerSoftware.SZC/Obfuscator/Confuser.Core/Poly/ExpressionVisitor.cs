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

namespace VelerSoftware.SZC.Obfuscator.Confuser.Core.Poly
{
    public abstract class ExpressionVisitor
    {
        public abstract void Visit(Expression exp);
        public abstract void VisitReverse(Expression exp);
    }
}
