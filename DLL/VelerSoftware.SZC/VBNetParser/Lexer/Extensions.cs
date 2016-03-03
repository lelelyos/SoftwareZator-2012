// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VelerSoftware.SZC.VBNetParser.Parser.VB
{
	public static class Extensions
	{
		public static bool IsElement<T>(this IEnumerable<T> items, Func<T, bool> check)
		{
			T item = items.FirstOrDefault();
			
			if (item != null)
				return check(item);
			return false;
		}
	}
}
