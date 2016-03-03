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

namespace VelerSoftware.SZC.VBNetParser.Ast
{
    public class PrimitiveExpression : Expression
    {
        string stringValue;

        public Parser.LiteralFormat LiteralFormat { get; set; }

        public object Value { get; set; }

        public string StringValue
        {
            get
            {
                if (stringValue == null)
                    return " ";
                else
                    return stringValue;
            }
            set
            {
                stringValue = value == null ? String.Empty : value;
            }
        }

        public PrimitiveExpression(object val)
        {
            this.Value = val;
        }

        public PrimitiveExpression(object val, string stringValue)
        {
            this.Value = val;
            this.StringValue = stringValue;
        }

        public override object AcceptVisitor(IAstVisitor visitor, object data)
        {
            return visitor.VisitPrimitiveExpression(this, data);
        }

        public override string ToString()
        {
            return String.Format("[PrimitiveExpression: Value={1}, ValueType={2}, StringValue={0}]",
                                 this.StringValue,
                                 this.Value,
                                 this.Value == null ? "null" : this.Value.GetType().FullName
                                );
        }
    }
}