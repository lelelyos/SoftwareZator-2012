﻿// *****************************************************************************
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

namespace VelerSoftware.SZC35.Editing
{
	/// <summary>
	/// Contains classes for handling weak events on the Caret class.
	/// </summary>
	public static class CaretWeakEventManager
	{
		/// <summary>
		/// Handles the Caret.PositionChanged event.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
		public sealed class PositionChanged : WeakEventManagerBase<PositionChanged, Caret>
		{
			/// <inheritdoc/>
			protected override void StartListening(Caret source)
			{
				source.PositionChanged += DeliverEvent;
			}
			
			/// <inheritdoc/>
			protected override void StopListening(Caret source)
			{
				source.PositionChanged -= DeliverEvent;
			}
		}
	}
}
