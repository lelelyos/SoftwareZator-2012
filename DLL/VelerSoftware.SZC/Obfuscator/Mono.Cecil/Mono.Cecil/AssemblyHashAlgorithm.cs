// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************


namespace Mono.Cecil {

	public enum AssemblyHashAlgorithm : uint {
		None		= 0x0000,
		Reserved	= 0x8003,	// MD5
		SHA1		= 0x8004
	}
}
