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

namespace VelerSoftware.SZC.Debugger.Core
{
    /// <summary>
    /// A basic command interface. A command has simply an owner which "runs" the command
    /// and a Run method which invokes the command.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Returns the owner of the command.
        /// </summary>
        object Owner
        {
            get;
            set;
        }

        /// <summary>
        /// Invokes the command.
        /// </summary>
        void Run();

        /// <summary>
        /// Is called when the Owner property is changed.
        /// </summary>
        event EventHandler OwnerChanged;
    }
}