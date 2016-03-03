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

namespace VelerSoftware.SZC.Debugger.Base.Debugging
{
    public class BreakpointBookmarkEventArgs : EventArgs
    {
        BreakpointBookmark breakpointBookmark;

        public BreakpointBookmark BreakpointBookmark
        {
            get
            {
                return breakpointBookmark;
            }
        }

        public BreakpointBookmarkEventArgs(BreakpointBookmark breakpointBookmark)
        {
            this.breakpointBookmark = breakpointBookmark;
        }
    }
}