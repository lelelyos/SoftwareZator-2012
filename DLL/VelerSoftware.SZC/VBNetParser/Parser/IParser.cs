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
using VelerSoftware.SZC.VBNetParser.Ast;

namespace VelerSoftware.SZC.VBNetParser
{
	/// <summary>
	/// Parser interface.
	/// </summary>
	public interface IParser : IDisposable
	{
		Parser.Errors Errors {
			get;
		}
		
		Parser.ILexer Lexer {
			get;
		}
		
		CompilationUnit CompilationUnit {
			get;
		}
		
		bool ParseMethodBodies {
			get; set;
		}
		
		void Parse();
		
		Expression ParseExpression();
		TypeReference ParseTypeReference ();
		BlockStatement ParseBlock();
		List<INode> ParseTypeMembers();
	}
}
