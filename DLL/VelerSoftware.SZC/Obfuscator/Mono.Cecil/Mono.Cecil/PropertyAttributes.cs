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
	public enum PropertyAttributes : ushort {
		None			= 0x0000,
		SpecialName		= 0x0200,	// Property is special
		RTSpecialName	= 0x0400,	// Runtime(metadata internal APIs) should check name encoding
		HasDefault		= 0x1000,	// Property has default
		Unused			= 0xe9ff	 // Reserved: shall be zero in a conforming implementation
	}
}
