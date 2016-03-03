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
//     <version>$Revision: 4932 $</version>
// </file>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

using VelerSoftware.SZC35.Document;
using VelerSoftware.SZC35.Editing;
using VelerSoftware.SZC35.Rendering;
using VelerSoftware.SZC35.Utils;

namespace VelerSoftware.SZC35.Folding
{
	/// <summary>
	/// Helper class used for <see cref="FoldingManager.UpdateFoldings"/>.
	/// </summary>
	public class NewFolding : ISegment
	{
		/// <summary>
		/// Gets/Sets the start offset.
		/// </summary>
		public int StartOffset { get; set; }
		
		/// <summary>
		/// Gets/Sets the end offset.
		/// </summary>
		public int EndOffset { get; set; }
		
		/// <summary>
		/// Gets/Sets the name displayed for the folding.
		/// </summary>
		public string Name { get; set; }
		
		/// <summary>
		/// Gets/Sets whether the folding is closed by default.
		/// </summary>
		public bool DefaultClosed { get; set; }
		
		/// <summary>
		/// Creates a new NewFolding instance.
		/// </summary>
		public NewFolding()
		{
		}
		
		/// <summary>
		/// Creates a new NewFolding instance.
		/// </summary>
		public NewFolding(int start, int end)
		{
			if (!(start <= end))
				throw new ArgumentException("'start' must be less than 'end'");
			this.StartOffset = start;
			this.EndOffset = end;
			this.Name = null;
			this.DefaultClosed = false;
		}
		
		int ISegment.Offset {
			get { return this.StartOffset; }
		}
		
		int ISegment.Length {
			get { return this.EndOffset - this.StartOffset; }
		}
	}
}
