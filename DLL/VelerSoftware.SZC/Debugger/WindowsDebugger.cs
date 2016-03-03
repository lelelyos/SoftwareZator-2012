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
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using VelerSoftware.SZC.Debugger.Base.Bookmarks;
using VelerSoftware.SZC.Debugger.Base.Debugging;
using VelerSoftware.SZC.Debugger.Base.Gui;
using VelerSoftware.SZC.Debugger.Core;
using VelerSoftware.SZC.Debugger.Debugger;
using VelerSoftware.SZC.Debugger.Debugger.Interop.CorPublish;
using VelerSoftware.SZC.VBNetParser.Ast;
using VelerSoftware.SZC.VBNetParser.Visitors;
using Process = VelerSoftware.SZC.Debugger.Debugger.Process;

namespace VelerSoftware.SZC.Debugger
{
    public class WindowsDebugger : IDebugger
    {
        private enum StopAttachedProcessDialogResult
        {
            Detach = 0,
            Terminate = 1,
            Cancel = 2
        }

        bool useRemotingForThreadInterop = false;
        bool attached;

        NDebugger debugger;

        ICorPublish corPublish;

        Process debuggedProcess;

        //DynamicTreeDebuggerRow currentTooltipRow;
        //Expression             currentTooltipExpression;

        public event EventHandler<ProcessEventArgs> ProcessSelected;

        public NDebugger DebuggerCore
        {
            get
            {
                return debugger;
            }
        }

        public Process DebuggedProcess
        {
            get
            {
                return debuggedProcess;
            }
        }

        public static Process CurrentProcess
        {
            get
            {
                WindowsDebugger dbgr = DebuggerService.CurrentDebugger as WindowsDebugger;
                if (dbgr != null && dbgr.DebuggedProcess != null)
                {
                    return dbgr.DebuggedProcess;
                }
                else
                {
                    return null;
                }
            }
        }

        protected virtual void OnProcessSelected(ProcessEventArgs e)
        {
            if (ProcessSelected != null)
            {
                ProcessSelected(this, e);
            }
        }

        public bool ServiceInitialized
        {
            get
            {
                return debugger != null;
            }
        }

        public WindowsDebugger()
        {
            if (Variables.Langue == "en")
            {
                errorDebugging = VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_Debugging_EN;
                errorNotDebugging = VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_NotDebugging_EN;
                errorProcessRunning = VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_ProcessRunning_EN;
                errorProcessPaused = VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_ProcessPaused_EN;
                errorCannotStepNoActiveFunction = VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_Threads_CannotStepNoActiveFunction_EN;
            }
            else
            {
                errorDebugging = VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_Debugging;
                errorNotDebugging = VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_NotDebugging;
                errorProcessRunning = VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_ProcessRunning;
                errorProcessPaused = VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_ProcessPaused;
                errorCannotStepNoActiveFunction = VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_Threads_CannotStepNoActiveFunction;
            }
        }

        #region IDebugger Members

        string errorDebugging = null;
        string errorNotDebugging = null;
        string errorProcessRunning = null;
        string errorProcessPaused = null;
        string errorCannotStepNoActiveFunction = null;

        public bool IsDebugging
        {
            get
            {
                return ServiceInitialized && debuggedProcess != null;
            }
        }

        public bool IsAttached
        {
            get
            {
                return ServiceInitialized && attached;
            }
        }

        public bool IsProcessRunning
        {
            get
            {
                return IsDebugging && debuggedProcess.IsRunning;
            }
        }

        public bool CanDebug(object project)
        {
            return true;
        }

        public void Start(ProcessStartInfo processStartInfo)
        {
            if (IsDebugging)
            {
                System.Windows.Forms.MessageBox.Show(errorDebugging);
                return;
            }
            if (!ServiceInitialized)
            {
                InitializeService();
            }
            string version = debugger.GetProgramVersion(processStartInfo.FileName);
            if (version.StartsWith("v1.0"))
            {
                if (Variables.Langue == "en")
                {
                    System.Windows.Forms.MessageBox.Show(VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_Net10NotSupported_EN);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_Net10NotSupported);
                }
            }
            else if (version.StartsWith("v1.1"))
            {
                if (Variables.Langue == "en")
                {
                    System.Windows.Forms.MessageBox.Show(StringParser.Parse(VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_Net10NotSupported_EN).Replace("1.0", "1.1"));
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(StringParser.Parse(VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_Net10NotSupported).Replace("1.0", "1.1"));
                }
                //			} else if (string.IsNullOrEmpty(version)) {
                //				// Not a managed assembly
                //				MessageService.ShowMessage("${res:XML.MainMenu.DebugMenu.Error.BadAssembly}");
            }
            else if (debugger.IsKernelDebuggerEnabled)
            {
                if (Variables.Langue == "en")
                {
                    System.Windows.Forms.MessageBox.Show(VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_KernelDebuggerEnabled_EN);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_KernelDebuggerEnabled);
                }
            }
            else
            {
                attached = false;
                if (DebugStarting != null)
                    DebugStarting(this, EventArgs.Empty);

                try
                {
                    Process process = debugger.Start(processStartInfo.FileName,
                                                     processStartInfo.WorkingDirectory,
                                                     processStartInfo.Arguments);
                    SelectProcess(process);
                }
                catch (System.Exception e)
                {
                    // COMException: The request is not supported. (Exception from HRESULT: 0x80070032)
                    // COMException: The application has failed to start because its side-by-side configuration is incorrect. Please see the application event log for more detail. (Exception from HRESULT: 0x800736B1)
                    // COMException: The requested operation requires elevation. (Exception from HRESULT: 0x800702E4)
                    // COMException: The directory name is invalid. (Exception from HRESULT: 0x8007010B)
                    // BadImageFormatException:  is not a valid Win32 application. (Exception from HRESULT: 0x800700C1)
                    // UnauthorizedAccessException: Отказано в доступе. (Исключение из HRESULT: 0x80070005 (E_ACCESSDENIED))
                    if (e is COMException || e is BadImageFormatException || e is UnauthorizedAccessException)
                    {
                        string msg = null;
                        if (Variables.Langue == "en")
                        {
                            msg = StringParser.Parse(VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_CannotStartProcess_EN);
                        }
                        else
                        {
                            msg = StringParser.Parse(VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_CannotStartProcess);
                        }
                        msg += " " + e.Message + " " + e.StackTrace;
                        // TODO: Remove
                        if (e is COMException && ((uint)((COMException)e).ErrorCode == 0x80070032))
                        {
                            msg += Environment.NewLine + Environment.NewLine;
                            msg += "64-bit debugging is not supported.  Please set Project -> Project Options... -> Compiling -> Target CPU to 32bit.";
                        }
                        System.Windows.Forms.MessageBox.Show(msg);

                        if (DebugStopped != null)
                            DebugStopped(this, EventArgs.Empty);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message);
                        throw;
                    }
                }
            }
        }

        public void ShowAttachDialog()
        {
            // using (AttachToProcessForm attachForm = new AttachToProcessForm())
            // {
            //     if (attachForm.ShowDialog(WorkbenchSingleton.MainWin32Window) == DialogResult.OK)
            //     {
            //         Attach(attachForm.Process);
            //     }
            // }
        }

        public void Attach(System.Diagnostics.Process existingProcess)
        {
            if (IsDebugging)
            {
                this.DebuggedProcess.OnLogMessage(new Debugger.MessageEventArgs(this.DebuggedProcess, errorDebugging));
                return;
            }
            if (!ServiceInitialized)
            {
                InitializeService();
            }

            if (DebugStarting != null)
                DebugStarting(this, EventArgs.Empty);

            try
            {
                Process process = debugger.Attach(existingProcess);
                attached = true;
                SelectProcess(process);

                process.Modules.Added += process_Modules_Added;
            }
            catch (System.Exception e)
            {
                // CORDBG_E_DEBUGGER_ALREADY_ATTACHED
                if (e is COMException || e is UnauthorizedAccessException)
                {
                    string msg = null;
                    if (Variables.Langue == "en")
                    {
                        msg = StringParser.Parse(VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_CannotStartProcess_EN);
                    }
                    else
                    {
                        msg = StringParser.Parse(VelerSoftware.SZC.Properties.Resources.XML_MainMenu_DebugMenu_Error_CannotStartProcess);
                    }
                    this.DebuggedProcess.OnLogMessage(new Debugger.MessageEventArgs(this.DebuggedProcess, msg + " " + e.Message));

                    if (DebugStopped != null)
                        DebugStopped(this, EventArgs.Empty);
                }
                else
                {
                    throw;
                }
            }
        }

        public void Detach()
        {
            debugger.Detach();
        }

        public void StartWithoutDebugging(ProcessStartInfo processStartInfo)
        {
            System.Diagnostics.Process.Start(processStartInfo);
        }

        public void Stop()
        {
            if (!IsDebugging)
            {
                return;
            }
            if (IsAttached)
            {
                StopAttachedProcessDialogResult result = ShowStopAttachedProcessDialog();
                switch (result)
                {
                    case StopAttachedProcessDialogResult.Terminate:
                        debuggedProcess.Terminate();
                        attached = false;
                        break;
                    case StopAttachedProcessDialogResult.Detach:
                        Detach();
                        attached = false;
                        break;
                }
            }
            else
            {
                debuggedProcess.Terminate();
            }
        }

        // ExecutionControl:

        public void Break()
        {
            if (!IsDebugging)
            {
                return;
            }
            if (!IsProcessRunning)
            {
                return;
            }
            debuggedProcess.Break();
        }

        public void Continue()
        {
            if (!IsDebugging)
            {
                return;
            }
            if (IsProcessRunning)
            {
                return;
            }
            debuggedProcess.AsyncContinue();
        }

        // Stepping:

        public void StepInto()
        {
            if (!IsDebugging)
            {
                return;
            }
            else
            {
                debuggedProcess.SelectedStackFrame.AsyncStepInto();
            }
        }

        public void StepOver()
        {
            if (!IsDebugging)
            {
                return;
            }
            else
            {
                debuggedProcess.SelectedStackFrame.AsyncStepOver();
            }
        }

        public void StepOut()
        {
            if (!IsDebugging)
            {
                return;
            }
            else
            {
                debuggedProcess.SelectedStackFrame.AsyncStepOut();
            }
        }

        public event EventHandler DebugStarting;
        public event EventHandler DebugStarted;
        public event EventHandler DebugStopped;
        public event EventHandler IsProcessRunningChanged;

        protected virtual void OnIsProcessRunningChanged(EventArgs e)
        {
            if (IsProcessRunningChanged != null)
            {
                IsProcessRunningChanged(this, e);
            }
        }

        /// <summary>
        /// Gets variable of given name.
        /// Returns null if unsuccessful. Can throw GetValueException.
        /// <exception cref="GetValueException">Thrown when evaluation fails. Exception message explains reason.</exception>
        /// </summary>
        public Value GetValueFromName(string variableName)
        {
            if (!CanEvaluate)
            {
                return null;
            }
            return ExpressionEvaluator.Evaluate(variableName, debuggedProcess.SelectedStackFrame);
        }

        /// <summary>
        /// Gets Expression for given variable. Can throw GetValueException.
        /// <exception cref="GetValueException">Thrown when getting expression fails. Exception message explains reason.</exception>
        /// </summary>
        public Expression GetExpression(string variableName)
        {
            if (!CanEvaluate)
            {
                throw new GetValueException("Cannot evaluate now - debugged process is either null or running or has no selected stack frame");
            }
            return ExpressionEvaluator.ParseExpression(variableName);
        }

        public bool IsManaged(int processId)
        {
            corPublish = new CorpubPublishClass();
            Debugger.Interop.TrackedComObjects.Track(corPublish);

            ICorPublishProcess process = corPublish.GetProcess((uint)processId);
            if (process != null)
            {
                return process.IsManaged() != 0;
            }
            return false;
        }

        /// <summary>
        /// Gets the current value of the variable as string that can be displayed in tooltips.
        /// Returns null if unsuccessful.
        /// </summary>
        public string GetValueAsString(string variableName)
        {
            try
            {
                Value val = GetValueFromName(variableName);
                if (val == null) return null;
                return val.AsString();
            }
            catch (GetValueException)
            {
                return null;
            }
        }

        private bool CanEvaluate
        {
            get
            {
                return debuggedProcess != null && !debuggedProcess.IsRunning && debuggedProcess.SelectedStackFrame != null;
            }
        }

        /// <summary>
        /// Gets the tooltip control that shows the value of given variable.
        /// Return null if no tooltip is available.
        /// </summary>
        public object GetTooltipControl(string variableName)
        {
            try
            {
                // var tooltipExpression = GetExpression(variableName);
                // ExpressionNode expressionNode = new ExpressionNode(ExpressionNode.GetImageForLocalVariable(), variableName, tooltipExpression);
                // return new DebuggerTooltipControl(expressionNode);
                return null;
            }
            catch (GetValueException)
            {
                return null;
            }
        }

        public bool CanSetInstructionPointer(string filename, int line, int column)
        {
            if (debuggedProcess != null && debuggedProcess.IsPaused && debuggedProcess.SelectedStackFrame != null)
            {
                SourcecodeSegment seg = debuggedProcess.SelectedStackFrame.CanSetIP(filename, line, column);
                return seg != null;
            }
            else
            {
                return false;
            }
        }

        public bool SetInstructionPointer(string filename, int line, int column)
        {
            if (CanSetInstructionPointer(filename, line, column))
            {
                SourcecodeSegment seg = debuggedProcess.SelectedStackFrame.SetIP(filename, line, column);
                return seg != null;
            }
            else
            {
                return false;
            }
        }

        public void Dispose()
        {
            Stop();
        }

        #endregion IDebugger Members

        public event EventHandler Initialize;

        public void InitializeService()
        {
            if (useRemotingForThreadInterop)
            {
                // This needs to be called before instance of NDebugger is created
                new RemotingConfigurationHelpper(Application.StartupPath).Configure();
            }

            debugger = new NDebugger();

            debugger.Options = new Options(); // = DebuggingOptions.Instance;

            debugger.DebuggerTraceMessage += debugger_TraceMessage;
            debugger.Processes.Added += debugger_ProcessStarted;
            debugger.Processes.Removed += debugger_ProcessExited;

            DebuggerService.BreakPointAdded += delegate(object sender, BreakpointBookmarkEventArgs e)
            {
                AddBreakpoint(e.BreakpointBookmark);
            };

            foreach (BreakpointBookmark b in DebuggerService.Breakpoints)
            {
                AddBreakpoint(b);
            }

            if (Initialize != null)
            {
                Initialize(this, null);
            }
        }

        private bool Compare(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }

        private void AddBreakpoint(BreakpointBookmark bookmark)
        {
            Breakpoint breakpoint = debugger.Breakpoints.Add(bookmark.FileName, null, bookmark.LineNumber, 0, bookmark.IsEnabled);
            MethodInvoker setBookmarkColor = delegate
            {
                if (debugger.Processes.Count == 0)
                {
                    bookmark.IsHealthy = true;
                    bookmark.Tooltip = null;
                }
                else if (!breakpoint.IsSet)
                {
                    bookmark.IsHealthy = false;
                    bookmark.Tooltip = "Breakpoint was not found in any loaded modules";
                }
                else if (breakpoint.OriginalLocation.CheckSum == null)
                {
                    bookmark.IsHealthy = true;
                    bookmark.Tooltip = null;
                }
                else
                {
                    byte[] fileMD5;
                    IEditable file = null;// = FileService.GetOpenFile(bookmark.FileName) as IEditable;
                    if (file != null)
                    {
                        byte[] fileContent = VelerSoftware.SZC.Debugger.Base.ExtensionMethods.GetBytesWithPreamble(System.Text.Encoding.UTF8, file.Text);
                        fileMD5 = new MD5CryptoServiceProvider().ComputeHash(fileContent);
                    }
                    else
                    {
                        fileMD5 = new MD5CryptoServiceProvider().ComputeHash(File.ReadAllBytes(bookmark.FileName));
                    }
                    if (Compare(fileMD5, breakpoint.OriginalLocation.CheckSum))
                    {
                        bookmark.IsHealthy = true;
                        bookmark.Tooltip = null;
                    }
                    else
                    {
                        bookmark.IsHealthy = false;
                        bookmark.Tooltip = "Check sum or file does not match to the original";
                    }
                }
            };

            // event handlers on bookmark and breakpoint don't need deregistration
            bookmark.IsEnabledChanged += delegate
            {
                breakpoint.Enabled = bookmark.IsEnabled;
            };
            breakpoint.Set += delegate { setBookmarkColor(); };

            setBookmarkColor();

            EventHandler<CollectionItemEventArgs<Process>> bp_debugger_ProcessStarted = (sender, e) =>
            {
                setBookmarkColor();
                // User can change line number by inserting or deleting lines
                breakpoint.Line = bookmark.LineNumber;
            };
            EventHandler<CollectionItemEventArgs<Process>> bp_debugger_ProcessExited = (sender, e) =>
            {
                setBookmarkColor();
            };

            EventHandler<BreakpointEventArgs> bp_debugger_BreakpointHit =
                new EventHandler<BreakpointEventArgs>(
                    delegate(object sender, BreakpointEventArgs e)
                    {
                        LoggingService.Debug(bookmark.Action + " " + bookmark.ScriptLanguage + " " + bookmark.Condition);

                        switch (bookmark.Action)
                        {
                            case BreakpointAction.Break:
                                break;
                            case BreakpointAction.Condition:
                                if (Evaluate(bookmark.Condition, bookmark.ScriptLanguage))
                                {
                                    if (Variables.Langue == "en")
                                    {
                                        this.DebuggedProcess.OnLogMessage(new Debugger.MessageEventArgs(this.DebuggedProcess, string.Format(StringParser.Parse(VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_Conditional_Breakpoints_BreakpointHitAtBecause_EN) + "\n", bookmark.LineNumber, bookmark.FileName, bookmark.Condition)));
                                    }
                                    else
                                    {
                                        this.DebuggedProcess.OnLogMessage(new Debugger.MessageEventArgs(this.DebuggedProcess, string.Format(StringParser.Parse(VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_Conditional_Breakpoints_BreakpointHitAtBecause) + "\n", bookmark.LineNumber, bookmark.FileName, bookmark.Condition)));
                                    }
                                }
                                else
                                {
                                    this.debuggedProcess.AsyncContinue();
                                }
                                break;
                            case BreakpointAction.Trace:
                                if (Variables.Langue == "en")
                                {
                                    this.DebuggedProcess.OnLogMessage(new Debugger.MessageEventArgs(this.DebuggedProcess, string.Format(StringParser.Parse(VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_Conditional_Breakpoints_BreakpointHitAt_EN) + "\n", bookmark.LineNumber, bookmark.FileName)));
                                }
                                else
                                {
                                    this.DebuggedProcess.OnLogMessage(new Debugger.MessageEventArgs(this.DebuggedProcess, string.Format(StringParser.Parse(VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_Conditional_Breakpoints_BreakpointHitAt) + "\n", bookmark.LineNumber, bookmark.FileName)));
                                }
                                break;
                        }
                    });

            BookmarkEventHandler bp_bookmarkManager_Removed = null;
            bp_bookmarkManager_Removed = (sender, e) =>
            {
                if (bookmark == e.Bookmark)
                {
                    debugger.Breakpoints.Remove(breakpoint);

                    // unregister the events
                    debugger.Processes.Added -= bp_debugger_ProcessStarted;
                    debugger.Processes.Removed -= bp_debugger_ProcessExited;
                    breakpoint.Hit -= bp_debugger_BreakpointHit;
                    BookmarkManager.Removed -= bp_bookmarkManager_Removed;
                }
            };
            // register the events
            debugger.Processes.Added += bp_debugger_ProcessStarted;
            debugger.Processes.Removed += bp_debugger_ProcessExited;
            breakpoint.Hit += bp_debugger_BreakpointHit;
            BookmarkManager.Removed += bp_bookmarkManager_Removed;
        }

        private bool Evaluate(string code, string language)
        {
            try
            {
                Value val = ExpressionEvaluator.Evaluate(code, debuggedProcess.SelectedStackFrame);

                if (val != null && val.Type.IsPrimitive && val.PrimitiveValue is bool)
                    return (bool)val.PrimitiveValue;
                else
                    return false;
            }
            catch (GetValueException e)
            {
                string errorMessage = "Error while evaluating breakpoint condition " + code + ":\n" + e.Message + "\n";
                DebuggerService.PrintDebugMessage(errorMessage);
                return true;
            }
        }

        private void LogMessage(object sender, MessageEventArgs e)
        {
            DebuggerService.PrintDebugMessage(e.Message);
        }

        private void debugger_TraceMessage(object sender, MessageEventArgs e)
        {
            LoggingService.Debug("Debugger: " + e.Message);
        }

        private void debugger_ProcessStarted(object sender, CollectionItemEventArgs<Process> e)
        {
            if (debugger.Processes.Count == 1)
            {
                if (DebugStarted != null)
                {
                    DebugStarted(this, EventArgs.Empty);
                }
            }
            e.Item.LogMessage += LogMessage;
        }

        private void debugger_ProcessExited(object sender, CollectionItemEventArgs<Process> e)
        {
            if (debugger.Processes.Count == 0)
            {
                if (DebugStopped != null)
                {
                    DebugStopped(this, e);
                }
                SelectProcess(null);
            }
            else
            {
                SelectProcess(debugger.Processes[0]);
            }
        }

        public void SelectProcess(Process process)
        {
            if (debuggedProcess != null)
            {
                debuggedProcess.Paused -= debuggedProcess_DebuggingPaused;
                //debuggedProcess.ExceptionThrown -= debuggedProcess_ExceptionThrown;
                debuggedProcess.Resumed -= debuggedProcess_DebuggingResumed;
            }
            debuggedProcess = process;
            if (debuggedProcess != null)
            {
                debuggedProcess.Paused += debuggedProcess_DebuggingPaused;
                //debuggedProcess.ExceptionThrown += debuggedProcess_ExceptionThrown;
                debuggedProcess.Resumed += debuggedProcess_DebuggingResumed;
            }
            JumpToCurrentLine();
            OnProcessSelected(new ProcessEventArgs(process));
        }

        private void debuggedProcess_DebuggingPaused(object sender, ProcessEventArgs e)
        {
            OnIsProcessRunningChanged(EventArgs.Empty);

            // TODO update tooltip
            /*if (currentTooltipRow != null && currentTooltipRow.IsShown) {
                using(new PrintTimes("Update tooltip")) {
                    try {
                        Utils.DoEvents(debuggedProcess);
                        AbstractNode updatedNode = ValueNode.Create(currentTooltipExpression);
                        currentTooltipRow.SetContentRecursive(updatedNode);
                    } catch (AbortedBecauseDebuggeeResumedException) {
                    }
                }
            }*/
        }

        private void debuggedProcess_DebuggingResumed(object sender, ProcessEventArgs e)
        {
            OnIsProcessRunningChanged(EventArgs.Empty);
            DebuggerService.RemoveCurrentLineMarker();
        }

        public void JumpToCurrentLine()
        {
            DebuggerService.RemoveCurrentLineMarker();
            if (debuggedProcess != null)
            {
                SourcecodeSegment nextStatement = debuggedProcess.NextStatement;
                if (nextStatement != null)
                {
                    DebuggerService.JumpToCurrentLine(nextStatement.Filename, nextStatement.StartLine, nextStatement.StartColumn, nextStatement.EndLine, nextStatement.EndColumn);
                }
            }
        }

        private StopAttachedProcessDialogResult ShowStopAttachedProcessDialog()
        {
            string caption = StringParser.Parse("${res:XML.MainMenu.DebugMenu.Stop}");
            string message = StringParser.Parse("${res:MainWindow.Windows.Debug.StopProcessDialog.Message}");
            string[] buttonLabels = new string[] { StringParser.Parse("${res:XML.MainMenu.DebugMenu.Detach}"), StringParser.Parse("${res:MainWindow.Windows.Debug.ExceptionForm.Terminate}"), StringParser.Parse("${res:Global.CancelButtonText}") };
            return (StopAttachedProcessDialogResult)MessageService.ShowCustomDialog(caption, message, (int)StopAttachedProcessDialogResult.Detach, (int)StopAttachedProcessDialogResult.Cancel, buttonLabels);
        }

        private void process_Modules_Added(object sender, CollectionItemEventArgs<Module> e)
        {
            // ProjectService.OpenSolution.Projects
            //     .Where(p => e.Item.Name.IndexOf(p.Name) >= 0)
            //     .ForEach(p => e.Item.LoadSymbolsFromDisk(new[] { Path.GetDirectoryName(p.OutputAssemblyFullPath) }));
        }
    }
}