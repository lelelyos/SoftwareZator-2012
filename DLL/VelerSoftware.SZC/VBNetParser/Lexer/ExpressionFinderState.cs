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
using System.Linq;
using System.Text;

namespace VelerSoftware.SZC.VBNetParser.Parser.VB
{
	public class ExpressionFinderState
	{
		public bool WasQualifierTokenAtStart { get; set; }
		public bool NextTokenIsPotentialStartOfExpression { get; set; }
		public bool ReadXmlIdentifier { get; set; }
		public bool IdentifierExpected { get; set; }
		public bool NextTokenIsStartOfImportsOrAccessExpression { get; set; }
		public Stack<int> StateStack { get; set; }
		public Stack<Block> BlockStack { get; set; }
		public int CurrentState { get; set; }
	}
}
