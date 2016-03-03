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
//     <version>$Revision: 4142 $</version>
// </file>

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace VelerSoftware.SZC35.Rendering
{
	struct HeightTreeLineNode
	{
		internal HeightTreeLineNode(double height)
		{
			this.collapsedSections = null;
			this.height = height;
		}
		
		internal double height;
		internal List<CollapsedLineSection> collapsedSections;
		
		internal bool IsDirectlyCollapsed {
			get { return collapsedSections != null; }
		}
		
		internal void AddDirectlyCollapsed(CollapsedLineSection section)
		{
			if (collapsedSections == null)
				collapsedSections = new List<CollapsedLineSection>();
			collapsedSections.Add(section);
		}
		
		internal void RemoveDirectlyCollapsed(CollapsedLineSection section)
		{
			Debug.Assert(collapsedSections.Contains(section));
			collapsedSections.Remove(section);
			if (collapsedSections.Count == 0)
				collapsedSections = null;
		}
		
		/// <summary>
		/// Returns 0 if the line is directly collapsed, otherwise, returns <see cref="height"/>.
		/// </summary>
		internal double TotalHeight {
			get {
				return IsDirectlyCollapsed ? 0 : height;
			}
		}
	}
}
