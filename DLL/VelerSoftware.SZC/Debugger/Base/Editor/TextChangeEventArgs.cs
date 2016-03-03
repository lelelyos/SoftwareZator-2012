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

namespace VelerSoftware.SZC.Debugger.Base.Editor
{
    /// <summary>
    /// Describes a change of the document text.
    /// This class is thread-safe.
    /// </summary>
    public class TextChangeEventArgs : EventArgs
    {
        /// <summary>
        /// The offset at which the change occurs.
        /// </summary>
        public int Offset { get; private set; }

        /// <summary>
        /// The text that was inserted.
        /// </summary>
        public string RemovedText { get; private set; }

        /// <summary>
        /// The number of characters removed.
        /// </summary>
        public int RemovalLength
        {
            get { return RemovedText.Length; }
        }

        /// <summary>
        /// The text that was inserted.
        /// </summary>
        public string InsertedText { get; private set; }

        /// <summary>
        /// The number of characters inserted.
        /// </summary>
        public int InsertionLength
        {
            get { return InsertedText.Length; }
        }

        /// <summary>
        /// Creates a new TextChangeEventArgs object.
        /// </summary>
        public TextChangeEventArgs(int offset, string removedText, string insertedText)
        {
            this.Offset = offset;
            this.RemovedText = removedText ?? string.Empty;
            this.InsertedText = insertedText ?? string.Empty;
        }
    }
}