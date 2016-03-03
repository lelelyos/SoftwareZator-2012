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

namespace VelerSoftware.SZC.TreeViewAdv.Tree
{
    internal class ClickColumnState : ColumnState
    {
        private Point _location;

        public ClickColumnState(TreeViewAdv tree, TreeColumn column, Point location)
            : base(tree, column)
        {
            _location = location;
        }

        public override void KeyDown(KeyEventArgs args)
        {
        }

        public override void MouseDown(TreeNodeAdvMouseEventArgs args)
        {
        }

        public override bool MouseMove(MouseEventArgs args)
        {
            if (TreeViewAdv.Dist(_location, args.Location) > TreeViewAdv.ItemDragSensivity
                && Tree.AllowColumnReorder)
            {
                Tree.Input = new ReorderColumnState(Tree, Column, args.Location);
                Tree.UpdateView();
            }
            return true;
        }

        public override void MouseUp(TreeNodeAdvMouseEventArgs args)
        {
            Tree.ChangeInput();
            Tree.UpdateView();
            Tree.OnColumnClicked(Column);
        }
    }
}