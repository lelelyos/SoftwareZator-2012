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

using Mono.Cecil.Metadata;

namespace Mono.Cecil {

	public abstract class TypeSpecification : TypeReference {

		readonly TypeReference element_type;

		public TypeReference ElementType {
			get { return element_type; }
		}

		public override string Name {
			get { return element_type.Name; }
			set { throw new NotSupportedException (); }
		}

		public override string Namespace {
			get { return element_type.Namespace; }
			set { throw new NotSupportedException (); }
		}

		public override IMetadataScope Scope {
			get { return element_type.Scope; }
		}

		public override ModuleDefinition Module {
			get { return element_type.Module; }
		}

		public override string FullName {
			get { return element_type.FullName; }
		}

		internal override bool ContainsGenericParameter {
			get { return element_type.ContainsGenericParameter; }
		}

		public override MetadataType MetadataType {
			get { return (MetadataType) etype; }
		}

		internal TypeSpecification (TypeReference type)
			: base (null, null)
		{
			this.element_type = type;
			this.token = new MetadataToken (TokenType.TypeSpec);
		}

		public override TypeReference GetElementType ()
		{
			return element_type.GetElementType ();
		}
	}

	static partial class Mixin {

		public static void CheckType (TypeReference type)
		{
			if (type == null)
				throw new ArgumentNullException ("type");
		}
	}
}
