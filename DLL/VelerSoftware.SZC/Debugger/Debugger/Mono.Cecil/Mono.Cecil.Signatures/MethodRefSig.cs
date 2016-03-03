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
    internal class MethodRefSig : MethodSig
    {
        public int Sentinel;

        public MethodRefSig()
            : this(0)
        {
        }

        public MethodRefSig(uint blobIndex)
            : base(blobIndex)
        {
            Sentinel = -1;
        }

        public override void Accept(ISignatureVisitor visitor)
        {
            visitor.VisitMethodRefSig(this);
        }
    }
}