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

using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata {

	public sealed class BlobHeap : Heap {

		public BlobHeap (Section section, uint start, uint size)
			: base (section, start, size)
		{
		}

		public byte [] Read (uint index)
		{
			if (index == 0 || index > Size - 1)
				return Empty<byte>.Array;

			var data = Section.Data;

			int position = (int) (index + Offset);
			int length = (int) data.ReadCompressedUInt32 (ref position);

			var buffer = new byte [length];

			Buffer.BlockCopy (data, position, buffer, 0, length);

			return buffer;
		}
	}
}
