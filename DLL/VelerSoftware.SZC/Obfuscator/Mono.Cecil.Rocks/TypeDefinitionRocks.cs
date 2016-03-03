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

	public static class TypeDefinitionRocks {

		public static IEnumerable<MethodDefinition> GetConstructors (this TypeDefinition self)
		{
			if (self == null)
				throw new ArgumentNullException ("self");

			if (!self.HasMethods)
				return Empty<MethodDefinition>.Array;

			return self.Methods.Where (method => method.IsConstructor);
		}

		public static MethodDefinition GetStaticConstructor (this TypeDefinition self)
		{
			if (self == null)
				throw new ArgumentNullException ("self");

			if (!self.HasMethods)
				return null;

			return self.GetConstructors ().FirstOrDefault (ctor => ctor.IsStatic);
		}

		public static IEnumerable<MethodDefinition> GetMethods (this TypeDefinition self)
		{
			if (self == null)
				throw new ArgumentNullException ("self");

			if (!self.HasMethods)
				return Empty<MethodDefinition>.Array;

			return self.Methods.Where (method => !method.IsConstructor);
		}

		public static TypeReference GetEnumUnderlyingType (this TypeDefinition self)
		{
			if (self == null)
				throw new ArgumentNullException ("self");
			if (!self.IsEnum)
				throw new ArgumentException ();

			return Mixin.GetEnumUnderlyingType (self);
		}
	}
}
