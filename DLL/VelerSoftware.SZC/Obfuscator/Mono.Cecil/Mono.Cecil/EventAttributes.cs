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
	public enum EventAttributes : ushort {
		None			= 0x0000,
		SpecialName		= 0x0200,	// Event is special
		RTSpecialName	= 0x0400	 // CLI provides 'special' behavior, depending upon the name of the event
	}
}
