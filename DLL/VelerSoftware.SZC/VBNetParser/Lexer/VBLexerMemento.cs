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
using System.Collections.Generic;

namespace VelerSoftware.SZC.VBNetParser.Parser.VB
{
	public sealed class VBLexerMemento : LexerMemento
	{
		public bool LineEnd { get; set; }
		public bool IsAtLineBegin { get; set; }
		public bool MisreadExclamationMarkAsTypeCharacter { get; set; }
		public bool EncounteredLineContinuation { get; set; }
		public ExpressionFinderState ExpressionFinder { get; set; }
		public Stack<XmlModeInfo> XmlModeInfoStack { get; set; }
		public bool InXmlMode { get; set; }
	}
}
