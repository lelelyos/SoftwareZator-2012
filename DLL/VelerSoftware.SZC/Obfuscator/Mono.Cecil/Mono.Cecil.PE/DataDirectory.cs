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

using RVA = System.UInt32;

namespace Mono.Cecil.PE {

	public struct DataDirectory {

		public readonly RVA VirtualAddress;
		public readonly uint Size;

		public bool IsZero {
			get { return VirtualAddress == 0 && Size == 0; }
		}

		public DataDirectory (RVA rva, uint size)
		{
			this.VirtualAddress = rva;
			this.Size = size;
		}
	}
}
