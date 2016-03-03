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
//     <version>$Revision: 4626 $</version>
// </file>

using System;

namespace VelerSoftware.SZC35.Highlighting.Xshd
{
	/// <summary>
	/// &lt;Rule&gt; element.
	/// </summary>
	[Serializable]
	public class XshdRule : XshdElement
	{
		/// <summary>
		/// Gets/sets the rule regex.
		/// </summary>
		public string Regex { get; set; }
		
		/// <summary>
		/// Gets/sets the rule regex type.
		/// </summary>
		public XshdRegexType RegexType { get; set; }
		
		/// <summary>
		/// Gets/sets the color reference.
		/// </summary>
		public XshdReference<XshdColor> ColorReference { get; set; }
		
		/// <inheritdoc/>
		public override object AcceptVisitor(IXshdVisitor visitor)
		{
			return visitor.VisitRule(this);
		}
	}
}
