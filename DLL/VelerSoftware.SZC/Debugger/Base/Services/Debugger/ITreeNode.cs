// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System.Collections.Generic;

namespace VelerSoftware.SZC.Debugger.Base.Debugging
{
    /// <summary>
    /// Node that can be bound to <see cref="DebuggerTooltipControl" />.
    /// </summary>
    public interface ITreeNode
    {
        string Name { get; }

        string Text { get; }

        string Type { get; }

        IEnumerable<ITreeNode> ChildNodes { get; }

        bool HasChildNodes { get; }

        IEnumerable<IVisualizerCommand> VisualizerCommands { get; }

        bool HasVisualizerCommands { get; }
    }
}