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

namespace VelerSoftware.SZC.Obfuscator.Confuser.Core.Poly.Expressions
{
    public class NegExpression : Expression
    {
        Expression val;
        public Expression Value { get { return val; } set { val = value; } }

        public override Expression GetVariableExpression()
        {
            return val.GetVariableExpression();
        }

        public override void Visit(ExpressionVisitor visitor)
        {
            val.Visit(visitor);
            visitor.Visit(this);
        }

        public override void VisitReverse(ExpressionVisitor visitor, Expression child)
        {
            val.Visit(visitor);
            visitor.VisitReverse(this);
            if (Parent != null && child != null)
                Parent.VisitReverse(visitor, this);
        }

        public override bool HasVariable
        {
            get { return false; }
        }

        public override string ToString()
        {
            return string.Format("-{0}", val);
        }
    }
}
