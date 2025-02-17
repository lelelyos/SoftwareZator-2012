// *****************************************************************************
// 
//  � Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

namespace VelerSoftware.SZC.Debugger.Debugger.Mono.Cecil.Signatures
{
    using VelerSoftware.SZC.Debugger.Debugger.Mono.Cecil.Metadata;

    internal sealed class MVAR : SigType
    {
        public int Index;

        public MVAR(int index)
            : base(ElementType.MVar)
        {
            this.Index = index;
        }
    }
}