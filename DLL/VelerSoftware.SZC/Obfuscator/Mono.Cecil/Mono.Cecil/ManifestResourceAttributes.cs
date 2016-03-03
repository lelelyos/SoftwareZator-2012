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
	public enum ManifestResourceAttributes : uint {
		VisibilityMask	= 0x0007,
		Public			= 0x0001,	// The resource is exported from the Assembly
		Private			= 0x0002	 // The resource is private to the Assembly
	}
}
