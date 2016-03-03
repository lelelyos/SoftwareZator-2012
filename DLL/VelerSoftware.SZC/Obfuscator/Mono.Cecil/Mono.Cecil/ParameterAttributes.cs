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
	public enum ParameterAttributes : ushort {
		None				= 0x0000,
		In					= 0x0001,	// Param is [In]
		Out					= 0x0002,	// Param is [Out]
		Lcid				= 0x0004,
		Retval				= 0x0008,
		Optional			= 0x0010,	// Param is optional
		HasDefault			= 0x1000,	// Param has default value
		HasFieldMarshal		= 0x2000,	// Param has field marshal
		Unused				= 0xcfe0	 // Reserved: shall be zero in a conforming implementation
	}
}
