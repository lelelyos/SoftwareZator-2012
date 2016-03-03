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

namespace VelerSoftware.SZC.VBNetParser.Parser
{
	public class SavepointEventArgs : EventArgs
	{
		public Location SavepointLocation { get; private set; }
		public LexerMemento State { get; private set; }
		
		public SavepointEventArgs(Location savepointLocation, LexerMemento state)
		{
			this.SavepointLocation = savepointLocation;
			this.State = state;
		}
	}
}
