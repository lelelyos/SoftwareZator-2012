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
using System.Collections.Generic;
using System.Text;

using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata {

	public class StringHeap : Heap {

		readonly Dictionary<uint, string> strings = new Dictionary<uint, string> ();

		public StringHeap (Section section, uint start, uint size)
			: base (section, start, size)
		{
		}

		public string Read (uint index)
		{
			if (index == 0)
				return string.Empty;

			string @string;
			if (strings.TryGetValue (index, out @string))
				return @string;

			if (index > Size - 1)
				return string.Empty;

			@string = ReadStringAt (index);
			if (@string.Length != 0)
				strings.Add (index, @string);

			return @string;
		}

		protected virtual string ReadStringAt (uint index)
		{
			int length = 0;
			byte [] data = Section.Data;
			int start = (int) (index + Offset);

			for (int i = start; ; i++) {
				if (data [i] == 0)
					break;

				length++;
			}

			return Encoding.UTF8.GetString (data, start, length);
		}
	}
}
