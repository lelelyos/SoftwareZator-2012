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
    internal class InputWithControl : NormalInputState
    {
        public InputWithControl(TreeViewAdv tree)
            : base(tree)
        {
        }

        protected override void DoMouseOperation(TreeNodeAdvMouseEventArgs args)
        {
            if (Tree.SelectionMode == TreeSelectionMode.Single)
            {
                base.DoMouseOperation(args);
            }
            else if (CanSelect(args.Node))
            {
                args.Node.IsSelected = !args.Node.IsSelected;
                Tree.SelectionStart = args.Node;
            }
        }

        protected override void MouseDownAtEmptySpace(TreeNodeAdvMouseEventArgs args)
        {
        }
    }
}