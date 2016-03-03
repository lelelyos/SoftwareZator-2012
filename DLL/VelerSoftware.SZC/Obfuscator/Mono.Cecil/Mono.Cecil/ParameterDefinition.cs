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

	public sealed class ParameterDefinition : ParameterReference, ICustomAttributeProvider, IConstantProvider, IMarshalInfoProvider {

		ushort attributes;

		internal IMethodSignature method;

		object constant = Mixin.NotResolved;
		Collection<CustomAttribute> custom_attributes;
		MarshalInfo marshal_info;

		public ParameterAttributes Attributes {
			get { return (ParameterAttributes) attributes; }
			set { attributes = (ushort) value; }
		}

		public IMethodSignature Method {
			get { return method; }
		}

		public int Sequence {
			get {
				if (method == null)
					return -1;

				return method.HasThis ? index + 1 : index;
			}
		}

		public bool HasConstant {
			get {
				ResolveConstant ();

				return constant != Mixin.NoValue;
			}
			set { if (!value) constant = Mixin.NoValue; }
		}

		public object Constant {
			get { return HasConstant ? constant : null;	}
			set { constant = value; }
		}

		void ResolveConstant ()
		{
			if (constant != Mixin.NotResolved)
				return;

			this.ResolveConstant (ref constant, parameter_type.Module);
		}

		public bool HasCustomAttributes {
			get {
				if (custom_attributes != null)
					return custom_attributes.Count > 0;

				return this.GetHasCustomAttributes (parameter_type.Module);
			}
		}

		public Collection<CustomAttribute> CustomAttributes {
			get { return custom_attributes ?? (custom_attributes = this.GetCustomAttributes (parameter_type.Module)); }
		}

		public bool HasMarshalInfo {
			get {
				if (marshal_info != null)
					return true;

				return this.GetHasMarshalInfo (parameter_type.Module);
			}
		}

		public MarshalInfo MarshalInfo {
			get { return marshal_info ?? (marshal_info = this.GetMarshalInfo (parameter_type.Module)); }
			set { marshal_info = value; }
		}

		#region ParameterAttributes

		public bool IsIn {
			get { return attributes.GetAttributes ((ushort) ParameterAttributes.In); }
			set { attributes = attributes.SetAttributes ((ushort) ParameterAttributes.In, value); }
		}

		public bool IsOut {
			get { return attributes.GetAttributes ((ushort) ParameterAttributes.Out); }
			set { attributes = attributes.SetAttributes ((ushort) ParameterAttributes.Out, value); }
		}

		public bool IsLcid {
			get { return attributes.GetAttributes ((ushort) ParameterAttributes.Lcid); }
			set { attributes = attributes.SetAttributes ((ushort) ParameterAttributes.Lcid, value); }
		}

		public bool IsReturnValue {
			get { return attributes.GetAttributes ((ushort) ParameterAttributes.Retval); }
			set { attributes = attributes.SetAttributes ((ushort) ParameterAttributes.Retval, value); }
		}

		public bool IsOptional {
			get { return attributes.GetAttributes ((ushort) ParameterAttributes.Optional); }
			set { attributes = attributes.SetAttributes ((ushort) ParameterAttributes.Optional, value); }
		}

		public bool HasDefault {
			get { return attributes.GetAttributes ((ushort) ParameterAttributes.HasDefault); }
			set { attributes = attributes.SetAttributes ((ushort) ParameterAttributes.HasDefault, value); }
		}

		public bool HasFieldMarshal {
			get { return attributes.GetAttributes ((ushort) ParameterAttributes.HasFieldMarshal); }
			set { attributes = attributes.SetAttributes ((ushort) ParameterAttributes.HasFieldMarshal, value); }
		}

		#endregion

		public ParameterDefinition (TypeReference parameterType)
			: this (string.Empty, ParameterAttributes.None, parameterType)
		{
		}

		public ParameterDefinition (string name, ParameterAttributes attributes, TypeReference parameterType)
			: base (name, parameterType)
		{
			this.attributes = (ushort) attributes;
			this.token = new MetadataToken (TokenType.Param);
		}

		public override ParameterDefinition Resolve ()
		{
			return this;
		}
	}
}
