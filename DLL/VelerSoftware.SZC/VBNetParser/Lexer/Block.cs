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
	public enum Context
	{
		Global,
		TypeDeclaration,
		ObjectCreation,
		ObjectInitializer,
		CollectionInitializer,
		Type,
		Member,
		Parameter,
		Identifier,
		Body,
		Xml,
		Attribute,
		Importable,
		Query,
		Expression,
		Debug,
		Default
	}
	
	public class Block : ICloneable
	{
		public static readonly Block Default = new Block() {
			context = Context.Global,
			lastExpressionStart = Location.Empty
		};
		
		public Context context;
		public Location lastExpressionStart;
		public bool isClosed;
		
		public override string ToString()
		{
			return string.Format("[Block Context={0}, LastExpressionStart={1}, IsClosed={2}]", context, lastExpressionStart, isClosed);
		}
		
		public object Clone()
		{
			return new Block() {
				context = this.context,
				lastExpressionStart = this.lastExpressionStart,
				isClosed = this.isClosed
			};
		}
	}
}
