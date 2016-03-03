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

namespace Mono.Cecil.Rocks {

	public static class ModuleDefinitionRocks {

		public static IEnumerable<TypeDefinition> GetAllTypes (this ModuleDefinition self)
		{
			if (self == null)
				throw new ArgumentNullException ("self");

			// it was fun to write, but we need a somewhat less convoluted implementation
			return self.Types.SelectMany (
				Functional.Y<TypeDefinition, IEnumerable<TypeDefinition>> (f => type => type.NestedTypes.SelectMany (f).Prepend (type)));
		}
	}
}
