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

	public sealed class AssemblyLinkedResource : Resource {

		AssemblyNameReference reference;

		public AssemblyNameReference Assembly {
			get { return reference; }
			set { reference = value; }
		}

		public override ResourceType ResourceType {
			get { return ResourceType.AssemblyLinked; }
		}

		public AssemblyLinkedResource (string name, ManifestResourceAttributes flags)
			: base (name, flags)
		{
		}

		public AssemblyLinkedResource (string name, ManifestResourceAttributes flags, AssemblyNameReference reference)
			: base (name, flags)
		{
			this.reference = reference;
		}
	}
}
