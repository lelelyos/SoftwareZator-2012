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
Partial Class BoxSortie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BoxSortie))
        Me.kryptonPanel = New VelerSoftware.Design.Toolkit.KryptonPanel()
        Me.KryptonRichTextBox1 = New VelerSoftware.Design.Toolkit.KryptonRichTextBox()
        Me.KryptonContextMenu1 = New VelerSoftware.Design.Toolkit.KryptonContextMenu()
        Me.KryptonContextMenuItems1 = New VelerSoftware.Design.Toolkit.KryptonContextMenuItems()
        Me.KryptonContextMenuItem1 = New VelerSoftware.Design.Toolkit.KryptonContextMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kryptonPanel.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'kryptonPanel
        '
        Me.kryptonPanel.Controls.Add(Me.KryptonRichTextBox1)
        Me.kryptonPanel.Controls.Add(Me.ToolStrip1)
        Me.kryptonPanel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.kryptonPanel, "kryptonPanel")
        Me.kryptonPanel.Name = "kryptonPanel"
        '
        'KryptonRichTextBox1
        '
        Me.KryptonRichTextBox1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonRichTextBox1, "KryptonRichTextBox1")
        Me.KryptonRichTextBox1.KryptonContextMenu = Me.KryptonContextMenu1
        Me.KryptonRichTextBox1.Name = "KryptonRichTextBox1"
        Me.KryptonRichTextBox1.ReadOnly = True
        Me.KryptonRichTextBox1.ShowSelectionMargin = True
        Me.KryptonRichTextBox1.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.KryptonRichTextBox1.StateActive.Content.Color1 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.KryptonRichTextBox1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.KryptonRichTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.KryptonRichTextBox1.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.KryptonRichTextBox1.StateDisabled.Content.Color1 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.KryptonRichTextBox1.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.KryptonRichTextBox1.StateNormal.Content.Color1 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
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
        'ToolStrip1
        '
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripComboBox1, Me.ToolStripButton2, Me.ToolStripButton1})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        resources.ApplyResources(Me.ToolStripLabel1, "ToolStripLabel1")
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox1.Items.AddRange(New Object() {resources.GetString("ToolStripComboBox1.Items"), resources.GetString("ToolStripComboBox1.Items1"), resources.GetString("ToolStripComboBox1.Items2")})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        resources.ApplyResources(Me.ToolStripComboBox1, "ToolStripComboBox1")
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.SoftwareZator.My.Resources.Resources.copy_small
        resources.ApplyResources(Me.ToolStripButton2, "ToolStripButton2")
        Me.ToolStripButton2.Name = "ToolStripButton2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.SoftwareZator.My.Resources.Resources.effacer_tout
        resources.ApplyResources(Me.ToolStripButton1, "ToolStripButton1")
        Me.ToolStripButton1.Name = "ToolStripButton1"
        '
        'BoxSortie
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kryptonPanel)
        Me.Name = "BoxSortie"
        CType(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonPanel.ResumeLayout(False)
        Me.kryptonPanel.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents kryptonPanel As VelerSoftware.Design.Toolkit.KryptonPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents KryptonRichTextBox1 As VelerSoftware.Design.Toolkit.KryptonRichTextBox
    Friend WithEvents KryptonContextMenu1 As VelerSoftware.Design.Toolkit.KryptonContextMenu
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents KryptonContextMenuItems1 As VelerSoftware.Design.Toolkit.KryptonContextMenuItems
    Friend WithEvents KryptonContextMenuItem1 As VelerSoftware.Design.Toolkit.KryptonContextMenuItem

End Class
