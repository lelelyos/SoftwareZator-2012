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

namespace VelerSoftware.SZC.VBNetParser.PrettyPrinter
{
	/// <summary>
	/// Description of VBNetPrettyPrintOptions.
	/// </summary>
	public class VBNetPrettyPrintOptions : AbstractPrettyPrintOptions
	{
		/// <summary>
		/// Gets/Sets if the optional "ByVal" modifier should be written.
		/// </summary>
		public bool OutputByValModifier { get; set; }
	}
}
