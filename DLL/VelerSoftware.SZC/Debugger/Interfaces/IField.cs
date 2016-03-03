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
    public interface IField : IMember
    {
        /// <summary>Gets if this field is a local variable that has been converted into a field.</summary>
        bool IsLocalVariable { get; }

        /// <summary>Gets if this field is a parameter that has been converted into a field.</summary>
        bool IsParameter { get; }
    }
}