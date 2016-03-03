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
//     <version>$Revision: 5235 $</version>
// </file>

using System;
using System.Windows.Threading;
using VelerSoftware.SZC35.Document;
using VelerSoftware.SZC35.Rendering;

namespace VelerSoftware.SZC35.Folding
{
	/// <summary>
	/// A section that can be folded.
	/// </summary>
	public sealed class FoldingSection : TextSegment
	{
		FoldingManager manager;
		bool isFolded;
		CollapsedLineSection collapsedSection;
		string title;
		
		/// <summary>
		/// Gets/sets if the section is folded.
		/// </summary>
		public bool IsFolded {
			get { return isFolded; }
			set {
				if (isFolded != value) {
					isFolded = value;
					if (value) {
						if (manager != null) {
							DocumentLine startLine = manager.document.GetLineByOffset(StartOffset);
							DocumentLine endLine = manager.document.GetLineByOffset(EndOffset);
							if (startLine != endLine) {
								DocumentLine startLinePlusOne = startLine.NextLine;
								collapsedSection = manager.textView.CollapseLines(startLinePlusOne, endLine);
							}
						}
					} else {
						RemoveCollapsedLineSection();
					}
					if (manager != null)
						manager.textView.Redraw(this, DispatcherPriority.Normal);
				}
			}
		}
		
		/// <summary>
		/// Gets/Sets the text used to display the collapsed version of the folding section.
		/// </summary>
		public string Title {
			get {
				return title;
			}
			set {
				if (title != value) {
					title = value;
					if (this.IsFolded && manager != null)
						manager.textView.Redraw(this, DispatcherPriority.Normal);
				}
			}
		}
		
		/// <summary>
		/// Gets/Sets an additional object associated with this folding section.
		/// </summary>
		public object Tag { get; set; }
		
		internal FoldingSection(FoldingManager manager, int startOffset, int endOffset)
		{
			this.manager = manager;
			this.StartOffset = startOffset;
			this.Length = endOffset - startOffset;
		}
		
		void RemoveCollapsedLineSection()
		{
			if (collapsedSection != null) {
				if (collapsedSection.Start != null)
					collapsedSection.Uncollapse();
				collapsedSection = null;
			}
		}
		
		internal void Removed()
		{
			manager = null;
		}
	}
}
