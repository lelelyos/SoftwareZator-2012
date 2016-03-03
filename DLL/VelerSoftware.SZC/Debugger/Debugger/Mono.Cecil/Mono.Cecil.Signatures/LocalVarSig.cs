// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************



namespace VelerSoftware.SZC.Debugger.Debugger.Mono.Cecil.Signatures
{
    internal sealed class LocalVarSig : Signature
    {
        public bool Local;
        public int Count;
        public LocalVariable[] LocalVariables;

        public LocalVarSig()
            : base()
        {
        }

        public LocalVarSig(uint blobIndex)
            : base(blobIndex)
        {
        }

        public override void Accept(ISignatureVisitor visitor)
        {
            visitor.VisitLocalVarSig(this);
        }

        public struct LocalVariable
        {
            public CustomMod[] CustomMods;
            public Constraint Constraint;
            public bool ByRef;
            public SigType Type;
        }
    }
}