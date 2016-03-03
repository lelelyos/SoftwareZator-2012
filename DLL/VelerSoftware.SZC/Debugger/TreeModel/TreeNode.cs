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
using System.Drawing;
using System.Linq;

using VelerSoftware.SZC.Debugger.Base.Debugging;

namespace VelerSoftware.SZC.Debugger.TreeModel
{
    /// <summary>
    /// A node in the variable tree.
    /// The node is imutable.
    /// </summary>
    public class TreeNode : IComparable<TreeNode>, ITreeNode
    {
        string name = string.Empty;
        string text = string.Empty;
        string type = string.Empty;
        IEnumerable<TreeNode> childNodes = null;
        Image img = null;

        /// <summary>
        /// System.Drawing.Image version of <see cref="IconImage"/>.
        /// </summary>
        public Image Image
        {
            get
            {
                return img;
            }
            set
            {
                img = value;
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string Text
        {
            get { return text; }
            protected set { text = value; }
        }

        public virtual string Type
        {
            get { return type; }
            protected set { type = value; }
        }

        public virtual IEnumerable<TreeNode> ChildNodes
        {
            get { return childNodes; }
            protected set { childNodes = value; }
        }

        IEnumerable<ITreeNode> ITreeNode.ChildNodes
        {
            get { return childNodes; }
        }

        public virtual bool HasChildNodes
        {
            get { return childNodes != null; }
        }

        public virtual IEnumerable<IVisualizerCommand> VisualizerCommands
        {
            get
            {
                return null;
            }
        }

        public virtual bool HasVisualizerCommands
        {
            get
            {
                return (VisualizerCommands != null) && (VisualizerCommands.Count() > 0);
            }
        }

        public TreeNode()
        {
        }

        public TreeNode(Image iconImage, string name, string text, string type, IEnumerable<TreeNode> childNodes)
        {
            this.img = iconImage;
            this.name = name;
            this.text = text;
            this.type = type;
            this.childNodes = childNodes;
        }

        public int CompareTo(TreeNode other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}