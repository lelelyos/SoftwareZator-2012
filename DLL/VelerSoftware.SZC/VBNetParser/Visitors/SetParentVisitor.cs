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
using VelerSoftware.SZC.VBNetParser.Ast;
using System.Collections.Generic;

namespace VelerSoftware.SZC.VBNetParser.Visitors
{
	/// <summary>
	/// Sets the parent property on all nodes in the tree.
	/// </summary>
	public class SetParentVisitor : NodeTrackingAstVisitor
	{
		Stack<INode> nodeStack = new Stack<INode>();
		
		public SetParentVisitor()
		{
			nodeStack.Push(null);
		}
		
		protected override void BeginVisit(INode node)
		{
			node.Parent = nodeStack.Peek();
			nodeStack.Push(node);
		}
		
		protected override void EndVisit(INode node)
		{
			nodeStack.Pop();
		}
	}
}
