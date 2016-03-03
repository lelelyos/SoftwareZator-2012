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

	public sealed class UserStringHeap : StringHeap {

		public UserStringHeap (Section section, uint start, uint size)
			: base (section, start, size)
		{
		}

		protected override string ReadStringAt (uint index)
		{
			byte [] data = Section.Data;
			int start = (int) (index + Offset);

			uint length = (uint) (data.ReadCompressedUInt32 (ref start) & ~1);
			if (length < 1)
				return string.Empty;

			var chars = new char [length / 2];

			for (int i = start, j = 0; i < start + length; i += 2)
				chars [j++] = (char) (data [i] | (data [i + 1] << 8));

			return new string (chars);
		}
	}
}
