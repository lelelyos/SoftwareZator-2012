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

namespace VelerSoftware.SZC.Debugger.Base.Bookmarks
{
    public delegate void BookmarkEventHandler(object sender, BookmarkEventArgs e);

    /// <summary>
    /// Description of BookmarkEventHandler.
    /// </summary>
    public class BookmarkEventArgs : EventArgs
    {
        SDBookmark bookmark;

        public SDBookmark Bookmark
        {
            get
            {
                return bookmark;
            }
        }

        public BookmarkEventArgs(SDBookmark bookmark)
        {
            this.bookmark = bookmark;
        }
    }
}