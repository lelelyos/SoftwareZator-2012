// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************


namespace Mono.Cecil.Cil {

	public sealed class VariableDefinition : VariableReference {

		public bool IsPinned {
			get { return variable_type.IsPinned; }
		}

		public VariableDefinition (TypeReference variableType)
			: base (variableType)
		{
		}

		public VariableDefinition (string name, TypeReference variableType)
			: base (name, variableType)
		{
		}

		public override VariableDefinition Resolve ()
		{
			return this;
		}
	}
}
