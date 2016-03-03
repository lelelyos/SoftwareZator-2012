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

	public interface IMethodSignature : IMetadataTokenProvider {

		bool HasThis { get; set; }
		bool ExplicitThis { get; set; }
		MethodCallingConvention CallingConvention { get; set; }

		bool HasParameters { get; }
		Collection<ParameterDefinition> Parameters { get; }
		TypeReference ReturnType { get; set; }
		MethodReturnType MethodReturnType { get; }
	}

	static partial class Mixin {

		public static void MethodSignatureFullName (this IMethodSignature self, StringBuilder builder)
		{
			builder.Append ("(");

			if (self.HasParameters) {
				var parameters = self.Parameters;
				for (int i = 0; i < parameters.Count; i++) {
					var parameter = parameters [i];
					if (i > 0)
						builder.Append (",");

					if (parameter.ParameterType.IsSentinel)
						builder.Append ("...,");

					builder.Append (parameter.ParameterType.FullName);
				}
			}

			builder.Append (")");
		}
	}
}
