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
    public class FileEventArgs : EventArgs
    {
        string fileName = null;

        bool isDirectory;

        public string FileName
        {
            get
            {
                return fileName;
            }
        }

        public bool IsDirectory
        {
            get
            {
                return isDirectory;
            }
        }

        public FileEventArgs(string fileName, bool isDirectory)
        {
            this.fileName = fileName;
            this.isDirectory = isDirectory;
        }
    }

    public class FileCancelEventArgs : FileEventArgs
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

        public FileCancelEventArgs(string fileName, bool isDirectory)
            : base(fileName, isDirectory)
        {
        }
    }
}