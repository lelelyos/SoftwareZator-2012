// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <author name="Daniel Grunwald"/>
//     <version>$Revision: 3635 $</version>
// </file>

using System;

namespace VelerSoftware.SZC35.Highlighting.Xshd
{
	/// <summary>
	/// A visitor over the XSHD element tree.
	/// </summary>
	public interface IXshdVisitor
	{
		/// <summary/>
		object VisitRuleSet(XshdRuleSet ruleSet);
		
		/// <summary/>
		object VisitColor(XshdColor color);
		
		/// <summary/>
		object VisitKeywords(XshdKeywords keywords);
		
		/// <summary/>
		object VisitSpan(XshdSpan span);
		
		/// <summary/>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "A VB programmer implementing a visitor?")]
		object VisitImport(XshdImport import);
		
		/// <summary/>
		object VisitRule(XshdRule rule);
	}
}
