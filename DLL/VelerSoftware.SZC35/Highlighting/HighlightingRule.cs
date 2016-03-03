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
using System.Text.RegularExpressions;

namespace VelerSoftware.SZC35.Highlighting
{
	/// <summary>
	/// A highlighting rule.
	/// </summary>
	[Serializable]
	public class HighlightingRule
	{
		/// <summary>
		/// Gets/Sets the regular expression for the rule.
		/// </summary>
		public Regex Regex { get; set; }
		
		/// <summary>
		/// Gets/Sets the highlighting color.
		/// </summary>
		public HighlightingColor Color { get; set; }
		
		/// <inheritdoc/>
		public override string ToString()
		{
			return "[" + GetType().Name + " " + Regex + "]";
		}
	}
}
