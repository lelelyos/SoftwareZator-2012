// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




namespace VelerSoftware.SZC.Debugger.Core
{
    /// <summary>
    /// EventArgs with a file name.
    /// </summary>
    public class FileNameEventArgs : System.EventArgs
    {
        FileName fileName;

        public FileName FileName
        {
            get
            {
                return fileName;
            }
        }

        public FileNameEventArgs(FileName fileName)
        {
            this.fileName = fileName;
        }

        public FileNameEventArgs(string fileName)
        {
            this.fileName = FileName.Create(fileName);
        }
    }
}