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
    public struct EditorContext
    {
        private TreeNodeAdv _currentNode;

        public TreeNodeAdv CurrentNode
        {
            get { return _currentNode; }
            set { _currentNode = value; }
        }

        private Control _editor;

        public Control Editor
        {
            get { return _editor; }
            set { _editor = value; }
        }

        private NodeControl _owner;

        public NodeControl Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        private Rectangle _bounds;

        public Rectangle Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }

        private DrawContext _drawContext;

        public DrawContext DrawContext
        {
            get { return _drawContext; }
            set { _drawContext = value; }
        }
    }
}