// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System;
using M = VelerSoftware.SZC.VBNetParser.Ast.Modifiers;

namespace VelerSoftware.SZC.Debugger.Interfaces
{
    [Flags]
    public enum ModifierEnum // must be the same values as NRefactories' ModifierEnum
    {
        None = 0,

        // Access
        Private = M.Private,
        Internal = M.Internal, // == Friend
        Protected = M.Protected,
        Public = M.Public,
        Dim = M.Dim,	// VB.NET SPECIFIC

        // Scope
        Abstract = M.Abstract,  // == 	MustOverride/MustInherit
        Virtual = M.Virtual,
        Sealed = M.Sealed,
        Static = M.Static,
        Override = M.Override,
        Readonly = M.ReadOnly,
        Const = M.Const,
        New = M.New,  // == Shadows
        Partial = M.Partial,

        // Special
        Extern = M.Extern,
        Volatile = M.Volatile,
        Unsafe = M.Unsafe,
        Overloads = M.Overloads, // VB specific
        WithEvents = M.WithEvents, // VB specific
        Default = M.Default, // VB specific
        Fixed = M.Fixed,

        Synthetic = M.Synthetic,

        ProtectedAndInternal = Internal | Protected,
        VisibilityMask = Private | Internal | Protected | Public,
    }
}