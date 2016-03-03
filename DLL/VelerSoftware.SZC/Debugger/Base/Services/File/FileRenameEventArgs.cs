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

namespace VelerSoftware.SZC.Debugger.Base
{
    public class FileRenamingEventArgs : FileRenameEventArgs
    {
        bool cancel;

        public bool Cancel
        {
            get
            {
                return cancel;
            }
            set
            {
                cancel = value;
            }
        }

        bool operationAlreadyDone;

        public bool OperationAlreadyDone
        {
            get
            {
                return operationAlreadyDone;
            }
            set
            {
                operationAlreadyDone = value;
            }
        }

        public FileRenamingEventArgs(string sourceFile, string targetFile, bool isDirectory)
            : base(sourceFile, targetFile, isDirectory)
        {
        }
    }

    public class FileRenameEventArgs : EventArgs
    {
        bool isDirectory;

        string sourceFile = null;
        string targetFile = null;

        public string SourceFile
        {
            get
            {
                return sourceFile;
            }
        }

        public string TargetFile
        {
            get
            {
                return targetFile;
            }
        }

        public bool IsDirectory
        {
            get
            {
                return isDirectory;
            }
        }

        public FileRenameEventArgs(string sourceFile, string targetFile, bool isDirectory)
        {
            this.sourceFile = sourceFile;
            this.targetFile = targetFile;
            this.isDirectory = isDirectory;
        }
    }
}