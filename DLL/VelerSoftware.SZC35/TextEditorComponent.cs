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
using System.ComponentModel;
using VelerSoftware.SZC35.Document;
using VelerSoftware.SZC35.Editing;
using VelerSoftware.SZC35.Rendering;

namespace VelerSoftware.SZC35
{
	/// <summary>
	/// Represents a text editor control (<see cref="TextEditor"/>, <see cref="TextArea"/>
	/// or <see cref="TextView"/>).
	/// </summary>
	public interface ITextEditorComponent : IServiceProvider
	{
		/// <summary>
		/// Gets the document being edited.
		/// </summary>
		TextDocument Document { get; }
		
		/// <summary>
		/// Occurs when the Document property changes (when the text editor is connected to another
		/// document - not when the document content changes).
		/// </summary>
		event EventHandler DocumentChanged;
		
		/// <summary>
		/// Gets the options of the text editor.
		/// </summary>
		TextEditorOptions Options { get; }
		
		/// <summary>
		/// Occurs when the Options property changes, or when an option inside the current option list
		/// changes.
		/// </summary>
		event PropertyChangedEventHandler OptionChanged;
	}
}
