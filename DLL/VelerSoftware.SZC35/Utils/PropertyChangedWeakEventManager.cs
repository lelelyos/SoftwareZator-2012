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
//     <version>$Revision: 3907 $</version>
// </file>

using System;
using System.ComponentModel;

namespace VelerSoftware.SZC35.Utils
{
	/// <summary>
	/// WeakEventManager for INotifyPropertyChanged.PropertyChanged.
	/// </summary>
	public sealed class PropertyChangedWeakEventManager : WeakEventManagerBase<PropertyChangedWeakEventManager, INotifyPropertyChanged>
	{
		/// <inheritdoc/>
		protected override void StartListening(INotifyPropertyChanged source)
		{
			source.PropertyChanged += DeliverEvent;
		}
		
		/// <inheritdoc/>
		protected override void StopListening(INotifyPropertyChanged source)
		{
			source.PropertyChanged -= DeliverEvent;
		}
	}
}
