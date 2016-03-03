// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <author name="Daniel Grunwald"/>
//     <version>$Revision: 3635 $</version>
// </file>

using System;
using System.Runtime.Serialization;

namespace VelerSoftware.SZC35.Highlighting
{
	/// <summary>
	/// Indicates that the highlighting definition that was tried to load was invalid.
	/// </summary>
	[Serializable()]
	public class HighlightingDefinitionInvalidException : Exception
	{
		/// <summary>
		/// Creates a new HighlightingDefinitionInvalidException instance.
		/// </summary>
		public HighlightingDefinitionInvalidException() : base()
		{
		}
		
		/// <summary>
		/// Creates a new HighlightingDefinitionInvalidException instance.
		/// </summary>
		public HighlightingDefinitionInvalidException(string message) : base(message)
		{
		}
		
		/// <summary>
		/// Creates a new HighlightingDefinitionInvalidException instance.
		/// </summary>
		public HighlightingDefinitionInvalidException(string message, Exception innerException) : base(message, innerException)
		{
		}
		
		/// <summary>
		/// Creates a new HighlightingDefinitionInvalidException instance.
		/// </summary>
		protected HighlightingDefinitionInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
