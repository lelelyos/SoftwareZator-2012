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
    internal abstract class InputOutputItem
    {
        public CustomMod[] CustomMods;
        public bool ByRef;
        public SigType Type;
        public bool TypedByRef;
    }
}