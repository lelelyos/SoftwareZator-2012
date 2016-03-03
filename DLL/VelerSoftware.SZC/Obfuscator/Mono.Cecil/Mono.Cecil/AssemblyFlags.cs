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
	public enum AssemblyAttributes : uint {
		PublicKey					 	= 0x0001,
		SideBySideCompatible			= 0x0000,
		Retargetable					= 0x0100,
		DisableJITCompileOptimizer		= 0x4000,
		EnableJITCompileTracking		= 0x8000,
	}
}
