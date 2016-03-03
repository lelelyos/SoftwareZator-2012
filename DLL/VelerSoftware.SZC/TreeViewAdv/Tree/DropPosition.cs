// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

namespace VelerSoftware.SZC.TreeViewAdv.Tree
{
    public struct DropPosition
    {
        private TreeNodeAdv _node;

        public TreeNodeAdv Node
        {
            get { return _node; }
            set { _node = value; }
        }

        private NodePosition _position;

        public NodePosition Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }
}