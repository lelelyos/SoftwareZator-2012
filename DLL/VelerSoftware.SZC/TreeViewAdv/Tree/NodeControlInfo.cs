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
using VelerSoftware.SZC.TreeViewAdv.Tree.NodeControls;

namespace VelerSoftware.SZC.TreeViewAdv.Tree
{
    public struct NodeControlInfo
    {
        public static readonly NodeControlInfo Empty = new NodeControlInfo(null, Rectangle.Empty, null);

        private NodeControl _control;

        public NodeControl Control
        {
            get { return _control; }
        }

        private Rectangle _bounds;

        public Rectangle Bounds
        {
            get { return _bounds; }
        }

        private TreeNodeAdv _node;

        public TreeNodeAdv Node
        {
            get { return _node; }
        }

        public NodeControlInfo(NodeControl control, Rectangle bounds, TreeNodeAdv node)
        {
            _control = control;
            _bounds = bounds;
            _node = node;
        }
    }
}