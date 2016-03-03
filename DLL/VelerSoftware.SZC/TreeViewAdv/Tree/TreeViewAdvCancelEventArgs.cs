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
    public class TreeViewAdvCancelEventArgs : TreeViewAdvEventArgs
    {
        private bool _cancel;

        public bool Cancel
        {
            get { return _cancel; }
            set { _cancel = value; }
        }

        public TreeViewAdvCancelEventArgs(TreeNodeAdv node)
            : base(node)
        {
        }
    }
}