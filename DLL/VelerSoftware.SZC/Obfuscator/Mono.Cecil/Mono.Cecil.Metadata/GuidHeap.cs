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

	public sealed class GuidHeap : Heap {

		public GuidHeap (Section section, uint start, uint size)
			: base (section, start, size)
		{
		}

		public Guid Read (uint index)
		{
			if (index == 0)
				return new Guid ();

			const int guid_size = 16;

			var buffer = new byte [guid_size];

			index--;

			Buffer.BlockCopy (Section.Data, (int) (Offset + index), buffer, 0, guid_size);

			return new Guid (buffer);

		}
	}
}
