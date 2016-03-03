// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************


using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata {

	public abstract class Heap {

		public int IndexSize;

		public readonly Section Section;
		public readonly uint Offset;
		public readonly uint Size;

		protected Heap (Section section, uint offset, uint size)
		{
			this.Section = section;
			this.Offset = offset;
			this.Size = size;
		}
	}
}
