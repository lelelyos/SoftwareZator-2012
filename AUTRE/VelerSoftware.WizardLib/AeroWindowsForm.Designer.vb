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
Partial Class AeroWindowsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AeroWindowsForm))
        Me.Header_Panel = New System.Windows.Forms.Panel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Foot_Panel = New System.Windows.Forms.Panel()
        Me.LabelBevel = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Center_Panel = New System.Windows.Forms.Panel()
        Me.LabelTitle = New System.Windows.Forms.Label()
        Me.Foot_Panel.SuspendLayout()
        Me.Center_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header_Panel
        '
        Me.Header_Panel.BackColor = System.Drawing.Color.Transparent
        Me.Header_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Header_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Header_Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Header_Panel.Name = "Header_Panel"
        Me.Header_Panel.Size = New System.Drawing.Size(284, 40)
        Me.Header_Panel.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cancel_Button.Location = New System.Drawing.Point(185, 14)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(87, 22)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel_Button"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OK_Button.Location = New System.Drawing.Point(92, 14)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(87, 22)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK_Button"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'Foot_Panel
        '
        Me.Foot_Panel.BackColor = System.Drawing.SystemColors.Control
        Me.Foot_Panel.Controls.Add(Me.LabelBevel)
        Me.Foot_Panel.Controls.Add(Me.OK_Button)
        Me.Foot_Panel.Controls.Add(Me.Cancel_Button)
        Me.Foot_Panel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Foot_Panel.Location = New System.Drawing.Point(0, 214)
        Me.Foot_Panel.Name = "Foot_Panel"
        Me.Foot_Panel.Size = New System.Drawing.Size(284, 48)
        Me.Foot_Panel.TabIndex = 1
        '
        'LabelBevel
        '
        Me.LabelBevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelBevel.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelBevel.Location = New System.Drawing.Point(0, 0)
        Me.LabelBevel.Name = "LabelBevel"
        Me.LabelBevel.Size = New System.Drawing.Size(284, 2)
        Me.LabelBevel.TabIndex = 10
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
        Me.Center_Panel.BackColor = System.Drawing.SystemColors.Window
        Me.Center_Panel.Controls.Add(Me.LabelTitle)
        Me.Center_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Center_Panel.Location = New System.Drawing.Point(0, 40)
        Me.Center_Panel.Name = "Center_Panel"
        Me.Center_Panel.Size = New System.Drawing.Size(284, 174)
        Me.Center_Panel.TabIndex = 2
        '
        'LabelTitle
        '
        Me.LabelTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitle.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LabelTitle.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LabelTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelTitle.Location = New System.Drawing.Point(18, 25)
        Me.LabelTitle.Margin = New System.Windows.Forms.Padding(9, 16, 16, 16)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(40, 19)
        Me.LabelTitle.TabIndex = 1
        Me.LabelTitle.Text = "Title"
        '
        'AeroWindowsForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.Center_Panel)
        Me.Controls.Add(Me.Foot_Panel)
        Me.Controls.Add(Me.Header_Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AeroWindowsForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Foot_Panel.ResumeLayout(False)
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LabelBevel As System.Windows.Forms.Label
    Public WithEvents Center_Panel As System.Windows.Forms.Panel
    Public WithEvents Foot_Panel As System.Windows.Forms.Panel
    Public WithEvents Cancel_Button As System.Windows.Forms.Button
    Public WithEvents OK_Button As System.Windows.Forms.Button
    Public WithEvents LabelTitle As System.Windows.Forms.Label
    Public WithEvents Header_Panel As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class