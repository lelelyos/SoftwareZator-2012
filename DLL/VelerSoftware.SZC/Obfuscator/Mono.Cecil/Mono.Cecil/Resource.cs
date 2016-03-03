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

	public enum ResourceType {
		Linked,
		Embedded,
		AssemblyLinked,
	}

	public abstract class Resource : IAnnotationProvider {

		string name;
		uint attributes;

		public string Name {
			get { return name; }
			set { name = value; }
		}

		public ManifestResourceAttributes Attributes {
			get { return (ManifestResourceAttributes) attributes; }
			set { attributes = (uint) value; }
		}

		public abstract ResourceType ResourceType {
			get;
		}

		#region ManifestResourceAttributes

		public bool IsPublic {
			get { return attributes.GetMaskedAttributes ((uint) ManifestResourceAttributes.VisibilityMask, (uint) ManifestResourceAttributes.Public); }
			set { attributes = attributes.SetMaskedAttributes ((uint) ManifestResourceAttributes.VisibilityMask, (uint) ManifestResourceAttributes.Public, value); }
		}

		public bool IsPrivate {
			get { return attributes.GetMaskedAttributes ((uint) ManifestResourceAttributes.VisibilityMask, (uint) ManifestResourceAttributes.Private); }
			set { attributes = attributes.SetMaskedAttributes ((uint) ManifestResourceAttributes.VisibilityMask, (uint) ManifestResourceAttributes.Private, value); }
		}

		#endregion

		internal Resource (string name, ManifestResourceAttributes attributes)
		{
			this.name = name;
			this.attributes = (uint) attributes;
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
