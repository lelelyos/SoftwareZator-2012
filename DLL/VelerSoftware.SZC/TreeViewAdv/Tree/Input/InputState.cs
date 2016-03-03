// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using System.Windows.Forms;

namespace VelerSoftware.SZC.TreeViewAdv.Tree
{
    internal abstract class InputState
    {
        private TreeViewAdv _tree;

        public TreeViewAdv Tree
        {
            get { return _tree; }
        }

        public InputState(TreeViewAdv tree)
        {
            _tree = tree;
        }

        public abstract void KeyDown(System.Windows.Forms.KeyEventArgs args);

        public abstract void MouseDown(TreeNodeAdvMouseEventArgs args);

        public abstract void MouseUp(TreeNodeAdvMouseEventArgs args);

        /// <summary>
        /// handle OnMouseMove event
        /// </summary>
        /// <param name="args"></param>
        /// <returns>true if event was handled and should be dispatched</returns>
        public virtual bool MouseMove(MouseEventArgs args)
        {
            return false;
        }
    }
}