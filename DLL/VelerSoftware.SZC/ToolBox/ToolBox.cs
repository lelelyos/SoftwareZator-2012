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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VelerSoftware.SZC.ToolBox
{
    [ToolboxItem(true)]
    [ToolboxBitmap(@"ToolBoxBmp")]
    public partial class ToolBox : TreeView
    {
        #region Local classes

        public class VSTreeNode : TreeNode
        {
            #region Private fields

            private string mToolTipCaption;
            private string mFileHelp;
            private bool mOnEdit;
            private bool mEnabled;

            #endregion Private fields

            #region Public properties

            public string ToolTipCaption
            {
                get
                {
                    return this.mToolTipCaption;
                }
                set
                {
                    this.mToolTipCaption = value;
                }
            }

            public string FileHelp
            {
                get
                {
                    return this.mFileHelp;
                }
                set
                {
                    this.mFileHelp = value;
                }
            }

            public bool OnEdit
            {
                get
                {
                    return this.mOnEdit;
                }
                set
                {
                    this.mOnEdit = value;
                }
            }

            public bool Enabled
            {
                get
                {
                    return this.mEnabled;
                }
                set
                {
                    this.mEnabled = value;
                }
            }

            #endregion Public properties

            #region Constructor / Destructor

            public VSTreeNode()
                : base()
            {
                this.mToolTipCaption = string.Empty;
                this.mOnEdit = false;
                this.mEnabled = true;
            }

            public VSTreeNode(string _text, string _name, Type _tip, string _filehelp, string _ToolTipCaption, string _ToolTipText)
                : base()
            {
                this.mToolTipCaption = string.Empty;
                this.mOnEdit = false;
                this.mEnabled = true;
                this.Text = _text;
                this.Name = _name;
                this.Tag = _tip;
                this.FileHelp = _filehelp;
                this.ToolTipCaption = _ToolTipCaption;
                this.ToolTipText = _ToolTipText;
            }

            public VSTreeNode(string _text, string _name, string _tip, string _filehelp, string _ToolTipCaption, string _ToolTipText)
                : base()
            {
                this.mToolTipCaption = string.Empty;
                this.mOnEdit = false;
                this.mEnabled = true;
                this.Text = _text;
                this.Name = _name;
                this.Tag = _tip;
                this.FileHelp = _filehelp;
                this.ToolTipCaption = _ToolTipCaption;
                this.ToolTipText = _ToolTipText;
            }

            public VSTreeNode(string _text)
                : base(_text)
            {
                this.mToolTipCaption = string.Empty;
                this.mOnEdit = false;
                this.mEnabled = true;
                this.Name = _text;
            }

            #endregion Constructor / Destructor
        }

        #endregion Local classes

        #region Private consts

        /// <summary>
        /// This is needed to disable the default tooltips
        /// of a treenode item.
        /// </summary>
        private const int TVS_NOTOOLTIPS = 0x80;

        #endregion Private consts

        #region Private fields

        /// <summary>
        /// Font to be used for the group headers in the toolbox.
        /// </summary>
        private Font mGroupHeaderFont;

        /// <summary>
        /// Custom tooltip for the treenodes.
        /// </summary>
        private ToolTip mToolTip;

        /// <summary>
        /// Stores the last mouse position for the custom tooltip.
        /// </summary>
        private TreeNode mPreviousNode;

        /// <summary>
        /// Textbox used for label edit.
        /// </summary>
        private TextBox mLabelEditBox;

        #endregion Private fields

        #region Protected properties

        /// <summary>
        /// Gets the create params property.
        ///
        /// Disables the tooltip activity for the treenodes.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;
                p.Style = p.Style | TVS_NOTOOLTIPS;
                return p;
            }
        }

        #endregion Protected properties

        #region Private methods

        /// <summary>
        /// Draws a group header
        /// </summary>
        private void drawRootItem(DrawTreeNodeEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle nodeTextRect = e.Bounds;

                nodeTextRect.Y += 1;
                nodeTextRect.Width -= 1;
                nodeTextRect.Height -= 3;

                if ((e.State & TreeNodeStates.Marked) == TreeNodeStates.Marked
                    || (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected)
                {
                    using (Brush selBrush = new SolidBrush(this.BackColor))
                    {
                        e.Graphics.FillRectangle(selBrush, nodeTextRect);
                    }

                    if ((this.BackColor.R + 22) == 257)
                    {   
                        using (Pen outerPen = new Pen(Color.FromArgb(255, this.BackColor.G + 17, this.BackColor.B + 11)))
                        {
                            e.Graphics.DrawRectangle(outerPen, nodeTextRect);
                        }
                    }
                    else
                    {
                        using (Pen outerPen = new Pen(Color.FromArgb(this.BackColor.R + 22, this.BackColor.G + 17, this.BackColor.B + 11)))
                        {
                            e.Graphics.DrawRectangle(outerPen, nodeTextRect);
                        }
                    }
                }
                else
                {

                    if ((this.BackColor.R + 22) == 257)
                    {
                        using (LinearGradientBrush lgBrush = new LinearGradientBrush(
                            e.Bounds, Color.FromArgb(255, this.BackColor.G + 17, this.BackColor.B + 11), this.BackColor, LinearGradientMode.Vertical))
                        {
                            e.Graphics.FillRectangle(lgBrush, nodeTextRect);
                        }
                    }
                    else
                    {
                        using (LinearGradientBrush lgBrush = new LinearGradientBrush(
                            e.Bounds, Color.FromArgb(this.BackColor.R + 22, this.BackColor.G + 17, this.BackColor.B + 11), this.BackColor, LinearGradientMode.Vertical))
                        {
                            e.Graphics.FillRectangle(lgBrush, nodeTextRect);
                        }
                    }

                    using (Pen linePen = new Pen(this.BackColor))
                    {
                        //e.Graphics.DrawLine(linePen, 0, nodeTextRect.Bottom - 2, nodeTextRect.Width, nodeTextRect.Bottom - 2);
                    }
                }

                if (e.Node.IsExpanded == true)
                {
                    e.Graphics.DrawImage(Properties.Resources.minus, new Point(nodeTextRect.Left + 3, nodeTextRect.Top + 4));
                }
                else
                {
                    e.Graphics.DrawImage(Properties.Resources.plus, new Point(nodeTextRect.Left + 3, nodeTextRect.Top + 4));
                }

                nodeTextRect.Offset(20, 0);

                e.Graphics.DrawString(e.Node.Text, this.mGroupHeaderFont, new SolidBrush(this.ForeColor), nodeTextRect.Location);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Draws a sub item of a group
        /// </summary>
        /// <param name="e"></param>
        private void drawItem(DrawTreeNodeEventArgs e)
        {
            //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle nodeTextRect = e.Bounds;

            nodeTextRect.Width -= 1;
            nodeTextRect.Height -= 1;

            if ((e.Node as VSTreeNode).OnEdit)
            {
                e.Graphics.FillRectangle(SystemBrushes.Window, nodeTextRect);

                using (Pen clearBGPen = new Pen(Color.FromArgb(236, 199, 87)))
                {
                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(236, 199, 87)), nodeTextRect);
                }

                if (this.ImageList != null)
                {
                    if (e.Node.ImageIndex != -1 && e.Node.ImageIndex < this.ImageList.Images.Count && this.ImageList.Images[e.Node.ImageIndex] != null)
                    {
                        e.Graphics.DrawImage(this.ImageList.Images[e.Node.ImageIndex], new Point(e.Bounds.Left + 3, e.Bounds.Top + 2));
                    }
                    else if (e.Node.ImageKey != null && this.ImageList.Images[e.Node.ImageKey] != null)
                    {
                        e.Graphics.DrawImage(this.ImageList.Images[e.Node.ImageKey], new Point(e.Bounds.Left + 3, e.Bounds.Top + 2));
                    }
                }
            }
            else
            {
                if ((e.Node as VSTreeNode).Enabled)
                {
                    if ((e.State & TreeNodeStates.Hot) == TreeNodeStates.Hot)
                    {
                        using (Brush hoverBrush = new SolidBrush(this.BackColor))
                        {
                            e.Graphics.FillRectangle(hoverBrush, nodeTextRect);
                        }

                        using (Pen clearBGPen = new Pen(Color.FromArgb(236, 199, 87)))
                        {
                            e.Graphics.DrawRectangle(clearBGPen, nodeTextRect);
                        }
                    }
                    else
                    {
                        if ((e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected)
                        {
                            using (Brush hoverBrush = new SolidBrush(Color.FromArgb(255, 234, 176)))
                            {
                                e.Graphics.FillRectangle(hoverBrush, nodeTextRect);
                            }

                            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(236, 199, 87)), nodeTextRect);
                        }
                        else
                        {
                            using (Brush hoverBrush = new SolidBrush(this.BackColor))
                            {
                                e.Graphics.FillRectangle(hoverBrush, e.Bounds);
                            }
                        }
                    }

                    if (this.ImageList != null)
                    {
                        if (e.Node.ImageIndex != -1 && e.Node.ImageIndex < this.ImageList.Images.Count && this.ImageList.Images[e.Node.ImageIndex] != null)
                        {
                            e.Graphics.DrawImage(this.ImageList.Images[e.Node.ImageIndex], new Point(e.Bounds.Left + 3, e.Bounds.Top + 2));
                        }
                        else if (e.Node.ImageKey != null && this.ImageList.Images[e.Node.ImageKey] != null)
                        {
                            e.Graphics.DrawImage(this.ImageList.Images[e.Node.ImageKey], new Point(e.Bounds.Left + 3, e.Bounds.Top + 2));
                        }
                    }

                    nodeTextRect.Offset(20, 3);
                    e.Graphics.DrawString(e.Node.Text, this.Font, new SolidBrush(this.ForeColor), new Rectangle(nodeTextRect.X, nodeTextRect.Y, nodeTextRect.Width - 20, nodeTextRect.Height));
                }
                else
                {
                    using (Brush hoverBrush = new SolidBrush(this.BackColor))
                    {
                        e.Graphics.FillRectangle(hoverBrush, e.Bounds);
                    }

                    if (this.ImageList != null)
                    {
                        if (e.Node.ImageIndex != -1 && e.Node.ImageIndex < this.ImageList.Images.Count && this.ImageList.Images[e.Node.ImageIndex] != null)
                        {
                            ControlPaint.DrawImageDisabled(e.Graphics, this.ImageList.Images[e.Node.ImageIndex],
                        e.Bounds.Left + 3, e.Bounds.Top + 2, this.BackColor);
                        }
                        else if (e.Node.ImageKey != null && this.ImageList.Images[e.Node.ImageKey] != null)
                        {
                            ControlPaint.DrawImageDisabled(e.Graphics, this.ImageList.Images[e.Node.ImageKey],
                        e.Bounds.Left + 3, e.Bounds.Top + 2, this.BackColor);
                        }
                    }

                    nodeTextRect.Offset(20, 3);
                    ControlPaint.DrawStringDisabled(e.Graphics, e.Node.Text, this.Font, this.BackColor, nodeTextRect,
                      new StringFormat());
                }
            }
        }

        /// <summary>
        /// Handles the end edit event.
        ///
        /// Hides the edit text box and stores the entered
        /// value if needed.
        /// </summary>
        /// <param name="setNewValues">Bool if the new text should be stored.</param>
        private void endLabelEdit(bool setNewValues)
        {
            if (setNewValues == true && this.mLabelEditBox.Tag != null)
            {
                (this.mLabelEditBox.Tag as VSTreeNode).Text = this.mLabelEditBox.Text;
            }

            this.mLabelEditBox.Visible = false;

            if (this.mLabelEditBox.Tag != null)
            {
                (this.mLabelEditBox.Tag as VSTreeNode).OnEdit = false;
                this.mLabelEditBox.Tag = null;
            }

            Invalidate();
        }

        /// <summary>
        /// Handles the lost forcus event of the edit text box.
        ///
        /// Ends the label editing by calling the coresponding method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mLabelEditBox_LostFocus(object sender, EventArgs e)
        {
            endLabelEdit(false);
        }

        /// <summary>
        /// Handles the key down event.
        ///
        /// Calls the end label edit method and decides epending on the
        /// pressed key if the nw test should be stored.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mLabelEditBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        endLabelEdit(false);
                        break;
                    }
                case Keys.Enter:
                    {
                        endLabelEdit(true);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        #endregion Private methods

        #region Protected methods

        /// <summary>
        /// Decides wich node type should be drawn and calls the coresponding.
        /// methods.
        /// </summary>
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                drawRootItem(e);
            }
            else
            {
                drawItem(e);
            }
        }

        /// <summary>
        /// Handles the mouse down event
        ///
        /// Selects the node under the mouse cursor.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            TreeViewHitTestInfo hitTestInfo = this.HitTest(e.X, e.Y);

            if (hitTestInfo.Node != null
            && hitTestInfo.Location != TreeViewHitTestLocations.PlusMinus
            && (hitTestInfo.Node as VSTreeNode).Enabled == true)
            {
                this.SelectedNode = hitTestInfo.Node;

                if (hitTestInfo.Node.Level == 0)
                {
                    if (hitTestInfo.Node.IsExpanded == true)
                    {
                        hitTestInfo.Node.Collapse();
                    }
                    else
                    {
                        hitTestInfo.Node.Expand();
                    }
                }
            }

            base.OnMouseDown(e);
        }

        /// <summary>
        /// Handles the mouse move event
        ///
        /// Checks if the node under the cursor contains a tooltip
        /// and display it.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            VSTreeNode currentNode = GetNodeAt(e.X, e.Y) as VSTreeNode;

            if (currentNode == null || this.mPreviousNode == currentNode)
            {
                // Nothing to show. Let's return.
                return;
            }

            if (currentNode.ToolTipText == String.Empty)
            {
                // This item doesn'n contain a tooltip text.
                // Hide the tooltip.
                if (this.mToolTip != null)
                {
                    this.mToolTip.Dispose();
                    this.mToolTip = null;
                }

                return;
            }

            // Store the current node.
            this.mPreviousNode = currentNode;

            string toolTipCaption = currentNode.ToolTipCaption;
            string toolTipText = currentNode.ToolTipText;

            // Turn off the tooltip so we can change the text.
            if (this.mToolTip != null && this.mToolTip.Active)
            {
                this.mToolTip.Dispose();
                this.mToolTip = null;
            }

            // Change the tooltip text.
            this.mToolTip = new ToolTip();
            this.mToolTip.ToolTipTitle = toolTipCaption;
            this.mToolTip.SetToolTip(this, toolTipText);

            // Turn on the tooltip .
            this.mToolTip.Active = true;
        }

        /// <summary>
        /// Handles the OnBeforeLabelEdit event
        ///
        /// Adds a textbox to the current label position to
        /// handle the label editing by itself.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnBeforeLabelEdit(NodeLabelEditEventArgs e)
        {
            e.CancelEdit = true;

            if ((e.Node as VSTreeNode).Enabled)
            {
                (e.Node as VSTreeNode).OnEdit = true;

                mLabelEditBox.Bounds = new Rectangle(
                  22, e.Node.Bounds.Top + 3, e.Node.Bounds.Width, e.Node.Bounds.Height + 4);

                mLabelEditBox.Text = e.Node.Text;
                mLabelEditBox.Visible = true;
                mLabelEditBox.Tag = e.Node;

                mLabelEditBox.Focus();
                mLabelEditBox.SelectAll();
            }
        }

        /// <summary>
        /// Handles the OnBeforeSelect event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            if (!(e.Node as VSTreeNode).Enabled)
            {
                e.Cancel = true;
            }

            base.OnBeforeSelect(e);
        }

        #endregion Protected methods

        #region Constructor / Destructor

        /// <summary>
        /// Creates a new VS 2005 ToolBox like control.
        /// </summary>
        public ToolBox()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

            this.mGroupHeaderFont = new Font("Segoe UI",
              9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            this.ShowLines = false;
            this.HotTracking = true;
            this.FullRowSelect = true;
            this.DrawMode = TreeViewDrawMode.OwnerDrawAll;

            this.mPreviousNode = null;

            this.mToolTip = new ToolTip();

            this.mLabelEditBox = new TextBox();
            this.mLabelEditBox.BorderStyle = BorderStyle.None;
            this.mLabelEditBox.Visible = false;
            this.mLabelEditBox.LostFocus += new EventHandler(mLabelEditBox_LostFocus);
            this.mLabelEditBox.KeyDown += new KeyEventHandler(mLabelEditBox_KeyDown);

            this.Controls.Add(this.mLabelEditBox);
        }

        #endregion Constructor / Destructor
    }
}