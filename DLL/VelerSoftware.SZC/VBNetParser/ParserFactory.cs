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
using System.Text;
using VelerSoftware.SZC.VBNetParser.Parser;

namespace VelerSoftware.SZC.VBNetParser
{	
	/// <summary>
	/// Static helper class that constructs lexer and parser objects.
	/// </summary>
	public static class ParserFactory
	{
		public static Parser.ILexer CreateLexer(TextReader textReader)
		{
			return new VelerSoftware.SZC.VBNetParser.Parser.VB.Lexer(textReader);
			throw new System.NotSupportedException("VBNet not supported.");
		}
		
		public static Parser.ILexer CreateLexer(TextReader textReader, LexerMemento state)
		{
			return new VelerSoftware.SZC.VBNetParser.Parser.VB.Lexer(textReader, state);
			throw new System.NotSupportedException("VBNet not supported.");
		}
		
		public static IParser CreateParser(TextReader textReader)
		{
			Parser.ILexer lexer = CreateLexer(textReader);
			return new VelerSoftware.SZC.VBNetParser.Parser.VB.Parser(lexer);
			throw new System.NotSupportedException("VBNet not supported.");
		}
		
		public static IParser CreateParser(string fileName)
		{
			return CreateParser(fileName, Encoding.UTF8);
		}
		
		public static IParser CreateParser(string fileName, Encoding encoding)
		{
			string ext = Path.GetExtension(fileName);
			if (ext.Equals(".vb", StringComparison.OrdinalIgnoreCase))
            {
				return CreateParser(new StreamReader(fileName, encoding));
            }
			return null;
		}
	}
}
