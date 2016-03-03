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
Partial Class ActionForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActionForm))
        Me.Header_Panel = New System.Windows.Forms.Panel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Foot_Panel = New System.Windows.Forms.Panel()
        Me.ParseCodeButton = New System.Windows.Forms.Button()
        Me.RefreshCodeButton = New System.Windows.Forms.Button()
        Me.CodeEditorPanel = New System.Windows.Forms.Panel()
        Me.CodeEditorHost = New System.Windows.Forms.Integration.ElementHost()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CouperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SélectionnerToutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AnnulerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RétablirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Help_Button = New System.Windows.Forms.PictureBox()
        Me.EditCode_CheckBox = New System.Windows.Forms.CheckBox()
        Me.ShowHideCodeEditor_Button = New System.Windows.Forms.PictureBox()
        Me.LabelBevel = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Center_Panel = New System.Windows.Forms.Panel()
        Me.Controls_Panel = New System.Windows.Forms.Panel()
        Me.Icon_PictureBox = New System.Windows.Forms.PictureBox()
        Me.LabelTitle = New System.Windows.Forms.Label()
        Me.Foot_Panel.SuspendLayout()
        Me.CodeEditorPanel.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.Help_Button, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShowHideCodeEditor_Button, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Center_Panel.SuspendLayout()
        CType(Me.Icon_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Header_Panel
        '
        Me.Header_Panel.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Header_Panel, "Header_Panel")
        Me.Header_Panel.Name = "Header_Panel"
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'Foot_Panel
        '
        Me.Foot_Panel.BackColor = System.Drawing.SystemColors.Control
        Me.Foot_Panel.Controls.Add(Me.ParseCodeButton)
        Me.Foot_Panel.Controls.Add(Me.RefreshCodeButton)
        Me.Foot_Panel.Controls.Add(Me.CodeEditorPanel)
        Me.Foot_Panel.Controls.Add(Me.Help_Button)
        Me.Foot_Panel.Controls.Add(Me.EditCode_CheckBox)
        Me.Foot_Panel.Controls.Add(Me.ShowHideCodeEditor_Button)
        Me.Foot_Panel.Controls.Add(Me.LabelBevel)
        Me.Foot_Panel.Controls.Add(Me.OK_Button)
        Me.Foot_Panel.Controls.Add(Me.Cancel_Button)
        resources.ApplyResources(Me.Foot_Panel, "Foot_Panel")
        Me.Foot_Panel.Name = "Foot_Panel"
        '
        'ParseCodeButton
        '
        Me.ParseCodeButton.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.refresh
        resources.ApplyResources(Me.ParseCodeButton, "ParseCodeButton")
        Me.ParseCodeButton.Name = "ParseCodeButton"
        Me.ToolTip1.SetToolTip(Me.ParseCodeButton, resources.GetString("ParseCodeButton.ToolTip"))
        Me.ParseCodeButton.UseVisualStyleBackColor = True
        '
        'RefreshCodeButton
        '
        Me.RefreshCodeButton.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.show_code
        resources.ApplyResources(Me.RefreshCodeButton, "RefreshCodeButton")
        Me.RefreshCodeButton.Name = "RefreshCodeButton"
        Me.ToolTip1.SetToolTip(Me.RefreshCodeButton, resources.GetString("RefreshCodeButton.ToolTip"))
        Me.RefreshCodeButton.UseVisualStyleBackColor = True
        '
        'CodeEditorPanel
        '
        resources.ApplyResources(Me.CodeEditorPanel, "CodeEditorPanel")
        Me.CodeEditorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CodeEditorPanel.Controls.Add(Me.CodeEditorHost)
        Me.CodeEditorPanel.Name = "CodeEditorPanel"
        '
        'CodeEditorHost
        '
        Me.CodeEditorHost.ContextMenuStrip = Me.ContextMenuStrip1
        resources.ApplyResources(Me.CodeEditorHost, "CodeEditorHost")
        Me.CodeEditorHost.Name = "CodeEditorHost"
        Me.CodeEditorHost.Child = Nothing
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopierToolStripMenuItem, Me.CouperToolStripMenuItem, Me.CollerToolStripMenuItem, Me.ToolStripSeparator1, Me.SélectionnerToutToolStripMenuItem, Me.ToolStripSeparator2, Me.AnnulerToolStripMenuItem, Me.RétablirToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        '
        'CopierToolStripMenuItem
        '
        Me.CopierToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.copy_small
        Me.CopierToolStripMenuItem.Name = "CopierToolStripMenuItem"
        resources.ApplyResources(Me.CopierToolStripMenuItem, "CopierToolStripMenuItem")
        '
        'CouperToolStripMenuItem
        '
        Me.CouperToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.cut
        Me.CouperToolStripMenuItem.Name = "CouperToolStripMenuItem"
        resources.ApplyResources(Me.CouperToolStripMenuItem, "CouperToolStripMenuItem")
        '
        'CollerToolStripMenuItem
        '
        Me.CollerToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.paste_sma
        Me.CollerToolStripMenuItem.Name = "CollerToolStripMenuItem"
        resources.ApplyResources(Me.CollerToolStripMenuItem, "CollerToolStripMenuItem")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'SélectionnerToutToolStripMenuItem
        '
        Me.SélectionnerToutToolStripMenuItem.Name = "SélectionnerToutToolStripMenuItem"
        resources.ApplyResources(Me.SélectionnerToutToolStripMenuItem, "SélectionnerToutToolStripMenuItem")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'AnnulerToolStripMenuItem
        '
        Me.AnnulerToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.undo
        Me.AnnulerToolStripMenuItem.Name = "AnnulerToolStripMenuItem"
        resources.ApplyResources(Me.AnnulerToolStripMenuItem, "AnnulerToolStripMenuItem")
        '
        'RétablirToolStripMenuItem
        '
        Me.RétablirToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.redo
        Me.RétablirToolStripMenuItem.Name = "RétablirToolStripMenuItem"
        resources.ApplyResources(Me.RétablirToolStripMenuItem, "RétablirToolStripMenuItem")
        '
        'Help_Button
        '
        Me.Help_Button.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.help
        resources.ApplyResources(Me.Help_Button, "Help_Button")
        Me.Help_Button.Name = "Help_Button"
        Me.Help_Button.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Help_Button, resources.GetString("Help_Button.ToolTip"))
        '
        'EditCode_CheckBox
        '
        resources.ApplyResources(Me.EditCode_CheckBox, "EditCode_CheckBox")
        Me.EditCode_CheckBox.Name = "EditCode_CheckBox"
        Me.ToolTip1.SetToolTip(Me.EditCode_CheckBox, resources.GetString("EditCode_CheckBox.ToolTip"))
        Me.EditCode_CheckBox.UseVisualStyleBackColor = True
        '
        'ShowHideCodeEditor_Button
        '
        Me.ShowHideCodeEditor_Button.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.ChevronMore
        resources.ApplyResources(Me.ShowHideCodeEditor_Button, "ShowHideCodeEditor_Button")
        Me.ShowHideCodeEditor_Button.Name = "ShowHideCodeEditor_Button"
        Me.ShowHideCodeEditor_Button.TabStop = False
        Me.ToolTip1.SetToolTip(Me.ShowHideCodeEditor_Button, resources.GetString("ShowHideCodeEditor_Button.ToolTip"))
        '
        'LabelBevel
        '
        Me.LabelBevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.LabelBevel, "LabelBevel")
        Me.LabelBevel.Name = "LabelBevel"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'Center_Panel
        '
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        Me.Center_Panel.BackColor = System.Drawing.SystemColors.Window
        Me.Center_Panel.Controls.Add(Me.Controls_Panel)
        Me.Center_Panel.Controls.Add(Me.Icon_PictureBox)
        Me.Center_Panel.Controls.Add(Me.LabelTitle)
        Me.Center_Panel.Name = "Center_Panel"
        '
        'Controls_Panel
        '
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        Me.Controls_Panel.BackColor = System.Drawing.SystemColors.Window
        Me.Controls_Panel.Name = "Controls_Panel"
        '
        'Icon_PictureBox
        '
        Me.Icon_PictureBox.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Icon_PictureBox, "Icon_PictureBox")
        Me.Icon_PictureBox.Name = "Icon_PictureBox"
        Me.Icon_PictureBox.TabStop = False
        '
        'LabelTitle
        '
        resources.ApplyResources(Me.LabelTitle, "LabelTitle")
        Me.LabelTitle.AutoEllipsis = True
        Me.LabelTitle.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitle.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LabelTitle.Name = "LabelTitle"
        '
        'ActionForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.CancelButton = Me.Cancel_Button
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.Center_Panel)
        Me.Controls.Add(Me.Foot_Panel)
        Me.Controls.Add(Me.Header_Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ActionForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Foot_Panel.ResumeLayout(False)
        Me.CodeEditorPanel.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.Help_Button, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShowHideCodeEditor_Button, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Center_Panel.ResumeLayout(False)
        CType(Me.Icon_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Header_Panel As System.Windows.Forms.Panel
    Private WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LabelBevel As System.Windows.Forms.Label
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CodeEditorHost As System.Windows.Forms.Integration.ElementHost
    Private WithEvents Icon_PictureBox As System.Windows.Forms.PictureBox
    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents ShowHideCodeEditor_Button As System.Windows.Forms.PictureBox
    Friend WithEvents Foot_Panel As System.Windows.Forms.Panel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents EditCode_CheckBox As System.Windows.Forms.CheckBox
    Public WithEvents Center_Panel As System.Windows.Forms.Panel
    Friend WithEvents Help_Button As System.Windows.Forms.PictureBox
    Private WithEvents CodeEditorPanel As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CouperToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CollerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SélectionnerToutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AnnulerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RétablirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshCodeButton As System.Windows.Forms.Button
    Public WithEvents Controls_Panel As System.Windows.Forms.Panel
    Friend WithEvents ParseCodeButton As System.Windows.Forms.Button
End Class