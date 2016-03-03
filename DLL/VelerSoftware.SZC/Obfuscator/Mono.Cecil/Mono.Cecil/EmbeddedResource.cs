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

namespace Mono.Cecil {

	public sealed class EmbeddedResource : Resource {

		readonly MetadataReader reader;

		uint? offset;
		byte [] data;
		Stream stream;

		public override ResourceType ResourceType {
			get { return ResourceType.Embedded; }
		}

		public EmbeddedResource (string name, ManifestResourceAttributes attributes, byte [] data) :
			base (name, attributes)
		{
			this.data = data;
		}

		public EmbeddedResource (string name, ManifestResourceAttributes attributes, Stream stream) :
			base (name, attributes)
		{
			this.stream = stream;
		}

		internal EmbeddedResource (string name, ManifestResourceAttributes attributes, uint offset, MetadataReader reader)
			: base (name, attributes)
		{
			this.offset = offset;
			this.reader = reader;
		}

		public Stream GetResourceStream ()
		{
			if (stream != null)
				return stream;

			if (data != null)
				return new MemoryStream (data);

			if (offset.HasValue)
				return reader.GetManagedResourceStream (offset.Value);

			throw new InvalidOperationException ();
		}

		public byte [] GetResourceData ()
		{
			if (stream != null)
				return ReadStream (stream);

			if (data != null)
				return data;

			if (offset.HasValue)
				return reader.GetManagedResourceStream (offset.Value).ToArray ();

			throw new InvalidOperationException ();
		}

		static byte [] ReadStream (Stream stream)
		{
			var length = (int) stream.Length;
			var data = new byte [length];
			int offset = 0, read;

			while ((read = stream.Read (data, offset, length - offset)) > 0)
				offset += read;

			return data;
		}
	}
}
