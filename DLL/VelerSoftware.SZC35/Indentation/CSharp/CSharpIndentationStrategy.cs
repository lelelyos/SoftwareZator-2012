﻿// *****************************************************************************
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
//     <version>$Revision: 5529 $</version>
// </file>

using System;
using VelerSoftware.SZC35.Document;

namespace VelerSoftware.SZC35.Indentation.CSharp
{
	/// <summary>
	/// Smart indentation for C#.
	/// </summary>
	public class CSharpIndentationStrategy : DefaultIndentationStrategy
	{
		/// <summary>
		/// Creates a new CSharpIndentationStrategy.
		/// </summary>
		public CSharpIndentationStrategy()
		{
		}
		
		/// <summary>
		/// Creates a new CSharpIndentationStrategy and initializes the settings using the text editor options.
		/// </summary>
		public CSharpIndentationStrategy(TextEditorOptions options)
		{
			this.IndentationString = options.IndentationString;
		}
		
		string indentationString = "\t";
		
		/// <summary>
		/// Gets/Sets the indentation string.
		/// </summary>
		public string IndentationString {
			get { return indentationString; }
			set {
				if (string.IsNullOrEmpty(value))
					throw new ArgumentException("Indentation string must not be null or empty");
				indentationString = value;
			}
		}
		
		/// <summary>
		/// Performs indentation using the specified document accessor.
		/// </summary>
		/// <param name="document">Object used for accessing the document line-by-line</param>
		/// <param name="keepEmptyLines">Specifies whether empty lines should be kept</param>
		public void Indent(IDocumentAccessor document, bool keepEmptyLines)
		{
			if (document == null)
				throw new ArgumentNullException("document");
			IndentationSettings settings = new IndentationSettings();
			settings.IndentString = this.IndentationString;
			settings.LeaveEmptyLines = keepEmptyLines;
			
			IndentationReformatter r = new IndentationReformatter();
			r.Reformat(document, settings);
		}
		
		/// <inheritdoc cref="IIndentationStrategy.IndentLine"/>
		public override void IndentLine(TextDocument document, DocumentLine line)
		{
			int lineNr = line.LineNumber;
			TextDocumentAccessor acc = new TextDocumentAccessor(document, lineNr, lineNr);
			Indent(acc, false);
			
			string t = acc.Text;
			if (t.Length == 0) {
				// use AutoIndentation for new lines in comments / verbatim strings.
				base.IndentLine(document, line);
			}
		}
		
		/// <inheritdoc cref="IIndentationStrategy.IndentLines"/>
		public override void IndentLines(TextDocument document, int beginLine, int endLine)
		{
			Indent(new TextDocumentAccessor(document, beginLine, endLine), true);
		}
	}
}
