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

namespace VelerSoftware.SZC.VBNetParser.Parser.VB
{
	internal class ParamModifierList
	{
		ParameterModifiers cur;
		Parser   parser;
		
		public ParameterModifiers Modifier {
			get {
				return cur;
			}
		}
		
		public ParamModifierList(Parser parser)
		{
			this.parser = parser;
			cur         = ParameterModifiers.None;
		}
		
		public bool isNone { get { return cur == ParameterModifiers.None; } }
		
		public void Add(ParameterModifiers m) 
		{
			if ((cur & m) == 0) {
				cur |= m;
			} else {
				parser.Error("param modifier " + m + " already defined");
			}
		}
		
		public void Add(ParamModifierList m)
		{
			Add(m.cur);
		}
		
		public void Check()
		{
			if((cur & ParameterModifiers.In) != 0 && 
			   (cur & ParameterModifiers.Ref) != 0) {
				parser.Error("ByRef and ByVal are not allowed at the same time.");
			}
		}
	}
}
