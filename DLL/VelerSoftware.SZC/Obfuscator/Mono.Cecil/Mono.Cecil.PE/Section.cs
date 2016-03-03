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

	public sealed class Section {
		public string Name;
		public RVA VirtualAddress;
		public uint VirtualSize;
		public uint SizeOfRawData;
		public uint PointerToRawData;
		public byte [] Data;
        public uint Characteristics;
	}
}
