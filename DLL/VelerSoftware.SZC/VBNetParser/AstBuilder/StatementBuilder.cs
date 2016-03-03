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
using VelerSoftware.SZC.VBNetParser.Ast;

namespace VelerSoftware.SZC.VBNetParser.AstBuilder
{
	/// <summary>
	/// Extension methods for NRefactory.Ast.Expression.
	/// </summary>
	public static class StatementBuilder
	{
		public static void AddStatement(this BlockStatement block, Statement statement)
		{
			if (block == null)
				throw new ArgumentNullException("block");
			if (statement == null)
				throw new ArgumentNullException("statement");
			block.AddChild(statement);
			statement.Parent = block;
		}
		
		public static void AddStatement(this BlockStatement block, Expression expressionStatement)
		{
			if (expressionStatement == null)
				throw new ArgumentNullException("expressionStatement");
			AddStatement(block, new ExpressionStatement(expressionStatement));
		}
		
		public static void Throw(this BlockStatement block, Expression expression)
		{
			if (expression == null)
				throw new ArgumentNullException("expression");
			AddStatement(block, new ThrowStatement(expression));
		}
		
		public static void Return(this BlockStatement block, Expression expression)
		{
			if (expression == null)
				throw new ArgumentNullException("expression");
			AddStatement(block, new ReturnStatement(expression));
		}
		
		public static void Assign(this BlockStatement block, Expression left, Expression right)
		{
			if (left == null)
				throw new ArgumentNullException("left");
			if (right == null)
				throw new ArgumentNullException("right");
			AddStatement(block, new AssignmentExpression(left, AssignmentOperatorType.Assign, right));
		}
	}
}
