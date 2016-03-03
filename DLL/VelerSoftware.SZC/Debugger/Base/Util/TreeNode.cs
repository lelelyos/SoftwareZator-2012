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
using System.Collections.Generic;

namespace VelerSoftware.SZC.Debugger.Base
{
    /// <summary>
    /// Generic TreeNode with content and children.
    /// </summary>
    public interface ITreeNode<TContent>
    {
        TContent Content { get; }

        IEnumerable<ITreeNode<TContent>> Children { get; }
    }

    public class TreeNode<TContent> : ITreeNode<TContent>
    {
        public TreeNode(TContent content)
        {
            if (content == null)
                throw new ArgumentNullException("content");
            this.Content = content;
        }

        public TContent Content { get; private set; }

        public IEnumerable<ITreeNode<TContent>> Children { get; set; }

        public override string ToString()
        {
            return string.Format("[TreeNode {0}]", this.Content.ToString());
        }
    }
}