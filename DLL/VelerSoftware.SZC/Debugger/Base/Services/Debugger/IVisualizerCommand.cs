// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




namespace VelerSoftware.SZC.Debugger.Base.Debugging
{
    /// <summary>
    /// Command called from <see cref="VisualizerPicker"/>.
    /// </summary>
    public interface IVisualizerCommand
    {
        /// <summary>
        /// Can this command execute?
        /// </summary>
        bool CanExecute { get; }

        /// <summary>
        /// Executes this visualizer command.
        /// </summary>
        void Execute();
    }
}