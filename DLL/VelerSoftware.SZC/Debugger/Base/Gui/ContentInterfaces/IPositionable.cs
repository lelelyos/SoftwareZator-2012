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
    /// If a IViewContent object is from the type IPositionable it signals
    /// that it's a texteditor which could set the caret to a position inside
    /// a file.
    /// </summary>
    public interface IPositionable
    {
        /// <summary>
        /// Sets the 'caret' to the position pos, where pos.Y is the line (starting from 1).
        /// And pos.X is the column (starting from 1 too).
        /// </summary>
        void JumpTo(int line, int column);

        /// <summary>
        /// gets the 'caret' position line (starting from 1)
        /// </summary>
        int Line
        {
            get;
        }

        /// <summary>
        /// gets the 'caret' position column (starting from 1)
        /// </summary>
        int Column
        {
            get;
        }
    }
}