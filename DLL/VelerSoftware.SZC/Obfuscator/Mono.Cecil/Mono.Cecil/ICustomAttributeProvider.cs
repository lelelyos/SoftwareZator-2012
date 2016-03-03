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

using Mono.Collections.Generic;

namespace Mono.Cecil {

	public interface ICustomAttributeProvider : IMetadataTokenProvider {

		Collection<CustomAttribute> CustomAttributes { get; }

		bool HasCustomAttributes { get; }
	}

	static partial class Mixin {

		public static bool GetHasCustomAttributes (
			this ICustomAttributeProvider self,
			ModuleDefinition module)
		{
			return module.HasImage ()
				? module.Read (self, (provider, reader) => reader.HasCustomAttributes (provider))
				: false;
		}

		public static Collection<CustomAttribute> GetCustomAttributes (
			this ICustomAttributeProvider self,
			ModuleDefinition module)
		{
			return module.HasImage ()
				? module.Read (self, (provider, reader) => reader.ReadCustomAttributes (provider))
				: new Collection<CustomAttribute> ();
		}
	}
}
