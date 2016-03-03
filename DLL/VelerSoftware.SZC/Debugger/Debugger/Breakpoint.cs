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
using System.Runtime.InteropServices;

using VelerSoftware.SZC.Debugger.Debugger.Interop.CorDebug;

namespace VelerSoftware.SZC.Debugger.Debugger
{
    public class Breakpoint : DebuggerObject
    {
        public NDebugger _debugger;

        public string _fileName;
        public byte[] _checkSum;
        public int _line;
        public int _column;
        public bool _enabled;

        public SourcecodeSegment originalLocation;

        public List<ICorDebugFunctionBreakpoint> corBreakpoints = new List<ICorDebugFunctionBreakpoint>();

        public event EventHandler<BreakpointEventArgs> Hit;
        public event EventHandler<BreakpointEventArgs> Set;

        public string SZW_SZC_FileName;

        public string FunctionName;

        public string ActionDisplayName;

        public string ActionID;

        public string ProjectName;

        public System.Activities.Debugger.SourceLocation SourceLocation;

        [Debugger.Tests.Ignore]
        public NDebugger Debugger
        {
            get { return _debugger; }
        }

        public string FileName
        {
            get { return _fileName; }
        }

        public byte[] CheckSum
        {
            get { return _checkSum; }
        }

        public int Line
        {
            get { return _line; }
            set { _line = value; }
        }

        public int Column
        {
            get { return _column; }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                foreach (ICorDebugFunctionBreakpoint corBreakpoint in corBreakpoints)
                {
                    corBreakpoint.Activate(_enabled ? 1 : 0);
                }
            }
        }

        public SourcecodeSegment OriginalLocation
        {
            get { return originalLocation; }
        }

        public bool IsSet
        {
            get
            {
                return corBreakpoints.Count > 0;
            }
        }

        protected virtual void OnHit(BreakpointEventArgs e)
        {
            if (Hit != null)
            {
                Hit(this, e);
            }
        }

        internal void NotifyHit()
        {
            OnHit(new BreakpointEventArgs(this));
            _debugger.Breakpoints.OnHit(this);
        }

        protected virtual void OnSet(BreakpointEventArgs e)
        {
            if (Set != null)
            {
                Set(this, e);
            }
        }

        public Breakpoint()
        {
        }

        public Breakpoint(string _filename, string _vbfilename, string _functionname, string _actiondisplayname, string _actionid, int _line, bool _enabled, string _projectname, System.Activities.Debugger.SourceLocation _sourcelocation, VelerSoftware.SZC.Debugger.Debugger.NDebugger __debugger)
        {
            this.ActionDisplayName = _actiondisplayname;
            this.ActionID = _actionid;
            this._enabled = _enabled;
            this.SZW_SZC_FileName = _filename;
            this.FunctionName = _functionname;
            this._line = _line;
            this.ProjectName = _projectname;
            this.SourceLocation = _sourcelocation;
            this._fileName = _vbfilename;
            this._checkSum = new byte[] { };
            this._debugger = __debugger;
            this._column = 0;
        }

        internal bool IsOwnerOf(ICorDebugBreakpoint breakpoint)
        {
            foreach (ICorDebugFunctionBreakpoint corFunBreakpoint in corBreakpoints)
            {
                if (((ICorDebugBreakpoint)corFunBreakpoint).Equals(breakpoint)) return true;
            }
            return false;
        }

        internal void Deactivate()
        {
            foreach (ICorDebugFunctionBreakpoint corBreakpoint in corBreakpoints)
            {
#if DEBUG
					// Get repro
					corBreakpoint.Activate(0);
#else
                try
                {
                    corBreakpoint.Activate(0);
                }
                catch (COMException e)
                {
                    // Sometimes happens, but we had not repro yet.
                    // 0x80131301: Process was terminated.
                    if ((uint)e.ErrorCode == 0x80131301)
                        continue;
                    throw;
                }
#endif
            }
            corBreakpoints.Clear();
        }

        internal void MarkAsDeactivated()
        {
            corBreakpoints.Clear();
        }

        internal bool SetBreakpoint(Module module)
        {
            SourcecodeSegment segment = SourcecodeSegment.Resolve(module, FileName, CheckSum, Line, Column);
            if (segment == null) return false;

            originalLocation = segment;

            ICorDebugFunctionBreakpoint corBreakpoint = segment.CorFunction.GetILCode().CreateBreakpoint((uint)segment.ILStart);
            corBreakpoint.Activate(_enabled ? 1 : 0);

            corBreakpoints.Add(corBreakpoint);

            OnSet(new BreakpointEventArgs(this));

            return true;
        }

        /// <summary> Remove this breakpoint </summary>
        public void Remove()
        {
            _debugger.Breakpoints.Remove(this);
        }
    }

    [Serializable]
    public class BreakpointEventArgs : DebuggerEventArgs
    {
        Breakpoint breakpoint;

        public Breakpoint Breakpoint
        {
            get
            {
                return breakpoint;
            }
        }

        public BreakpointEventArgs(Breakpoint breakpoint)
            : base(breakpoint.Debugger)
        {
            this.breakpoint = breakpoint;
        }
    }
}