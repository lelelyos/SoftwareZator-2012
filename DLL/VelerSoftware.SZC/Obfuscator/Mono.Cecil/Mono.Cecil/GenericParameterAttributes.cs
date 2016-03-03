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

namespace Mono.Cecil {

	[Flags]
	public enum GenericParameterAttributes : ushort {
		VarianceMask	= 0x0003,
		NonVariant		= 0x0000,
		Covariant		= 0x0001,
		Contravariant	= 0x0002,

		SpecialConstraintMask			= 0x001c,
		ReferenceTypeConstraint			= 0x0004,
		NotNullableValueTypeConstraint	= 0x0008,
		DefaultConstructorConstraint	= 0x0010
	}
}
