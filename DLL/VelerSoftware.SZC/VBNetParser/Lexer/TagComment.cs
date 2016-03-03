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
	/// <summary>
	/// Description of TagComment.	
	/// </summary>
	public class TagComment : Comment
	{
		string tag;
		
		public string Tag {
			get {
				return tag;
			}
			set {
				tag = value;
			}
		}
		
		public TagComment(string tag, string comment, bool commentStartsLine, Location startPosition, Location endPosition) : base(CommentType.SingleLine, comment, commentStartsLine, startPosition, endPosition)
		{
			this.tag = tag;
		}
	}
}
