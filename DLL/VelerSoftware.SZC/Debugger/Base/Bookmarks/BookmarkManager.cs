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
using System.Collections.Generic;
using VelerSoftware.SZC.Debugger.Base.Editor;
using VelerSoftware.SZC.Debugger.Core;
using VelerSoftware.SZC.VBNetParser;

namespace VelerSoftware.SZC.Debugger.Base.Bookmarks
{
    /// <summary>
    /// Static class that maintains the list of bookmarks and breakpoints.
    /// </summary>
    public static class BookmarkManager
    {
        static List<SDBookmark> bookmarks = new List<SDBookmark>();

        public static List<SDBookmark> Bookmarks
        {
            get
            {
                return bookmarks;
            }
        }

        public static List<SDBookmark> GetBookmarks(FileName fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");

            List<SDBookmark> marks = new List<SDBookmark>();

            foreach (SDBookmark mark in bookmarks)
            {
                if (fileName == mark.FileName)
                {
                    marks.Add(mark);
                }
            }

            return marks;
        }

        public static void AddMark(SDBookmark bookmark)
        {
            if (bookmark == null) return;
            if (bookmarks.Contains(bookmark)) return;
            if (bookmarks.Exists(b => IsEqualBookmark(b, bookmark))) return;
            bookmarks.Add(bookmark);
            OnAdded(new BookmarkEventArgs(bookmark));
        }

        private static bool IsEqualBookmark(SDBookmark a, SDBookmark b)
        {
            if (a == b)
                return true;
            if (a == null || b == null)
                return false;
            if (a.GetType() != b.GetType())
                return false;
            if (a.FileName != b.FileName)
                return false;
            return a.LineNumber == b.LineNumber;
        }

        public static void RemoveMark(SDBookmark bookmark)
        {
            bookmarks.Remove(bookmark);
            OnRemoved(new BookmarkEventArgs(bookmark));
        }

        public static void Clear()
        {
            while (bookmarks.Count > 0)
            {
                SDBookmark b = bookmarks[bookmarks.Count - 1];
                bookmarks.RemoveAt(bookmarks.Count - 1);
                OnRemoved(new BookmarkEventArgs(b));
            }
        }

        internal static void Initialize()
        {
        }

        private static void OnRemoved(BookmarkEventArgs e)
        {
            if (Removed != null)
            {
                Removed(null, e);
            }
        }

        private static void OnAdded(BookmarkEventArgs e)
        {
            if (Added != null)
            {
                Added(null, e);
            }
        }

        public static void ToggleBookmark(ITextEditor editor, int line,
                                          Predicate<SDBookmark> canToggle,
                                          Func<Location, SDBookmark> bookmarkFactory)
        {
            foreach (SDBookmark bookmark in GetBookmarks(new FileName(editor.FileName)))
            {
                if (canToggle(bookmark) && bookmark.LineNumber == line)
                {
                    BookmarkManager.RemoveMark(bookmark);
                    return;
                }
            }
        }

        public static event BookmarkEventHandler Removed;
        public static event BookmarkEventHandler Added;
    }
}