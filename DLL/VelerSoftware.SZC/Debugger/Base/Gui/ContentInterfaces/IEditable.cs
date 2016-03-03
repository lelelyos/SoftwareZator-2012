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
    public interface IEditable
    {
        /// <summary>
        /// Creates a snapshot of the editor content.
        /// </summary>
        ITextBuffer CreateSnapshot();

        /// <summary>
        /// Gets the text in the view content.
        /// </summary>
        string Text
        {
            get;
        }
    }
}