// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using VelerSoftware.SZC.VBNetParser.Ast;

namespace VelerSoftware.SZC.VBNetParser.Parser
{
	internal class ModifierList
	{
		Modifiers cur;
		Location location = new Location(-1, -1);
		
		public Modifiers Modifier {
			get {
				return cur;
			}
		}
		
		public Location GetDeclarationLocation(Location keywordLocation)
		{
			if(location.IsEmpty) {
				return keywordLocation;
			}
			return location;
		}
		
//		public Location Location {
//			get {
//				return location;
//			}
//			set {
//				location = value;
//			}
//		}
		
		public bool isNone { get { return cur == Modifiers.None; } }
		
		public bool Contains(Modifiers m)
		{
			return ((cur & m) != 0);
		}
		
		public void Add(Modifiers m, Location tokenLocation) 
		{
			if(location.IsEmpty) {
				location = tokenLocation;
			}
			
			if ((cur & m) == 0) {
				cur |= m;
			} else {
//				parser.Error("modifier " + m + " already defined");
			}
		}
		
//		public void Add(Modifiers m)
//		{
//			Add(m.cur, m.Location);
//		}
		
		public void Check(Modifiers allowed)
		{
			Modifiers wrong = cur & ~allowed;
			if (wrong != Modifiers.None) {
//				parser.Error("modifier(s) " + wrong + " not allowed here");
			}
		}
	}
}
