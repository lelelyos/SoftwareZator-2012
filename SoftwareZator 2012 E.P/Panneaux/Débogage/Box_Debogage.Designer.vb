''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BoxDebogage
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BoxDebogage))
        Me.KryptonSplitContainer1 = New VelerSoftware.Design.Toolkit.KryptonSplitContainer()
        Me.TreeViewAdv1 = New VelerSoftware.SZC.TreeViewAdv.Tree.TreeViewAdv()
        Me.TreeColumn1 = New VelerSoftware.SZC.TreeViewAdv.Tree.TreeColumn()
        Me.TreeColumn2 = New VelerSoftware.SZC.TreeViewAdv.Tree.TreeColumn()
        Me.TreeColumn3 = New VelerSoftware.SZC.TreeViewAdv.Tree.TreeColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KryptonButton1 = New VelerSoftware.Design.Toolkit.KryptonButton()
        Me.KryptonRichTextBox1 = New VelerSoftware.Design.Toolkit.KryptonRichTextBox()
        Me.KryptonContextMenu1 = New VelerSoftware.Design.Toolkit.KryptonContextMenu()
        Me.KryptonContextMenuItems1 = New VelerSoftware.Design.Toolkit.KryptonContextMenuItems()
        Me.KryptonContextMenuItem1 = New VelerSoftware.Design.Toolkit.KryptonContextMenuItem()
        Me.KryptonLabel1 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.kryptonPanel = New VelerSoftware.Design.Toolkit.KryptonPanel()
        Me.KryptonBreadCrumbItem1 = New VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem()
        Me.KryptonBreadCrumbItem2 = New VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem()
        Me.KryptonBreadCrumbItem6 = New VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem()
        Me.KryptonBreadCrumbItem7 = New VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem()
        Me.KryptonBreadCrumbItem8 = New VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem()
        Me.KryptonBreadCrumbItem9 = New VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem()
        Me.KryptonBreadCrumbItem3 = New VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem()
        Me.KryptonBreadCrumbItem4 = New VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem()
        Me.KryptonBreadCrumbItem5 = New VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem()
        DirectCast(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel1.SuspendLayout()
        Me.KryptonSplitContainer1.Panel2.SuspendLayout()
        Me.KryptonSplitContainer1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonSplitContainer1
        '
        Me.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonSplitContainer1, "KryptonSplitContainer1")
        Me.KryptonSplitContainer1.Name = "KryptonSplitContainer1"
        '
        'KryptonSplitContainer1.Panel1
        '
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.TreeViewAdv1)
        Me.KryptonSplitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonSplitContainer1.Panel1, "KryptonSplitContainer1.Panel1")
        '
        'KryptonSplitContainer1.Panel2
        '
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonButton1)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonRichTextBox1)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonLabel1)
        Me.KryptonSplitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonSplitContainer1.Panel2, "KryptonSplitContainer1.Panel2")
        '
        'TreeViewAdv1
        '
        Me.TreeViewAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.TreeViewAdv1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeViewAdv1.Columns.Add(Me.TreeColumn1)
        Me.TreeViewAdv1.Columns.Add(Me.TreeColumn2)
        Me.TreeViewAdv1.Columns.Add(Me.TreeColumn3)
        Me.TreeViewAdv1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TreeViewAdv1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TreeViewAdv1.DefaultToolTipProvider = Nothing
        resources.ApplyResources(Me.TreeViewAdv1, "TreeViewAdv1")
        Me.TreeViewAdv1.DragDropMarkColor = System.Drawing.Color.Black
        Me.TreeViewAdv1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.TreeViewAdv1.FullRowSelect = True
        Me.TreeViewAdv1.GridLineStyle = CType((VelerSoftware.SZC.TreeViewAdv.Tree.GridLineStyle.Horizontal Or VelerSoftware.SZC.TreeViewAdv.Tree.GridLineStyle.Vertical), VelerSoftware.SZC.TreeViewAdv.Tree.GridLineStyle)
        Me.TreeViewAdv1.LineColor = System.Drawing.SystemColors.ControlDark
        Me.TreeViewAdv1.Model = Nothing
        Me.TreeViewAdv1.Name = "TreeViewAdv1"
        Me.TreeViewAdv1.SelectedNode = Nothing
        Me.TreeViewAdv1.UseColumns = True
        '
        'TreeColumn1
        '
        resources.ApplyResources(Me.TreeColumn1, "TreeColumn1")
        Me.TreeColumn1.SortOrder = System.Windows.Forms.SortOrder.None
        '
        'TreeColumn2
        '
        resources.ApplyResources(Me.TreeColumn2, "TreeColumn2")
        Me.TreeColumn2.SortOrder = System.Windows.Forms.SortOrder.None
        '
        'TreeColumn3
        '
        resources.ApplyResources(Me.TreeColumn3, "TreeColumn3")
        Me.TreeColumn3.SortOrder = System.Windows.Forms.SortOrder.None
        '
        'ContextMenuStrip1
        '
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopierToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        '
        'CopierToolStripMenuItem
        '
        Me.CopierToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.copy_small
        Me.CopierToolStripMenuItem.Name = "CopierToolStripMenuItem"
        resources.ApplyResources(Me.CopierToolStripMenuItem, "CopierToolStripMenuItem")
        '
        'KryptonButton1
        '
        resources.ApplyResources(Me.KryptonButton1, "KryptonButton1")
        Me.KryptonButton1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Values.Text = resources.GetString("KryptonButton1.Values.Text")
        '
        'KryptonRichTextBox1
        '
        Me.KryptonRichTextBox1.AllowButtonSpecToolTips = True
        resources.ApplyResources(Me.KryptonRichTextBox1, "KryptonRichTextBox1")
        Me.KryptonRichTextBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonRichTextBox1.KryptonContextMenu = Me.KryptonContextMenu1
        Me.KryptonRichTextBox1.Name = "KryptonRichTextBox1"
        Me.KryptonRichTextBox1.ReadOnly = True
        '
        'KryptonContextMenu1
        '
        Me.KryptonContextMenu1.Items.AddRange(New VelerSoftware.Design.Toolkit.KryptonContextMenuItemBase() {Me.KryptonContextMenuItems1})
        '
        'KryptonContextMenuItems1
        '
        Me.KryptonContextMenuItems1.Items.AddRange(New VelerSoftware.Design.Toolkit.KryptonContextMenuItemBase() {Me.KryptonContextMenuItem1})
        '
        'KryptonContextMenuItem1
        '
        Me.KryptonContextMenuItem1.Image = Global.SoftwareZator.My.Resources.Resources.copy_small
        resources.ApplyResources(Me.KryptonContextMenuItem1, "KryptonContextMenuItem1")
        '
        'KryptonLabel1
        '
        resources.ApplyResources(Me.KryptonLabel1, "KryptonLabel1")
        Me.KryptonLabel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Values.Text = resources.GetString("KryptonLabel1.Values.Text")
        '
        'kryptonPanel
        '
        Me.kryptonPanel.Controls.Add(Me.KryptonSplitContainer1)
        Me.kryptonPanel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.kryptonPanel, "kryptonPanel")
        Me.kryptonPanel.Name = "kryptonPanel"
        '
        'KryptonBreadCrumbItem1
        '
        resources.ApplyResources(Me.KryptonBreadCrumbItem1, "KryptonBreadCrumbItem1")
        '
        'KryptonBreadCrumbItem2
        '
        Me.KryptonBreadCrumbItem2.Items.AddRange(New VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem() {Me.KryptonBreadCrumbItem6})
        resources.ApplyResources(Me.KryptonBreadCrumbItem2, "KryptonBreadCrumbItem2")
        '
        'KryptonBreadCrumbItem6
        '
        Me.KryptonBreadCrumbItem6.Items.AddRange(New VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem() {Me.KryptonBreadCrumbItem7})
        resources.ApplyResources(Me.KryptonBreadCrumbItem6, "KryptonBreadCrumbItem6")
        '
        'KryptonBreadCrumbItem7
        '
        Me.KryptonBreadCrumbItem7.Items.AddRange(New VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem() {Me.KryptonBreadCrumbItem8})
        resources.ApplyResources(Me.KryptonBreadCrumbItem7, "KryptonBreadCrumbItem7")
        '
        'KryptonBreadCrumbItem8
        '
        Me.KryptonBreadCrumbItem8.Items.AddRange(New VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem() {Me.KryptonBreadCrumbItem9})
        resources.ApplyResources(Me.KryptonBreadCrumbItem8, "KryptonBreadCrumbItem8")
        '
        'KryptonBreadCrumbItem9
        '
        resources.ApplyResources(Me.KryptonBreadCrumbItem9, "KryptonBreadCrumbItem9")
        '
        'KryptonBreadCrumbItem3
        '
        resources.ApplyResources(Me.KryptonBreadCrumbItem3, "KryptonBreadCrumbItem3")
        '
        'KryptonBreadCrumbItem4
        '
        resources.ApplyResources(Me.KryptonBreadCrumbItem4, "KryptonBreadCrumbItem4")
        '
        'KryptonBreadCrumbItem5
        '
        resources.ApplyResources(Me.KryptonBreadCrumbItem5, "KryptonBreadCrumbItem5")
        '
        'BoxDebogage
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kryptonPanel)
        Me.Name = "BoxDebogage"
        Me.KryptonSplitContainer1.Panel1.ResumeLayout(False)
        Me.KryptonSplitContainer1.Panel2.ResumeLayout(False)
        Me.KryptonSplitContainer1.Panel2.PerformLayout()
        DirectCast(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents kryptonPanel As VelerSoftware.Design.Toolkit.KryptonPanel
    Friend WithEvents KryptonSplitContainer1 As VelerSoftware.Design.Toolkit.KryptonSplitContainer
    Friend WithEvents KryptonBreadCrumbItem1 As VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents KryptonBreadCrumbItem2 As VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents KryptonBreadCrumbItem6 As VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents KryptonBreadCrumbItem7 As VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents KryptonBreadCrumbItem8 As VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents KryptonBreadCrumbItem9 As VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents KryptonBreadCrumbItem3 As VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents KryptonBreadCrumbItem4 As VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents KryptonBreadCrumbItem5 As VelerSoftware.Design.Toolkit.KryptonBreadCrumbItem
    Friend WithEvents TreeViewAdv1 As VelerSoftware.SZC.TreeViewAdv.Tree.TreeViewAdv
    Friend WithEvents TreeColumn1 As VelerSoftware.SZC.TreeViewAdv.Tree.TreeColumn
    Friend WithEvents TreeColumn2 As VelerSoftware.SZC.TreeViewAdv.Tree.TreeColumn
    Friend WithEvents TreeColumn3 As VelerSoftware.SZC.TreeViewAdv.Tree.TreeColumn
    Friend WithEvents KryptonButton1 As VelerSoftware.Design.Toolkit.KryptonButton
    Friend WithEvents KryptonRichTextBox1 As VelerSoftware.Design.Toolkit.KryptonRichTextBox
    Friend WithEvents KryptonLabel1 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonContextMenu1 As VelerSoftware.Design.Toolkit.KryptonContextMenu
    Friend WithEvents KryptonContextMenuItems1 As VelerSoftware.Design.Toolkit.KryptonContextMenuItems
    Friend WithEvents KryptonContextMenuItem1 As VelerSoftware.Design.Toolkit.KryptonContextMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
