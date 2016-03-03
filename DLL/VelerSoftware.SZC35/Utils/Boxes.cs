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
//     <version>$Revision: 3635 $</version>
// </file>

using System;

namespace VelerSoftware.SZC35.Utils
{
	/// <summary>
	/// Reuse the same instances for boxed booleans.
	/// </summary>
	static class Boxes
	{
		public static readonly object True = true;
		public static readonly object False = false;
		
		public static object Box(bool value)
		{
			return value ? True : False;
		}
	}
}
