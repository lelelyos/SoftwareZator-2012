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
    public abstract class Statement : AbstractNode, INullable
    {
        public static Statement Null
        {
            get
            {
                return NullStatement.Instance;
            }
        }

        public virtual bool IsNull
        {
            get
            {
                return false;
            }
        }

        public static Statement CheckNull(Statement statement)
        {
            return statement ?? NullStatement.Instance;
        }
    }

    public abstract class StatementWithEmbeddedStatement : Statement
    {
        Statement embeddedStatement;

        public Statement EmbeddedStatement
        {
            get
            {
                return embeddedStatement;
            }
            set
            {
                embeddedStatement = Statement.CheckNull(value);
                if (value != null)
                    value.Parent = this;
            }
        }
    }

    internal sealed class NullStatement : Statement
    {
        public static readonly NullStatement Instance = new NullStatement();

        public override bool IsNull
        {
            get { return true; }
        }

        public override object AcceptVisitor(IAstVisitor visitor, object data)
        {
            return data;
        }

        public override string ToString()
        {
            return String.Format("[NullStatement]");
        }
    }
}