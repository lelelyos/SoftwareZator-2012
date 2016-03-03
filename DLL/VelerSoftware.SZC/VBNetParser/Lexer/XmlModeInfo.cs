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

namespace VelerSoftware.SZC.VBNetParser.Parser.VB
{
	public class XmlModeInfo : ICloneable
	{
		public bool inXmlTag, inXmlCloseTag, isDocumentStart;
		public int level;
		
		public XmlModeInfo(bool isSpecial)
		{
			level = isSpecial ? -1 : 0;
			inXmlTag = inXmlCloseTag = isDocumentStart = false;
		}
		
		public object Clone()
		{
			return new XmlModeInfo(false) {
				inXmlCloseTag = this.inXmlCloseTag,
				inXmlTag = this.inXmlTag,
				isDocumentStart = this.isDocumentStart,
				level = this.level
			};
		}
	}
}
