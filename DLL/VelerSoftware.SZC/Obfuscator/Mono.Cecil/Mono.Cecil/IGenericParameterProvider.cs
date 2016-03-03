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

namespace Mono.Cecil {

	public interface IGenericParameterProvider : IMetadataTokenProvider {

		bool HasGenericParameters { get; }
		bool IsDefinition { get; }
		ModuleDefinition Module { get; }
		Collection<GenericParameter> GenericParameters { get; }
		GenericParameterType GenericParameterType { get; }
	}

	public enum GenericParameterType {
		Type,
		Method
	}

	interface IGenericContext {

		bool IsDefinition { get; }
		IGenericParameterProvider Type { get; }
		IGenericParameterProvider Method { get; }
	}

	static partial class Mixin {

		public static bool GetHasGenericParameters (
			this IGenericParameterProvider self,
			ModuleDefinition module)
		{
			return module.HasImage ()
				? module.Read (self, (provider, reader) => reader.HasGenericParameters (provider))
				: false;
		}

		public static Collection<GenericParameter> GetGenericParameters (
			this IGenericParameterProvider self,
			ModuleDefinition module)
		{
			return module.HasImage ()
				? module.Read (self, (provider, reader) => reader.ReadGenericParameters (provider))
				: new Collection<GenericParameter> ();
		}
	}
}
