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
    internal sealed class MethodDefSig : MethodRefSig
    {
        public int GenericParameterCount;

        public MethodDefSig()
            : this(0)
        {
        }

        public MethodDefSig(uint blobIndex)
            : base(blobIndex)
        {
        }

        public override void Accept(ISignatureVisitor visitor)
        {
            visitor.VisitMethodDefSig(this);
        }
    }
}