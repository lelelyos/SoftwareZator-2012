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

namespace VelerSoftware.SZC35.Rendering
{
	/// <summary>
	/// Allows <see cref="VisualLineElementGenerator"/>s, <see cref="IVisualLineTransformer"/>s and
	/// <see cref="IBackgroundRenderer"/>s to be notified when they are added or removed from a text view.
	/// </summary>
	public interface ITextViewConnect
	{
		/// <summary>
		/// Called when added to a text view.
		/// </summary>
		void AddToTextView(TextView textView);
		
		/// <summary>
		/// Called when removed from a text view.
		/// </summary>
		void RemoveFromTextView(TextView textView);
	}
}
