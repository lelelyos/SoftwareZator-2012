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

#if !READ_ONLY

using RVA = System.UInt32;

namespace Mono.Cecil.PE {

	enum TextSegment {
		ImportAddressTable,
		CLIHeader,
		Code,
		Resources,
		Data,
		StrongNameSignature,

		// Metadata
		MetadataHeader,
		TableHeap,
		StringHeap,
		UserStringHeap,
		GuidHeap,
		BlobHeap,
		// End Metadata

		DebugDirectory,
		ImportDirectory,
		ImportHintNameTable,
		StartupStub,
	}

	sealed class TextMap {

		readonly Range [] map = new Range [16 /*Enum.GetValues (typeof (TextSegment)).Length*/];

		public void AddMap (TextSegment segment, int length)
		{
			map [(int) segment] = new Range (GetStart (segment), (uint) length);
		}

		public void AddMap (TextSegment segment, int length, int align)
		{
			align--;

			AddMap (segment, (length + align) & ~align);
		}

		public void AddMap (TextSegment segment, Range range)
		{
			map [(int) segment] = range;
		}

		public Range GetRange (TextSegment segment)
		{
			return map [(int) segment];
		}

		public DataDirectory GetDataDirectory (TextSegment segment)
		{
			var range = map [(int) segment];

			return new DataDirectory (range.Length == 0 ? 0 : range.Start, range.Length);
		}

		public RVA GetRVA (TextSegment segment)
		{
			return map [(int) segment].Start;
		}

		public RVA GetNextRVA (TextSegment segment)
		{
			var i = (int) segment;
			return map [i].Start + map [i].Length;
		}

		public int GetLength (TextSegment segment)
		{
			return (int) map [(int) segment].Length;
		}

		RVA GetStart (TextSegment segment)
		{
			var index = (int) segment;
			return index == 0 ? ImageWriter.text_rva : ComputeStart (index);
		}

		RVA ComputeStart (int index)
		{
			index--;
			return map [index].Start + map [index].Length;
		}

		public uint GetLength ()
		{
			var range = map [(int) TextSegment.StartupStub];
			return range.Start - ImageWriter.text_rva + range.Length;
		}
	}
}

#endif
