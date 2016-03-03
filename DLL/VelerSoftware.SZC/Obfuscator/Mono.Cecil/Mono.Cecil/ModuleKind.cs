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

	public enum ModuleKind {
		Dll,
		Console,
		Windows,
		NetModule,
	}

	public enum TargetArchitecture {
		I386,
		AMD64,
		IA64,
	}

	[Flags]
	public enum ModuleAttributes {
		ILOnly = 1,
		Required32Bit = 2,
		StrongNameSigned = 8,
	}
}
