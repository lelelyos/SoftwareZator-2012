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
    internal abstract class BaseSignatureVisitor : ISignatureVisitor
    {
        public virtual void VisitMethodDefSig(MethodDefSig methodDef)
        {
        }

        public virtual void VisitMethodRefSig(MethodRefSig methodRef)
        {
        }

        public virtual void VisitFieldSig(FieldSig field)
        {
        }

        public virtual void VisitPropertySig(PropertySig property)
        {
        }

        public virtual void VisitLocalVarSig(LocalVarSig localvar)
        {
        }
    }
}