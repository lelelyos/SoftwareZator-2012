// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;

namespace VelerSoftware.SZC.Debugger.Base.Bookmarks
{
    /// <summary>
    /// The bookmark margin.
    /// </summary>
    public interface IBookmarkMargin
    {
        /// <summary>
        /// Gets the list of bookmarks.
        /// </summary>
        IList<IBookmark> Bookmarks { get; }

        /// <summary>
        /// Redraws the bookmark margin. Bookmarks need to call this method when the Image changes.
        /// </summary>
        void Redraw();
    }

    /// <summary>
    /// Represents a bookmark in the bookmark margin.
    /// </summary>
    public interface IBookmark
    {
        /// <summary>
        /// Gets the line number of the bookmark.
        /// </summary>
        int LineNumber { get; }

        /// <summary>
        /// Gets the image.
        /// </summary>
        Image Image { get; }

        /// <summary>
        /// Gets the Z-Order of the bookmark icon.
        /// </summary>
        int ZOrder { get; }

        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        void MouseDown(MouseButtonEventArgs e);

        /// <summary>
        /// Handles the mouse up event.
        /// </summary>
        void MouseUp(MouseButtonEventArgs e);

        /// <summary>
        /// Gets whether this bookmark can be dragged around.
        /// </summary>
        bool CanDragDrop { get; }

        /// <summary>
        /// Notifies the bookmark that it was dropped on the specified line.
        /// </summary>
        void Drop(int lineNumber);
    }
}