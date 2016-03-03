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
using System.Drawing;
using System.Windows.Media;
using VelerSoftware.SZC.Debugger.Base.Bookmarks;
using VelerSoftware.SZC.Debugger.Base.Editor;
using VelerSoftware.SZC.Debugger.Core;
using VelerSoftware.SZC.VBNetParser;

namespace VelerSoftware.SZC.Debugger.Base.Debugging
{
    public enum BreakpointAction
    {
        Break,
        Trace,
        Condition
    }

    public class BreakpointBookmark : SDMarkerBookmark
    {
        bool isHealthy = true;
        bool isEnabled = true;
        string tooltip;

        BreakpointAction action = BreakpointAction.Break;
        string condition;
        string scriptLanguage;

        public string ScriptLanguage
        {
            get { return scriptLanguage; }
            set { scriptLanguage = value; }
        }

        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        public BreakpointAction Action
        {
            get
            {
                return action;
            }
            set
            {
                if (action != value)
                {
                    action = value;
                    Redraw();
                }
            }
        }

        public virtual bool IsHealthy
        {
            get
            {
                return isHealthy;
            }
            set
            {
                if (isHealthy != value)
                {
                    isHealthy = value;
                    Redraw();
                }
            }
        }

        public virtual bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    if (IsEnabledChanged != null)
                        IsEnabledChanged(this, EventArgs.Empty);
                    Redraw();
                }
            }
        }

        public event EventHandler IsEnabledChanged;

        public string Tooltip
        {
            get { return tooltip; }
            set { tooltip = value; }
        }

        public BreakpointBookmark(FileName fileName, Location location, BreakpointAction action, string scriptLanguage, string script)
            : base(fileName, location)
        {
            this.action = action;
            this.scriptLanguage = scriptLanguage;
            this.condition = script;
        }

        // public static readonly Image BreakpointImage = new ResourceServiceImage("Bookmarks.Breakpoint");
        // public static readonly Image BreakpointConditionalImage = new ResourceServiceImage("Bookmarks.BreakpointConditional");
        // public static readonly Image DisabledBreakpointImage = new ResourceServiceImage("Bookmarks.DisabledBreakpoint");
        // public static readonly Image UnhealthyBreakpointImage = new ResourceServiceImage("Bookmarks.UnhealthyBreakpoint");
        // public static readonly Image UnhealthyBreakpointConditionalImage = new ResourceServiceImage("Bookmarks.UnhealthyBreakpointConditional");
        public static readonly Image BreakpointImage = null;
        public static readonly Image BreakpointConditionalImage = null;
        public static readonly Image DisabledBreakpointImage = null;
        public static readonly Image UnhealthyBreakpointImage = null;
        public static readonly Image UnhealthyBreakpointConditionalImage = null;

        public override Image Image
        {
            get
            {
                if (!this.IsEnabled)
                    return DisabledBreakpointImage;
                else if (this.IsHealthy)
                    return this.Action == BreakpointAction.Break ? BreakpointImage : BreakpointConditionalImage;
                else
                    return this.Action == BreakpointAction.Break ? UnhealthyBreakpointImage : UnhealthyBreakpointConditionalImage;
            }
        }

        protected override ITextMarker CreateMarker(ITextMarkerService markerService)
        {
            ITextMarker marker = null;
            marker.BackgroundColor = System.Windows.Media.Color.FromRgb(180, 38, 38);
            marker.ForegroundColor = Colors.White;
            return marker;
        }
    }
}