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
using System.IO;
using VelerSoftware.SZC.Debugger.Core;

namespace VelerSoftware.SZC.Debugger.Base
{
    internal sealed class FileChangeWatcher : IDisposable
    {
        public static bool DetectExternalChangesOption
        {
            get
            {
                return PropertyService.Get("SharpDevelop.FileChangeWatcher.DetectExternalChanges", true);
            }
            set
            {
                PropertyService.Set("SharpDevelop.FileChangeWatcher.DetectExternalChanges", value);
                foreach (FileChangeWatcher watcher in activeWatchers)
                {
                    watcher.SetWatcher();
                }
            }
        }

        public static bool AutoLoadExternalChangesOption
        {
            get
            {
                return PropertyService.Get("SharpDevelop.FileChangeWatcher.AutoLoadExternalChanges", true);
            }
            set
            {
                PropertyService.Set("SharpDevelop.FileChangeWatcher.AutoLoadExternalChanges", value);
            }
        }

        static HashSet<FileChangeWatcher> activeWatchers = new HashSet<FileChangeWatcher>();

        static int globalDisableCount;

        public static void DisableAllChangeWatchers()
        {
            globalDisableCount++;
            foreach (FileChangeWatcher w in activeWatchers)
                w.SetWatcher();
        }

        public static void EnableAllChangeWatchers()
        {
            if (globalDisableCount == 0)
                throw new InvalidOperationException();
            globalDisableCount--;
            foreach (FileChangeWatcher w in activeWatchers)
                w.SetWatcher();
        }

        FileSystemWatcher watcher;
        bool wasChangedExternally = false;
        OpenedFile file;

        public FileChangeWatcher(OpenedFile file)
        {
            if (file == null)
                throw new ArgumentNullException("file");
            this.file = file;
            file.FileNameChanged += file_FileNameChanged;
            activeWatchers.Add(this);
            SetWatcher();
        }

        private void file_FileNameChanged(object sender, EventArgs e)
        {
            SetWatcher();
        }

        public void Dispose()
        {
            activeWatchers.Remove(this);
            if (file != null)
            {
                file.FileNameChanged -= file_FileNameChanged;
                file = null;
            }
            if (watcher != null)
            {
                watcher.Dispose();
                watcher = null;
            }
        }

        bool enabled = true;

        public bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                SetWatcher();
            }
        }

        private void SetWatcher()
        {
            if (watcher != null)
            {
                watcher.EnableRaisingEvents = false;
            }

            if (!enabled)
                return;
            if (globalDisableCount > 0)
                return;
            if (DetectExternalChangesOption == false)
                return;

            string fileName = file.FileName;
            if (string.IsNullOrEmpty(fileName))
                return;
            if (FileUtility.IsUrl(fileName))
                return;
            if (!Path.IsPathRooted(fileName))
                return;

            try
            {
                if (watcher == null)
                {
                    watcher = new FileSystemWatcher();
                    watcher.Changed += OnFileChangedEvent;
                    watcher.Created += OnFileChangedEvent;
                    watcher.Renamed += OnFileChangedEvent;
                }
                watcher.Path = Path.GetDirectoryName(fileName);
                watcher.Filter = Path.GetFileName(fileName);
                watcher.EnableRaisingEvents = true;
            }
            catch (PlatformNotSupportedException)
            {
                if (watcher != null)
                {
                    watcher.Dispose();
                }
                watcher = null;
            }
            catch (FileNotFoundException)
            {
                // can occur if directory was deleted externally
                if (watcher != null)
                {
                    watcher.Dispose();
                }
                watcher = null;
            }
            catch (ArgumentException)
            {
                // can occur if parent directory was deleted externally
                if (watcher != null)
                {
                    watcher.Dispose();
                }
                watcher = null;
            }
        }

        private void OnFileChangedEvent(object sender, FileSystemEventArgs e)
        {
            if (file == null)
                return;
            LoggingService.Debug("File " + file.FileName + " was changed externally: " + e.ChangeType);
            if (!wasChangedExternally)
            {
                wasChangedExternally = true;
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (wasChangedExternally)
            {
                wasChangedExternally = false;

                if (file == null)
                    return;

                string fileName = file.FileName;
                if (!File.Exists(fileName))
                    return;

                string message = StringParser.Parse("${res:VelerSoftware.SZC.Debugger.Base.DefaultEditor.Gui.Editor.TextEditorDisplayBinding.FileAlteredMessage}", new string[,] { { "File", Path.GetFullPath(fileName) } });
                if ((AutoLoadExternalChangesOption && file.IsDirty == false)
                    || MessageService.AskQuestion(message, StringParser.Parse("${res:MainWindow.DialogName}")))
                {
                    if (File.Exists(fileName))
                    {
                        file.ReloadFromDisk();
                    }
                }
                else
                {
                    file.MakeDirty();
                }
            }
        }
    }
}