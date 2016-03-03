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
using System.ComponentModel;

namespace VelerSoftware.SZC.TreeViewAdv.Tree.NodeControls
{
    public abstract class InteractiveControl : BindableControl
    {
        private bool _editEnabled = false;

        [DefaultValue(false)]
        public bool EditEnabled
        {
            get { return _editEnabled; }
            set { _editEnabled = value; }
        }

        protected bool IsEditEnabled(TreeNodeAdv node)
        {
            if (EditEnabled)
            {
                NodeControlValueEventArgs args = new NodeControlValueEventArgs(node);
                args.Value = true;
                OnIsEditEnabledValueNeeded(args);
                return Convert.ToBoolean(args.Value);
            }
            else
                return false;
        }

        public event EventHandler<NodeControlValueEventArgs> IsEditEnabledValueNeeded;

        private void OnIsEditEnabledValueNeeded(NodeControlValueEventArgs args)
        {
            if (IsEditEnabledValueNeeded != null)
                IsEditEnabledValueNeeded(this, args);
        }
    }
}