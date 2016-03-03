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

using MD = Mono.Cecil.Metadata;

namespace Mono.Cecil {

	public interface IModifierType {
		TypeReference ModifierType { get; }
		TypeReference ElementType { get; }
	}

	public sealed class OptionalModifierType : TypeSpecification, IModifierType {

		TypeReference modifier_type;

		public TypeReference ModifierType {
			get { return modifier_type; }
			set { modifier_type = value; }
		}

		public override string Name {
			get { return base.Name + Suffix; }
		}

		public override string FullName {
			get { return base.FullName + Suffix; }
		}

		string Suffix {
			get { return " modopt(" + modifier_type + ")"; }
		}

		public override bool IsValueType {
			get { return false; }
			set { throw new InvalidOperationException (); }
		}

		public override bool IsOptionalModifier {
			get { return true; }
		}

		internal override bool ContainsGenericParameter {
			get { return modifier_type.ContainsGenericParameter || base.ContainsGenericParameter; }
		}

		public OptionalModifierType (TypeReference modifierType, TypeReference type)
			: base (type)
		{
			Mixin.CheckModifier (modifierType, type);
			this.modifier_type = modifierType;
			this.etype = MD.ElementType.CModOpt;
		}
	}

	public sealed class RequiredModifierType : TypeSpecification, IModifierType {

		TypeReference modifier_type;

		public TypeReference ModifierType {
			get { return modifier_type; }
			set { modifier_type = value; }
		}

		public override string Name {
			get { return base.Name + Suffix; }
		}

		public override string FullName {
			get { return base.FullName + Suffix; }
		}

		string Suffix {
			get { return " modreq(" + modifier_type + ")"; }
		}

		public override bool IsValueType {
			get { return false; }
			set { throw new InvalidOperationException (); }
		}

		public override bool IsRequiredModifier {
			get { return true; }
		}

		internal override bool ContainsGenericParameter {
			get { return modifier_type.ContainsGenericParameter || base.ContainsGenericParameter; }
		}

		public RequiredModifierType (TypeReference modifierType, TypeReference type)
			: base (type)
		{
			Mixin.CheckModifier (modifierType, type);
			this.modifier_type = modifierType;
			this.etype = MD.ElementType.CModReqD;
		}

	}

	static partial class Mixin {

		public static void CheckModifier (TypeReference modifierType, TypeReference type)
		{
			if (modifierType == null)
				throw new ArgumentNullException ("modifierType");
			if (type == null)
				throw new ArgumentNullException ("type");
		}
	}
}
