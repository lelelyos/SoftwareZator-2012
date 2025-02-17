// *****************************************************************************
// 
//  � Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

namespace VelerSoftware.SZC.TreeViewAdv.Tree.NodeControls
{
    public class NodeControlValueEventArgs : NodeEventArgs
    {
        private object _value;

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public NodeControlValueEventArgs(TreeNodeAdv node)
            : base(node)
        {
        }
    }
}