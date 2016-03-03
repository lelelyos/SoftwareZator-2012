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
	public enum MethodSemanticsAttributes : ushort {
		None		= 0x0000,
		Setter		= 0x0001,	// Setter for property
		Getter		= 0x0002,	// Getter for property
		Other		= 0x0004,	// Other method for property or event
		AddOn		= 0x0008,	// AddOn method for event
		RemoveOn	= 0x0010,	// RemoveOn method for event
		Fire		= 0x0020	 // Fire method for event
	}
}
