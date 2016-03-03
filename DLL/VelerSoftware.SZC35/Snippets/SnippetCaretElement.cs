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
//     <version>$Revision: 5529 $</version>
// </file>

using System;
using System.Windows.Input;
using VelerSoftware.SZC35.Document;

namespace VelerSoftware.SZC35.Snippets
{
	/// <summary>
	/// Sets the caret position after interactive mode has finished.
	/// </summary>
	[Serializable]
	public class SnippetCaretElement : SnippetElement
	{
		/// <inheritdoc/>
		public override void Insert(InsertionContext context)
		{
			if (!string.IsNullOrEmpty(context.SelectedText))
				SetCaret(context);
		}
		
		internal static void SetCaret(InsertionContext context)
		{
			TextAnchor pos = context.Document.CreateAnchor(context.InsertionPosition);
			pos.SurviveDeletion = true;
			context.Deactivated += (sender, e) => {
				if (e.Reason == DeactivateReason.ReturnPressed || e.Reason == DeactivateReason.NoActiveElements) {
					context.TextArea.Caret.Offset = pos.Offset;
				}
			};
		}
	}
}
