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

	public interface IConstantProvider : IMetadataTokenProvider {

		bool HasConstant { get; set; }
		object Constant { get; set; }
	}

	static partial class Mixin {

		internal static object NoValue = new object ();
		internal static object NotResolved = new object ();

		public static void ResolveConstant (
			this IConstantProvider self,
			ref object constant,
			ModuleDefinition module)
		{
			constant = module.HasImage ()
				? module.Read (self, (provider, reader) => reader.ReadConstant (provider))
				: Mixin.NoValue;
		}
	}
}
