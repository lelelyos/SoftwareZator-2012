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

	public class ModuleReference : IMetadataScope {

		string name;

		internal MetadataToken token;

		public string Name {
			get { return name; }
			set { name = value; }
		}

		public virtual MetadataScopeType MetadataScopeType {
			get { return MetadataScopeType.ModuleReference; }
		}

		public MetadataToken MetadataToken {
			get { return token; }
			set { token = value; }
		}

		internal ModuleReference ()
		{
			this.token = new MetadataToken (TokenType.ModuleRef);
		}

		public ModuleReference (string name)
			: this ()
		{
			this.name = name;
		}

		public override string ToString ()
		{
			return name;
		}
	}
}
