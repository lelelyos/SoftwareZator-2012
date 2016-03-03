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

	public sealed class AssemblyNameDefinition : AssemblyNameReference {

		public override byte [] Hash {
			get { return Empty<byte>.Array; }
		}

		internal AssemblyNameDefinition ()
		{
			this.token = new MetadataToken (TokenType.Assembly, 1);
		}

		public AssemblyNameDefinition (string name, Version version)
			: base (name, version)
		{
			this.token = new MetadataToken (TokenType.Assembly, 1);
		}
	}
}
