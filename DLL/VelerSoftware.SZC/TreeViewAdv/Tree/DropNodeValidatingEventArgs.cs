// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using System;
using System.Drawing;

namespace VelerSoftware.SZC.TreeViewAdv.Tree
{
    public class DropNodeValidatingEventArgs : EventArgs
    {
        Point _point;
        TreeNodeAdv _node;

        public DropNodeValidatingEventArgs(Point point, TreeNodeAdv node)
        {
            _point = point;
            _node = node;
        }

        public Point Point
        {
            get { return _point; }
        }

        public TreeNodeAdv Node
        {
            get { return _node; }
            set { _node = value; }
        }
    }
}