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
//     <version>$Revision: 5572 $</version>
// </file>

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace VelerSoftware.SZC35.Highlighting
{
	/// <summary>
	/// A highlighting definition.
	/// </summary>
	[TypeConverter(typeof(HighlightingDefinitionTypeConverter))]
	public interface IHighlightingDefinition
	{
		/// <summary>
		/// Gets the name of the highlighting definition.
		/// </summary>
		string Name { get; }
		
		/// <summary>
		/// Gets the main rule set.
		/// </summary>
		HighlightingRuleSet MainRuleSet { get; }
		
		/// <summary>
		/// Gets a rule set by name.
		/// </summary>
		/// <returns>The rule set, or null if it is not found.</returns>
		HighlightingRuleSet GetNamedRuleSet(string name);
		
		/// <summary>
		/// Gets a named highlighting color.
		/// </summary>
		/// <returns>The highlighting color, or null if it is not found.</returns>
		HighlightingColor GetNamedColor(string name);
		
		/// <summary>
		/// Gets the list of named highlighting colors.
		/// </summary>
		IEnumerable<HighlightingColor> NamedHighlightingColors { get; }
	}
}
