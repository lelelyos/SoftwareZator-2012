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
using VelerSoftware.SZC.VBNetParser;

namespace VelerSoftware.SZC.Debugger.Base.Editor
{
    /// <summary>
    /// A document representing a source code file for refactoring.
    /// Line and column counting starts at 1.
    /// Offset counting starts at 0.
    /// </summary>
    public interface IDocument : ITextBuffer, IServiceProvider
    {
        /// <summary>
        /// Gets/Sets the whole text as string.
        /// </summary>
        new string Text { get; set; } // hides TextBuffer.Text to add the setter

        /// <summary>
        /// Gets the total number of lines in the document.
        /// </summary>
        int TotalNumberOfLines { get; }

        int PositionToOffset(int line, int column);

        Location OffsetToPosition(int offset);

        void Insert(int offset, string text);

        void Insert(int offset, string text, AnchorMovementType defaultAnchorMovementType);

        void Remove(int offset, int length);

        void Replace(int offset, int length, string newText);

        /// <summary>
        /// Make the document combine the following actions into a single
        /// action for undo purposes.
        /// </summary>
        void StartUndoableAction();

        /// <summary>
        /// Ends the undoable action started with <see cref="StartUndoableAction"/>.
        /// </summary>
        void EndUndoableAction();

        /// <summary>
        /// Creates an undo group. Dispose the returned value to close the undo group.
        /// </summary>
        /// <returns>An object that closes the undo group when Dispose() is called.</returns>
        IDisposable OpenUndoGroup();

        /// <summary>
        /// Creates a new text anchor at the specified position.
        /// </summary>
        ITextAnchor CreateAnchor(int offset);

        event EventHandler<TextChangeEventArgs> Changing;
        event EventHandler<TextChangeEventArgs> Changed;
    }
}