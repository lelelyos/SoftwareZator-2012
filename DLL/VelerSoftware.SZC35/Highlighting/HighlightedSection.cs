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
//     <version>$Revision: 3899 $</version>
// </file>

using System;
using VelerSoftware.SZC35.Document;

namespace VelerSoftware.SZC35.Highlighting
{
	/// <summary>
	/// A text section with syntax highlighting information.
	/// </summary>
	public class HighlightedSection : ISegment
	{
		/// <summary>
		/// Gets/sets the document offset of the section.
		/// </summary>
		public int Offset { get; set; }
		
		/// <summary>
		/// Gets/sets the length of the section.
		/// </summary>
		public int Length { get; set; }
		
		int ISegment.EndOffset {
			get { return this.Offset + this.Length; }
		}
		
		/// <summary>
		/// Gets the highlighting color associated with the highlighted section.
		/// </summary>
		public HighlightingColor Color { get; set; }
	}
}
