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
using System.ComponentModel;
using VelerSoftware.SZC.Debugger.Core;
using VelerSoftware.SZC.VBNetParser;

namespace VelerSoftware.SZC.Debugger.Base.Bookmarks
{
    /// <summary>
    /// A bookmark that is persistant across SharpDevelop sessions.
    /// </summary>
    [TypeConverter(typeof(BookmarkConverter))]
    public class SDBookmark : BookmarkBase
    {
        public SDBookmark(FileName fileName, Location location)
            : base(location)
        {
            this.fileName = fileName;
        }

        FileName fileName;

        public FileName FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                if (fileName != value)
                {
                    fileName = value;
                    OnFileNameChanged(EventArgs.Empty);
                }
            }
        }

        public event EventHandler FileNameChanged;

        protected virtual void OnFileNameChanged(EventArgs e)
        {
            if (FileNameChanged != null)
            {
                FileNameChanged(this, e);
            }
        }

        public event EventHandler LineNumberChanged;

        internal void RaiseLineNumberChanged()
        {
            if (LineNumberChanged != null)
                LineNumberChanged(this, EventArgs.Empty);
        }

        bool isSaved = true;

        /// <summary>
        /// Gets/Sets if the bookmark should be saved to the project memento file.
        /// </summary>
        /// <remarks>
        /// Default is true, set this property to false if you are using the bookmark for
        /// something special like like "CurrentLineBookmark" in the debugger.
        /// </remarks>
        public bool IsSaved
        {
            get
            {
                return isSaved;
            }
            set
            {
                isSaved = value;
            }
        }

        bool isVisibleInBookmarkPad = true;

        /// <summary>
        /// Gets/Sets if the bookmark is shown in the bookmark pad.
        /// </summary>
        /// <remarks>
        /// Default is true, set this property to false if you are using the bookmark for
        /// something special like like "CurrentLineBookmark" in the debugger.
        /// </remarks>
        public bool IsVisibleInBookmarkPad
        {
            get
            {
                return isVisibleInBookmarkPad;
            }
            set
            {
                isVisibleInBookmarkPad = value;
            }
        }

        protected override void RemoveMark()
        {
            BookmarkManager.RemoveMark(this);
        }
    }
}