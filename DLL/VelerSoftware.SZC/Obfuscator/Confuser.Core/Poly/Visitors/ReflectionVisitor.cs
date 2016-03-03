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
using System.Reflection.Emit;
using VelerSoftware.SZC.Obfuscator.Confuser.Core.Poly.Expressions;

namespace VelerSoftware.SZC.Obfuscator.Confuser.Core.Poly.Visitors
{
    public class ReflectionVisitor : ExpressionVisitor
    {
        DynamicMethod dm;
        ILGenerator gen;
        bool useDouble;
        public ReflectionVisitor(Expression exp, bool isReverse, bool useDouble)
        {
            if (useDouble)
                dm = new DynamicMethod("", typeof(double), new Type[] { typeof(double) });
            else
                dm = new DynamicMethod("", typeof(long), new Type[] { typeof(long) });
            gen = dm.GetILGenerator();
            this.useDouble = useDouble;
            if (isReverse)
                exp.GetVariableExpression().VisitReverse(this, null);
            else
                exp.Visit(this);
            gen.Emit(OpCodes.Ret);
        }

        public object Eval(object var)
        {
            if (useDouble)
                return (double)dm.Invoke(null, new object[] { (double)var });
            else
                return (long)dm.Invoke(null, new object[] { (long)var });
        }

        public override void Visit(Expression exp)
        {
            if (exp is ConstantExpression)
            {
                ConstantExpression tExp = exp as ConstantExpression;
                if (useDouble)
                    gen.Emit(OpCodes.Ldc_R8, tExp.Value);
                else
                    gen.Emit(OpCodes.Ldc_I8, (long)tExp.Value);
            }
            else if (exp is VariableExpression)
            {
                gen.Emit(OpCodes.Ldarg_0);
            }
            else if (exp is AddExpression)
            {
                gen.Emit(OpCodes.Add);
            }
            else if (exp is SubExpression)
            {
                gen.Emit(OpCodes.Sub);
            }
            else if (exp is MulExpression)
            {
                gen.Emit(OpCodes.Mul);
            }
            else if (exp is NegExpression)
            {
                gen.Emit(OpCodes.Neg);
            }
            else if (exp is DivExpression)
            {
                gen.Emit(OpCodes.Div);
            }
        }

        public override void VisitReverse(Expression exp)
        {
            if (exp is ConstantExpression)
            {
                ConstantExpression tExp = exp as ConstantExpression;
                if (useDouble)
                    gen.Emit(OpCodes.Ldc_R8, tExp.Value);
                else
                    gen.Emit(OpCodes.Ldc_I8, (long)tExp.Value);
            }
            else if (exp is VariableExpression)
            {
                gen.Emit(OpCodes.Ldarg_0);
            }
            else if (exp is AddExpression)
            {
                gen.Emit(OpCodes.Sub);
            }
            else if (exp is SubExpression)
            {
                gen.Emit(OpCodes.Add);
            }
            else if (exp is MulExpression)
            {
                gen.Emit(OpCodes.Div);
            }
            else if (exp is NegExpression)
            {
                gen.Emit(OpCodes.Neg);
            }
            else if (exp is DivExpression)
            {
                gen.Emit(OpCodes.Mul);
            }
        }
    }
}
