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
using System.IO;

namespace Mono.Cecil.PE {

	public class BinaryStreamReader : BinaryReader {

		public BinaryStreamReader (Stream stream)
			: base (stream)
		{
		}

		protected void Advance (int bytes)
		{
			BaseStream.Seek (bytes, SeekOrigin.Current);
		}

		protected DataDirectory ReadDataDirectory ()
		{
			return new DataDirectory (ReadUInt32 (), ReadUInt32 ());
		}
	}
}
