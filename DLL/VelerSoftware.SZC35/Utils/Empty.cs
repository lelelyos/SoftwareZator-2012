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
//     <version>$Revision: 4572 $</version>
// </file>

using System;
using System.Collections.ObjectModel;

namespace VelerSoftware.SZC35.Utils
{
	/// <summary>
	/// Provides immutable empty list instances.
	/// </summary>
	static class Empty<T>
	{
		public static readonly T[] Array = new T[0];
		//public static readonly ReadOnlyCollection<T> ReadOnlyCollection = new ReadOnlyCollection<T>(Array);
	}
}
