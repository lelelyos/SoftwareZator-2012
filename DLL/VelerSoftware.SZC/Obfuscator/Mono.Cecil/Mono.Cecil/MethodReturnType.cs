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

	public sealed class MethodReturnType : IConstantProvider, ICustomAttributeProvider, IMarshalInfoProvider {

		internal IMethodSignature method;
		internal ParameterDefinition parameter;
		TypeReference return_type;

		public IMethodSignature Method {
			get { return method; }
		}

		public TypeReference ReturnType {
			get { return return_type; }
			set { return_type = value; }
		}

		internal ParameterDefinition Parameter {
			get { return parameter ?? (parameter = new ParameterDefinition (return_type)); }
			set { parameter = value; }
		}

		public MetadataToken MetadataToken {
			get { return Parameter.MetadataToken; }
			set { Parameter.MetadataToken = value; }
		}

		public bool HasCustomAttributes {
			get { return parameter != null && parameter.HasCustomAttributes; }
		}

		public Collection<CustomAttribute> CustomAttributes {
			get { return Parameter.CustomAttributes; }
		}

		public bool HasDefault {
			get { return parameter != null && parameter.HasDefault; }
			set { Parameter.HasDefault = value; }
		}

		public bool HasConstant {
			get { return parameter != null && parameter.HasConstant; }
			set { Parameter.HasConstant = value; }
		}

		public object Constant {
			get { return Parameter.Constant; }
			set { Parameter.Constant = value; }
		}

		public bool HasFieldMarshal {
			get { return parameter != null && parameter.HasFieldMarshal; }
			set { Parameter.HasFieldMarshal = value; }
		}

		public bool HasMarshalInfo {
			get { return parameter != null && parameter.HasMarshalInfo; }
		}

		public MarshalInfo MarshalInfo {
			get { return Parameter.MarshalInfo; }
			set { Parameter.MarshalInfo = value; }
		}

		public MethodReturnType (IMethodSignature method)
		{
			this.method = method;
		}
	}
}
