// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System.Drawing.Printing;

namespace VelerSoftware.SZC.Debugger.Base.Gui
{
    /// <summary>
    /// This interface is meant for Windows-Forms AddIns to preserve the printing functionality as in SharpDevelop 3.0.
    /// It works only for controls inside a <see cref="SDWindowsFormsHost"/>.
    /// WPF AddIns should handle the routed commands 'Print' and 'PrintPreview' instead.
    ///
    /// If a IViewContent object is from the type IPrintable it signals
    /// that it's contents could be printed to a printer, fax etc.
    /// </summary>
    public interface IPrintable
    {
        /// <summary>
        /// Returns the PrintDocument for this object, see the .NET reference
        /// for more information about printing.
        /// </summary>
        PrintDocument PrintDocument
        {
            get;
        }
    }
}