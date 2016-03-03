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
using VelerSoftware.SZC.Debugger.Base.Gui;
using VelerSoftware.SZC.Debugger.Core;

namespace VelerSoftware.SZC.Debugger.Base.Debugging
{
    public static class DebuggerService
    {
        static IDebugger currentDebugger = null;
        //static DebuggerDescriptor[] debuggers;

        static DebuggerService()
        {
            // ProjectService.SolutionLoaded += delegate {
            // 	ClearDebugMessages();
            // };
        }

        private static IDebugger GetCompatibleDebugger()
        {
            //GetDescriptors();
            //IProject project = null;
            //if (ProjectService.OpenSolution != null) {
            //	project = ProjectService.OpenSolution.StartupProject;
            //}
            //foreach (DebuggerDescriptor d in debuggers) {
            //	if (d.Debugger != null) {
            //		return d.Debugger;
            //	}
            //}
            return currentDebugger;
            //return new DefaultDebugger();
        }

        /// <summary>
        /// Gets the current debugger. The debugger addin is loaded on demand; so if you
        /// just want to check a property like IsDebugging, check <see cref="IsDebuggerLoaded"/>
        /// before using this property.
        /// </summary>
        public static IDebugger CurrentDebugger
        {
            get
            {
                if (currentDebugger == null)
                {
                    currentDebugger = GetCompatibleDebugger();
                    currentDebugger.DebugStarting += new EventHandler(OnDebugStarting);
                    currentDebugger.DebugStarted += new EventHandler(OnDebugStarted);
                    currentDebugger.DebugStopped += new EventHandler(OnDebugStopped);
                }
                return currentDebugger;
            }
            set
            {
                if (value == null)
                {
                    currentDebugger = null;
                }
                if (currentDebugger == null && value != null)
                {
                    currentDebugger = value;
                    currentDebugger.DebugStarting += new EventHandler(OnDebugStarting);
                    currentDebugger.DebugStarted += new EventHandler(OnDebugStarted);
                    currentDebugger.DebugStopped += new EventHandler(OnDebugStopped);
                }
            }
        }

        /// <summary>
        /// Returns true if debugger is already loaded.
        /// </summary>
        public static bool IsDebuggerLoaded
        {
            get
            {
                return currentDebugger != null;
            }
        }

        static bool debuggerStarted;

        /// <summary>
        /// Gets whether the debugger is currently active.
        /// </summary>
        public static bool IsDebuggerStarted
        {
            get { return debuggerStarted; }
        }

        public static event EventHandler DebugStarting;
        public static event EventHandler DebugStarted;
        public static event EventHandler DebugStopped;

        static IAnalyticsMonitorTrackedFeature debugFeature;

        private static void OnDebugStarting(object sender, EventArgs e)
        {
            debugFeature = AnalyticsMonitorService.TrackFeature("Debugger");

            ClearDebugMessages();

            if (DebugStarting != null)
                DebugStarting(null, e);
        }

        private static void OnDebugStarted(object sender, EventArgs e)
        {
            debuggerStarted = true;
            if (DebugStarted != null)
                DebugStarted(null, e);
        }

        private static void OnDebugStopped(object sender, EventArgs e)
        {
            debuggerStarted = false;
            if (debugFeature != null)
                debugFeature.EndTracking();

            RemoveCurrentLineMarker();
            if (DebugStopped != null)
                DebugStopped(null, e);
        }

        private static void EnsureDebugCategory()
        {
        }

        public static void ClearDebugMessages()
        {
            EnsureDebugCategory();
        }

        public static void PrintDebugMessage(string msg)
        {
            EnsureDebugCategory();
        }

        public static event EventHandler<BreakpointBookmarkEventArgs> BreakPointChanged;
        public static event EventHandler<BreakpointBookmarkEventArgs> BreakPointAdded;
        public static event EventHandler<BreakpointBookmarkEventArgs> BreakPointRemoved;

        private static void OnBreakPointChanged(BreakpointBookmarkEventArgs e)
        {
            if (BreakPointChanged != null)
            {
                BreakPointChanged(null, e);
            }
        }

        private static void OnBreakPointAdded(BreakpointBookmarkEventArgs e)
        {
            if (BreakPointAdded != null)
            {
                BreakPointAdded(null, e);
            }
        }

        private static void OnBreakPointRemoved(BreakpointBookmarkEventArgs e)
        {
            if (BreakPointRemoved != null)
            {
                BreakPointRemoved(null, e);
            }
        }

        public static IList<BreakpointBookmark> Breakpoints
        {
            get
            {
                List<BreakpointBookmark> breakpoints = new List<BreakpointBookmark>();
                return breakpoints.AsReadOnly();
            }
        }

        private static void BookmarkAdded(object sender, object e)
        {
        }

        private static void BookmarkRemoved(object sender, object e)
        {
        }

        private static void BookmarkChanged(object sender, EventArgs e)
        {
            BreakpointBookmark bb = sender as BreakpointBookmark;
            if (bb != null)
            {
                OnBreakPointChanged(new BreakpointBookmarkEventArgs(bb));
            }
        }

        public static void ToggleBreakpointAt(ITextEditor editor, int lineNumber)
        {
        }

        /* TODO: reimplement this stuff
        static void ViewContentOpened(object sender, ViewContentEventArgs e)
        {
                textArea.IconBarMargin.MouseDown += IconBarMouseDown;
                textArea.ToolTipRequest          += TextAreaToolTipRequest;
                textArea.MouseLeave              += TextAreaMouseLeave;
        }*/

        public static void RemoveCurrentLineMarker()
        {
        }

        public static void JumpToCurrentLine(string SourceFullFilename, int StartLine, int StartColumn, int EndLine, int EndColumn)
        {
            IViewContent viewContent = FileService.JumpToFilePosition(SourceFullFilename, StartLine, StartColumn);
        }
    }
}