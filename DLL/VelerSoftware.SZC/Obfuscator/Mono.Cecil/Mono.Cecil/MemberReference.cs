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

	public abstract class MemberReference : IMetadataTokenProvider, IAnnotationProvider {

		string name;
		TypeReference declaring_type;

		internal MetadataToken token;

		public virtual string Name {
			get { return name; }
			set { name = value; }
		}

		public abstract string FullName {
			get;
		}

		public virtual TypeReference DeclaringType {
			get { return declaring_type; }
			set { declaring_type = value; }
		}

		public MetadataToken MetadataToken {
			get { return token; }
			set { token = value; }
		}

		internal bool HasImage {
			get {
				var module = Module;
				if (module == null)
					return false;

				return module.HasImage;
			}
		}

		public virtual ModuleDefinition Module {
			get { return declaring_type != null ? declaring_type.Module : null; }
		}

		public virtual bool IsDefinition {
			get { return false; }
		}

		internal virtual bool ContainsGenericParameter {
			get { return declaring_type != null && declaring_type.ContainsGenericParameter; }
		}

		internal MemberReference ()
		{
		}

		internal MemberReference (string name)
		{
			this.name = name ?? string.Empty;
		}

		internal string MemberFullName ()
		{
			if (declaring_type == null)
				return name;

			return declaring_type.FullName + "::" + name;
		}

		public override string ToString ()
		{
			return FullName;
        }

        System.Collections.IDictionary m_annotations;
        System.Collections.IDictionary IAnnotationProvider.Annotations
        {
            get
            {
                if (m_annotations == null)
                    m_annotations = new System.Collections.Hashtable();
                return m_annotations;
            }
        }
	}
}
