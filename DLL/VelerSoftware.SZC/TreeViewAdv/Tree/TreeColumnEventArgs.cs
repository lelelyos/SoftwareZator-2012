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

namespace VelerSoftware.SZC.TreeViewAdv.Tree
{
    public class TreeColumnEventArgs : EventArgs
    {
        private TreeColumn _column;

        public TreeColumn Column
        {
            get { return _column; }
        }

        public TreeColumnEventArgs(TreeColumn column)
        {
            _column = column;
        }
    }
}