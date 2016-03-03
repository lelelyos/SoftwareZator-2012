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

namespace VelerSoftware.SZC.Debugger.Base.Gui
{
    /// <summary>
    /// Interface for classes that implement the IsDirty property and the DirtyChanged event.
    /// </summary>
    public interface ICanBeDirty
    {
        /// <summary>
        /// If this property returns true the content has changed since
        /// the last load/save operation.
        /// </summary>
        bool IsDirty
        {
            get;
        }

        /// <summary>
        /// Is called when the content is changed after a save/load operation
        /// and this signals that changes could be saved.
        /// </summary>
        event EventHandler IsDirtyChanged;
    }
}