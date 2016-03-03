// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using System.Drawing;
using System.Windows.Forms;
using VelerSoftware.SZC.TreeViewAdv.Tree.NodeControls;

namespace VelerSoftware.SZC.TreeViewAdv.Tree
{
    public class TreeNodeAdvMouseEventArgs : MouseEventArgs
    {
        private TreeNodeAdv _node;

        public TreeNodeAdv Node
        {
            get { return _node; }
            internal set { _node = value; }
        }

        private NodeControl _control;

        public NodeControl Control
        {
            get { return _control; }
            internal set { _control = value; }
        }

        private Point _viewLocation;

        public Point ViewLocation
        {
            get { return _viewLocation; }
            internal set { _viewLocation = value; }
        }

        private Keys _modifierKeys;

        public Keys ModifierKeys
        {
            get { return _modifierKeys; }
            internal set { _modifierKeys = value; }
        }

        private bool _handled;

        public bool Handled
        {
            get { return _handled; }
            set { _handled = value; }
        }

        private Rectangle _controlBounds;

        public Rectangle ControlBounds
        {
            get { return _controlBounds; }
            internal set { _controlBounds = value; }
        }

        public TreeNodeAdvMouseEventArgs(MouseEventArgs args)
            : base(args.Button, args.Clicks, args.X, args.Y, args.Delta)
        {
        }
    }
}