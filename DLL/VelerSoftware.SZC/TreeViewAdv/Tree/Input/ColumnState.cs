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
    internal abstract class ColumnState : InputState
    {
        private TreeColumn _column;

        public TreeColumn Column
        {
            get { return _column; }
        }

        public ColumnState(TreeViewAdv tree, TreeColumn column)
            : base(tree)
        {
            _column = column;
        }
    }
}