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

namespace Mono.Cecil.Rocks {

	static class Functional {

		public static System.Func<A, R> Y<A, R> (System.Func<System.Func<A, R>, System.Func<A, R>> f)
		{
			System.Func<A, R> g = null;
			g = f (a => g (a));
			return g;
		}

		public static IEnumerable<TSource> Prepend<TSource> (this IEnumerable<TSource> source, TSource element)
		{
			if (source == null)
				throw new ArgumentNullException ("source");

			return PrependIterator (source, element);
		}

		static IEnumerable<TSource> PrependIterator<TSource> (IEnumerable<TSource> source, TSource element)
		{
			yield return element;

			foreach (var item in source)
				yield return item;
		}
	}
}
