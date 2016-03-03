// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************


namespace Mono.Cecil {

	public sealed class LinkedResource : Resource {

		internal byte [] hash;
		string file;

		public byte [] Hash {
			get { return hash; }
		}

		public string File {
			get { return file; }
			set { file = value; }
		}

		public override ResourceType ResourceType {
			get { return ResourceType.Linked; }
		}

		public LinkedResource (string name, ManifestResourceAttributes flags)
			: base (name, flags)
		{
		}

		public LinkedResource (string name, ManifestResourceAttributes flags, string file)
			: base (name, flags)
		{
			this.file = file;
		}
	}
}
