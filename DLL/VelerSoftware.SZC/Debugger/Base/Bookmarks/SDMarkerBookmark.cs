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
using VelerSoftware.SZC.Debugger.Base.Editor;
using VelerSoftware.SZC.Debugger.Core;
using VelerSoftware.SZC.VBNetParser;

namespace VelerSoftware.SZC.Debugger.Base.Bookmarks
{
    /// <summary>
    /// A bookmark that is persistant across SharpDevelop sessions and has a text marker assigned to it.
    /// </summary>
    public abstract class SDMarkerBookmark : SDBookmark
    {
        public SDMarkerBookmark(FileName fileName, Location location)
            : base(fileName, location)
        {
            //SetMarker();
        }

        ITextMarker marker;

        protected abstract ITextMarker CreateMarker(ITextMarkerService markerService);

        private void SetMarker()
        {
            RemoveMarker();
            if (this.Document != null)
            {
                ITextMarkerService markerService = this.Document.GetService(typeof(ITextMarkerService)) as ITextMarkerService;
                if (markerService != null)
                {
                    marker = CreateMarker(markerService);
                }
            }
        }

        protected override void OnDocumentChanged(EventArgs e)
        {
            base.OnDocumentChanged(e);
            SetMarker();
        }

        public virtual void RemoveMarker()
        {
            if (marker != null)
            {
                marker.Delete();
                marker = null;
            }
        }
    }
}