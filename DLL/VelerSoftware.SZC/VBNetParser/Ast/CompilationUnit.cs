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
    public class CompilationUnit : AbstractNode
    {
        // Children in C#: UsingAliasDeclaration, UsingDeclaration, AttributeSection, NamespaceDeclaration
        // Children in VB: OptionStatements, ImportsStatement, AttributeSection, NamespaceDeclaration

        public override object AcceptVisitor(IAstVisitor visitor, object data)
        {
            return visitor.VisitCompilationUnit(this, data);
        }

        public override string ToString()
        {
            return String.Format("[CompilationUnit]");
        }
    }
}