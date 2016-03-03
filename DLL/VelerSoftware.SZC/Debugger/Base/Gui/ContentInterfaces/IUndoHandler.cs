// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




namespace VelerSoftware.SZC.Debugger.Base.Gui
{
    /// <summary>
    /// This interface is meant for Windows-Forms AddIns to preserve the undo handling functionality as in SharpDevelop 3.0.
    /// It works only for controls inside a <see cref="SDWindowsFormsHost"/>.
    /// WPF AddIns should handle the routed commands 'Undo' and 'Redo' instead.
    /// </summary>
    public interface IUndoHandler
    {
        bool EnableUndo
        {
            get;
        }

        bool EnableRedo
        {
            get;
        }

        void Undo();

        void Redo();
    }
}