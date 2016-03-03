// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

//
// MethodCallingConvention.cs

namespace Mono.Cecil {

	public enum MethodCallingConvention : byte {
		Default		= 0x0,
		C			= 0x1,
		StdCall		= 0x2,
		ThisCall	= 0x3,
		FastCall	= 0x4,
		VarArg		= 0x5,
		Generic		= 0x10,
	}
}
