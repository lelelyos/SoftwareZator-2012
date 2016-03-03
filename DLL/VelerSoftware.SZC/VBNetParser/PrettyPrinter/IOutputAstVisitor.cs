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
using VelerSoftware.SZC.VBNetParser.Parser;
using VelerSoftware.SZC.VBNetParser.Ast;

namespace VelerSoftware.SZC.VBNetParser.PrettyPrinter
{
	/// <summary>
	/// Description of IOutputASTVisitor.
	/// </summary>
	public interface IOutputAstVisitor : IAstVisitor
	{
		event Action<INode> BeforeNodeVisit;
		event Action<INode> AfterNodeVisit;
		
		string Text {
			get;
		}
		
		Errors Errors {
			get;
		}
		
		AbstractPrettyPrintOptions Options {
			get;
		}
		IOutputFormatter OutputFormatter {
			get;
		}
	}
	public interface IOutputFormatter
	{
		int IndentationLevel {
			get;
			set;
		}
		string Text {
			get;
		}
		bool IsInMemberBody {
			get;
			set;
		}
		void NewLine();
		void Indent();
		void PrintComment(Comment comment, bool forceWriteInPreviousBlock);
		void PrintPreprocessingDirective(PreprocessingDirective directive, bool forceWriteInPreviousBlock);
		void PrintBlankLine(bool forceWriteInPreviousBlock);
	}
}
