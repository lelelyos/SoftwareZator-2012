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
    /// The IPadContent interface is the basic interface to all "tool" windows
    /// in SharpDevelop.
    /// </summary>
    public interface IPadContent : IDisposable
    {
        /// <summary>
        /// This is the UI element for the view.
        /// You can use both Windows.Forms and WPF controls.
        /// </summary>
        object Control
        {
            get;
        }

        /// <summary>
        /// Gets the control which has focus initially.
        /// </summary>
        object InitiallyFocusedControl
        {
            get;
        }
    }
}