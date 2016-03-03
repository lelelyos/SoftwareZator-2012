// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




namespace VelerSoftware.SZC.Debugger.Interfaces
{
    public enum ClassType
    {
        Class = VelerSoftware.SZC.VBNetParser.Ast.ClassType.Class,
        Enum = VelerSoftware.SZC.VBNetParser.Ast.ClassType.Enum,
        Interface = VelerSoftware.SZC.VBNetParser.Ast.ClassType.Interface,
        Struct = VelerSoftware.SZC.VBNetParser.Ast.ClassType.Struct,
        Delegate = 0x5,
        Module = VelerSoftware.SZC.VBNetParser.Ast.ClassType.Module
    }
}