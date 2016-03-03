// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************


using Mono.Collections.Generic;

namespace Mono {

	static class Empty<T> {

		public static readonly T [] Array = new T [0];
	}
}

namespace Mono.Cecil {

	static partial class Mixin {

		public static bool IsNullOrEmpty<T> (this T [] self)
		{
			return self == null || self.Length == 0;
		}

		public static bool IsNullOrEmpty<T> (this Collection<T> self)
		{
			return self == null || self.size == 0;
		}
	}
}
