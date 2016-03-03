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

namespace VelerSoftware.SZC.Debugger.Base.Util
{
    public delegate void LineReceivedEventHandler(object sender, LineReceivedEventArgs e);

    /// <summary>
    /// The arguments for the <see cref="LineReceivedEventHandler"/> event.
    /// </summary>
    public class LineReceivedEventArgs : EventArgs
    {
        string line = String.Empty;

        public LineReceivedEventArgs(string line)
        {
            this.line = line;
        }

        public string Line
        {
            get
            {
                return line;
            }
        }
    }
}