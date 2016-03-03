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
    public class TreeModelEventArgs : TreePathEventArgs
    {
        private object[] _children;

        public object[] Children
        {
            get { return _children; }
        }

        private int[] _indices;

        public int[] Indices
        {
            get { return _indices; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parent">Path to a parent node</param>
        /// <param name="children">Child nodes</param>
        public TreeModelEventArgs(TreePath parent, object[] children)
            : this(parent, null, children)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parent">Path to a parent node</param>
        /// <param name="indices">Indices of children in parent nodes collection</param>
        /// <param name="children">Child nodes</param>
        public TreeModelEventArgs(TreePath parent, int[] indices, object[] children)
            : base(parent)
        {
            if (children == null)
                throw new ArgumentNullException();

            if (indices != null && indices.Length != children.Length)
                throw new ArgumentException("indices and children arrays must have the same length");

            _indices = indices;
            _children = children;
        }
    }
}