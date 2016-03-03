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
    public class TreePathEventArgs : EventArgs
    {
        private TreePath _path;

        public TreePath Path
        {
            get { return _path; }
        }

        public TreePathEventArgs()
        {
            _path = new TreePath();
        }

        public TreePathEventArgs(TreePath path)
        {
            if (path == null)
                throw new ArgumentNullException();

            _path = path;
        }
    }
}