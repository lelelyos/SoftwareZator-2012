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
Partial Class Gestionnaire_Plugins
    Inherits VelerSoftware.SZVB.AeroWindowsForm

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Gestionnaire_Plugins))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PropertyGrids1 = New VelerSoftware.SZVB.PropertyGrids.PropertyGrids()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Center_Panel.SuspendLayout()
        Me.Foot_Panel.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        Me.Center_Panel.Controls.Add(Me.Label2)
        Me.Center_Panel.Controls.Add(Me.Label1)
        Me.Center_Panel.Controls.Add(Me.SplitContainer1)
        Me.Center_Panel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        '
        'Foot_Panel
        '
        Me.Foot_Panel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Foot_Panel, "Foot_Panel")
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        '
        'OK_Button
        '
        Me.OK_Button.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.SplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        Me.SplitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.SplitContainer1.Panel1, "SplitContainer1.Panel1")
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PropertyGrids1)
        Me.SplitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.SplitContainer1.Panel2, "SplitContainer1.Panel2")
        '
        'TreeView1
        '
        Me.TreeView1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TreeView1, "TreeView1")
        Me.TreeView1.HideSelection = False
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.ShowLines = False
        Me.TreeView1.ShowNodeToolTips = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "gestionnaire_plugins_16.png")
        Me.ImageList1.Images.SetKeyName(1, "cog.png")
        '
        'PropertyGrids1
        '
        Me.PropertyGrids1.AutoSizeProperties = True
        Me.PropertyGrids1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.PropertyGrids1.Cursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        Me.PropertyGrids1.DocCommentDescription.AccessibleName = resources.GetString("PropertyGrids1.DocCommentDescription.AccessibleName")
        Me.PropertyGrids1.DocCommentDescription.AutoEllipsis = True
        Me.PropertyGrids1.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.PropertyGrids1.DocCommentDescription.Font = CType(resources.GetObject("PropertyGrids1.DocCommentDescription.Font"), System.Drawing.Font)
        Me.PropertyGrids1.DocCommentDescription.ImeMode = CType(resources.GetObject("PropertyGrids1.DocCommentDescription.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PropertyGrids1.DocCommentDescription.Location = CType(resources.GetObject("PropertyGrids1.DocCommentDescription.Location"), System.Drawing.Point)
        Me.PropertyGrids1.DocCommentDescription.Name = ""
        Me.PropertyGrids1.DocCommentDescription.RightToLeft = CType(resources.GetObject("PropertyGrids1.DocCommentDescription.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PropertyGrids1.DocCommentDescription.Size = CType(resources.GetObject("PropertyGrids1.DocCommentDescription.Size"), System.Drawing.Size)
        Me.PropertyGrids1.DocCommentDescription.TabIndex = CType(resources.GetObject("PropertyGrids1.DocCommentDescription.TabIndex"), Integer)
        Me.PropertyGrids1.DocCommentImage = Nothing
        '
        '
        '
        Me.PropertyGrids1.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.PropertyGrids1.DocCommentTitle.Font = CType(resources.GetObject("PropertyGrids1.DocCommentTitle.Font"), System.Drawing.Font)
        Me.PropertyGrids1.DocCommentTitle.ImeMode = CType(resources.GetObject("PropertyGrids1.DocCommentTitle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PropertyGrids1.DocCommentTitle.Location = CType(resources.GetObject("PropertyGrids1.DocCommentTitle.Location"), System.Drawing.Point)
        Me.PropertyGrids1.DocCommentTitle.Name = ""
        Me.PropertyGrids1.DocCommentTitle.RightToLeft = CType(resources.GetObject("PropertyGrids1.DocCommentTitle.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PropertyGrids1.DocCommentTitle.Size = CType(resources.GetObject("PropertyGrids1.DocCommentTitle.Size"), System.Drawing.Size)
        Me.PropertyGrids1.DocCommentTitle.TabIndex = CType(resources.GetObject("PropertyGrids1.DocCommentTitle.TabIndex"), Integer)
        Me.PropertyGrids1.DocCommentTitle.UseMnemonic = False
        resources.ApplyResources(Me.PropertyGrids1, "PropertyGrids1")
        Me.PropertyGrids1.Name = "PropertyGrids1"
        Me.PropertyGrids1.SelectedObject = CType(resources.GetObject("PropertyGrids1.SelectedObject"), Object)
        Me.PropertyGrids1.ToolbarVisible = False
        '
        '
        '
        Me.PropertyGrids1.ToolStrip.AccessibleName = resources.GetString("PropertyGrids1.ToolStrip.AccessibleName")
        Me.PropertyGrids1.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.PropertyGrids1.ToolStrip.AllowMerge = False
        Me.PropertyGrids1.ToolStrip.AutoSize = CType(resources.GetObject("PropertyGrids1.ToolStrip.AutoSize"), Boolean)
        Me.PropertyGrids1.ToolStrip.CanOverflow = False
        Me.PropertyGrids1.ToolStrip.Dock = CType(resources.GetObject("PropertyGrids1.ToolStrip.Dock"), System.Windows.Forms.DockStyle)
        Me.PropertyGrids1.ToolStrip.Font = CType(resources.GetObject("PropertyGrids1.ToolStrip.Font"), System.Drawing.Font)
        Me.PropertyGrids1.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PropertyGrids1.ToolStrip.ImeMode = CType(resources.GetObject("PropertyGrids1.ToolStrip.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PropertyGrids1.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.PropertyGrids1.ToolStrip.Location = CType(resources.GetObject("PropertyGrids1.ToolStrip.Location"), System.Drawing.Point)
        Me.PropertyGrids1.ToolStrip.Name = ""
        Me.PropertyGrids1.ToolStrip.Padding = CType(resources.GetObject("PropertyGrids1.ToolStrip.Padding"), System.Windows.Forms.Padding)
        Me.PropertyGrids1.ToolStrip.RightToLeft = CType(resources.GetObject("PropertyGrids1.ToolStrip.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PropertyGrids1.ToolStrip.Size = CType(resources.GetObject("PropertyGrids1.ToolStrip.Size"), System.Drawing.Size)
        Me.PropertyGrids1.ToolStrip.TabIndex = CType(resources.GetObject("PropertyGrids1.ToolStrip.TabIndex"), Integer)
        Me.PropertyGrids1.ToolStrip.TabStop = True
        Me.PropertyGrids1.ToolStrip.Text = resources.GetString("PropertyGrids1.ToolStrip.Text")
        Me.PropertyGrids1.ToolStrip.Visible = CType(resources.GetObject("PropertyGrids1.ToolStrip.Visible"), Boolean)
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.AutoEllipsis = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Name = "Label2"
        '
        'Gestionnaire_Plugins
        '
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.CancelButtonText = "Annuler"
        resources.ApplyResources(Me, "$this")
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.HelpButton = True
        Me.Name = "Gestionnaire_Plugins"
        Me.OKButtonText = "OK"
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Foot_Panel.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents PropertyGrids1 As VelerSoftware.SZVB.PropertyGrids.PropertyGrids
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
