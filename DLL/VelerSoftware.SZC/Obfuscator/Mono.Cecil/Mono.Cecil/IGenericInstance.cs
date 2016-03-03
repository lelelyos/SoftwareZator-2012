// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************



using System.Text;

using Mono.Collections.Generic;

namespace Mono.Cecil {

	public interface IGenericInstance : IMetadataTokenProvider {

		bool HasGenericArguments { get; }
		Collection<TypeReference> GenericArguments { get; }
	}

	static partial class Mixin {

		public static bool ContainsGenericParameter (this IGenericInstance self)
		{
			var arguments = self.GenericArguments;

			for (int i = 0; i < arguments.Count; i++)
				if (arguments [i].ContainsGenericParameter)
					return true;

			return false;
		}

		public static void GenericInstanceFullName (this IGenericInstance self, StringBuilder builder)
		{
			builder.Append ("<");
			var arguments = self.GenericArguments;
			for (int i = 0; i < arguments.Count; i++) {
				if (i > 0)
					builder.Append (",");
				builder.Append (arguments [i].FullName);
			}
			builder.Append (">");
		}
	}
}
