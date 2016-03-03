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
//     <version>$Revision: 4973 $</version>
// </file>

using VelerSoftware.SZC35.Utils;
using System;
using VelerSoftware.SZC35.Document;

namespace VelerSoftware.SZC35.Indentation
{
	/// <summary>
	/// Handles indentation by copying the indentation from the previous line.
	/// Does not support indenting multiple lines.
	/// </summary>
	public class DefaultIndentationStrategy : IIndentationStrategy
	{
		/// <inheritdoc/>
		public virtual void IndentLine(TextDocument document, DocumentLine line)
		{
			if (document == null)
				throw new ArgumentNullException("document");
			if (line == null)
				throw new ArgumentNullException("line");
			DocumentLine previousLine = line.PreviousLine;
			if (previousLine != null) {
				ISegment indentationSegment = TextUtilities.GetWhitespaceAfter(document, previousLine.Offset);
				string indentation = document.GetText(indentationSegment);
				// copy indentation to line
				indentationSegment = TextUtilities.GetWhitespaceAfter(document, line.Offset);
				document.Replace(indentationSegment, indentation);
			}
		}
		
		/// <summary>
		/// Does nothing: indenting multiple lines is useless without a smart indentation strategy.
		/// </summary>
		public virtual void IndentLines(TextDocument document, int beginLine, int endLine)
		{
		}
	}
}
