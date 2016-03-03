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
//     <version>$Revision: 4142 $</version>
// </file>

using System;
using System.Runtime.Serialization;

namespace VelerSoftware.SZC35.Editing
{
	/// <summary>
	/// Wraps exceptions that occur during drag'n'drop.
	/// Exceptions during drag'n'drop might
	/// get swallowed by WPF/COM, so SZC35 catches them and re-throws them later
	/// wrapped in a DragDropException.
	/// </summary>
	[Serializable()]
	public class DragDropException : Exception
	{
		/// <summary>
		/// Creates a new DragDropException.
		/// </summary>
		public DragDropException() : base()
		{
		}
		
		/// <summary>
		/// Creates a new DragDropException.
		/// </summary>
		public DragDropException(string message) : base(message)
		{
		}
		
		/// <summary>
		/// Creates a new DragDropException.
		/// </summary>
		public DragDropException(string message, Exception innerException) : base(message, innerException)
		{
		}
		
		/// <summary>
		/// Deserializes a DragDropException.
		/// </summary>
		protected DragDropException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
