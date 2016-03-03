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

	public sealed class PointerType : TypeSpecification {

		public override string Name {
			get { return base.Name + "*"; }
		}

		public override string FullName {
			get { return base.FullName + "*"; }
		}

		public override bool IsValueType {
			get { return false; }
			set { throw new InvalidOperationException (); }
		}

		public override bool IsPointer {
			get { return true; }
		}

		public PointerType (TypeReference type)
			: base (type)
		{
			Mixin.CheckType (type);
			this.etype = MD.ElementType.Ptr;
		}
	}
}
