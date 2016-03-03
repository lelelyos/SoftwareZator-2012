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

using VelerSoftware.SZC35.Utils;
using System;

namespace VelerSoftware.SZC35
{
	/// <summary>
	/// Contains weak event managers for <see cref="ITextEditorComponent"/>.
	/// </summary>
	public static class TextEditorWeakEventManager
	{
		/// <summary>
		/// Weak event manager for the <see cref="ITextEditorComponent.DocumentChanged"/> event.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
		public sealed class DocumentChanged : WeakEventManagerBase<DocumentChanged, ITextEditorComponent>
		{
			/// <inheritdoc/>
			protected override void StartListening(ITextEditorComponent source)
			{
				source.DocumentChanged += DeliverEvent;
			}
			
			/// <inheritdoc/>
			protected override void StopListening(ITextEditorComponent source)
			{
				source.DocumentChanged -= DeliverEvent;
			}
		}
		
		/// <summary>
		/// Weak event manager for the <see cref="ITextEditorComponent.OptionChanged"/> event.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
		public sealed class OptionChanged : WeakEventManagerBase<OptionChanged, ITextEditorComponent>
		{
			/// <inheritdoc/>
			protected override void StartListening(ITextEditorComponent source)
			{
				source.OptionChanged += DeliverEvent;
			}
			
			/// <inheritdoc/>
			protected override void StopListening(ITextEditorComponent source)
			{
				source.OptionChanged -= DeliverEvent;
			}
		}
	}
}
