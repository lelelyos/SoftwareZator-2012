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
Partial Class BoxBasesDonnees
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BoxBasesDonnees))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.kryptonPanel = New VelerSoftware.Design.Toolkit.KryptonPanel()
        Me.TreeViewMultiSelect1 = New VelerSoftware.SZC.TreeViewMultiSelect.TreeViewMultiSelect()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OuvrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SupprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ActualiserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.MySQLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SQLServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kryptonPanel.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = DirectCast(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.ImageList1.Images.SetKeyName(0, "database_access.png")
        Me.ImageList1.Images.SetKeyName(1, "database_mysql.png")
        Me.ImageList1.Images.SetKeyName(2, "database_oracle.png")
        Me.ImageList1.Images.SetKeyName(3, "database_sql.png")
        Me.ImageList1.Images.SetKeyName(4, "bases_de_donnees.png")
        Me.ImageList1.Images.SetKeyName(5, "table.png")
        '
        'kryptonPanel
        '
        Me.kryptonPanel.Controls.Add(Me.TreeViewMultiSelect1)
        Me.kryptonPanel.Controls.Add(Me.ToolStrip1)
        Me.kryptonPanel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.kryptonPanel, "kryptonPanel")
        Me.kryptonPanel.Name = "kryptonPanel"
        '
        'TreeViewMultiSelect1
        '
        Me.TreeViewMultiSelect1.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.TreeViewMultiSelect1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeViewMultiSelect1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TreeViewMultiSelect1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TreeViewMultiSelect1, "TreeViewMultiSelect1")
        Me.TreeViewMultiSelect1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.TreeViewMultiSelect1.FullRowSelect = True
        Me.TreeViewMultiSelect1.ImageList = Me.ImageList1
        Me.TreeViewMultiSelect1.LabelEdit = True
        Me.TreeViewMultiSelect1.LineColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.TreeViewMultiSelect1.Name = "TreeViewMultiSelect1"
        Me.TreeViewMultiSelect1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(108, Byte), Integer))
        Me.TreeViewMultiSelect1.SelectionMode = VelerSoftware.SZC.TreeViewMultiSelect.TreeViewSelectionMode.SingleSelect
        Me.TreeViewMultiSelect1.ShowLines = False
        Me.TreeViewMultiSelect1.ShowNodeToolTips = True
        '
        'ContextMenuStrip1
        '
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OuvrirToolStripMenuItem, Me.ToolStripSeparator2, Me.SupprimerToolStripMenuItem, Me.ToolStripSeparator1, Me.ActualiserToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        '
        'OuvrirToolStripMenuItem
        '
        Me.OuvrirToolStripMenuItem.Name = "OuvrirToolStripMenuItem"
        resources.ApplyResources(Me.OuvrirToolStripMenuItem, "OuvrirToolStripMenuItem")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'SupprimerToolStripMenuItem
        '
        Me.SupprimerToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.delete
        Me.SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem"
        resources.ApplyResources(Me.SupprimerToolStripMenuItem, "SupprimerToolStripMenuItem")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'ActualiserToolStripMenuItem
        '
        Me.ActualiserToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.actualiser
        Me.ActualiserToolStripMenuItem.Name = "ActualiserToolStripMenuItem"
        resources.ApplyResources(Me.ActualiserToolStripMenuItem, "ActualiserToolStripMenuItem")
        '
        'ToolStrip1
        '
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripDropDownButton1, Me.ToolStripSeparator3, Me.ToolStripButton2, Me.ToolStripButton3})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MySQLToolStripMenuItem, Me.SQLServerToolStripMenuItem, Me.AccessToolStripMenuItem})
        Me.ToolStripButton1.Image = Global.SoftwareZator.My.Resources.Resources.nouvelle_bases_de_donnees
        resources.ApplyResources(Me.ToolStripButton1, "ToolStripButton1")
        Me.ToolStripButton1.Name = "ToolStripButton1"
        '
        'MySQLToolStripMenuItem
        '
        Me.MySQLToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.database_mysql
        Me.MySQLToolStripMenuItem.Name = "MySQLToolStripMenuItem"
        resources.ApplyResources(Me.MySQLToolStripMenuItem, "MySQLToolStripMenuItem")
        '
        'SQLServerToolStripMenuItem
        '
        Me.SQLServerToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.database_sql
        Me.SQLServerToolStripMenuItem.Name = "SQLServerToolStripMenuItem"
        resources.ApplyResources(Me.SQLServerToolStripMenuItem, "SQLServerToolStripMenuItem")
        '
        'AccessToolStripMenuItem
        '
        Me.AccessToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.database_access
        Me.AccessToolStripMenuItem.Name = "AccessToolStripMenuItem"
        resources.ApplyResources(Me.AccessToolStripMenuItem, "AccessToolStripMenuItem")
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.ToolStripDropDownButton1.Image = Global.SoftwareZator.My.Resources.Resources.nouvelle_bases_de_donnees_existante
        resources.ApplyResources(Me.ToolStripDropDownButton1, "ToolStripDropDownButton1")
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.SoftwareZator.My.Resources.Resources.database_mysql
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.SoftwareZator.My.Resources.Resources.database_sql
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = Global.SoftwareZator.My.Resources.Resources.database_access
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.SoftwareZator.My.Resources.Resources.nouvelle_table
        resources.ApplyResources(Me.ToolStripButton2, "ToolStripButton2")
        Me.ToolStripButton2.Name = "ToolStripButton2"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.SoftwareZator.My.Resources.Resources.actualiser
        resources.ApplyResources(Me.ToolStripButton3, "ToolStripButton3")
        Me.ToolStripButton3.Name = "ToolStripButton3"
        '
        'BoxBasesDonnees
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kryptonPanel)
        Me.Name = "BoxBasesDonnees"
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonPanel.ResumeLayout(False)
        Me.kryptonPanel.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents kryptonPanel As VelerSoftware.Design.Toolkit.KryptonPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TreeViewMultiSelect1 As VelerSoftware.SZC.TreeViewMultiSelect.TreeViewMultiSelect
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents SQLServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccessToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OuvrirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SupprimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ActualiserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MySQLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
