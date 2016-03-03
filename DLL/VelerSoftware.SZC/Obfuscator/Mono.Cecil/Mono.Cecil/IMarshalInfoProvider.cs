// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************



namespace Mono.Cecil {

	public interface IMarshalInfoProvider : IMetadataTokenProvider {

		bool HasMarshalInfo { get; }
		MarshalInfo MarshalInfo { get; set; }
	}

	static partial class Mixin {

		public static bool GetHasMarshalInfo (
			this IMarshalInfoProvider self,
			ModuleDefinition module)
		{
			return module.HasImage ()
				? module.Read (self, (provider, reader) => reader.HasMarshalInfo (provider))
				: false;
		}

		public static MarshalInfo GetMarshalInfo (
			this IMarshalInfoProvider self,
			ModuleDefinition module)
		{
			return module.HasImage ()
				? module.Read (self, (provider, reader) => reader.ReadMarshalInfo (provider))
				: null;
		}
	}
}
