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

namespace VelerSoftware.SZC.VBNetParser.Parser
{
	public abstract class LexerMemento
	{
		public int Line { get; set; }
		public int Column { get; set; }
		public int PrevTokenKind { get; set; }
	}
}
